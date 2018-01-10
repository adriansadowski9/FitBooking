using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Configuration;
using System.Diagnostics;
using FitBooking.Models;

namespace FitBooking
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await SendEmail(message);
        }

        private static SmtpClient _smtpClient;
        static EmailService()
        {
        _smtpClient = new SmtpClient();
        }
        private async Task SendEmail(IdentityMessage message)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("luvisonx@gmail.com", "FitBooking", Encoding.UTF8);
                mail.Bcc.Add(new MailAddress(message.Destination));
                mail.Subject = message.Subject;
                mail.Body = message.Body;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.BodyEncoding = Encoding.UTF8;
                mail.Priority = MailPriority.High;
                _smtpClient.Send(mail);
            }
        }
    }



    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Dołącz tutaj usługę wiadomości SMS, aby wysłać wiadomość SMS.
            return Task.FromResult(0);
        }
    }

    // Skonfiguruj menedżera użytkowników aplikacji używanego w tej aplikacji. Interfejs UserManager jest zdefiniowany w produkcie ASP.NET Identity i jest używany przez aplikację.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Konfiguruj logikę weryfikacji nazw użytkowników
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Konfiguruj logikę weryfikacji haseł
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Zarejestruj dostawców uwierzytelniania dwuetapowego. W przypadku tej aplikacji kod weryfikujący użytkownika jest uzyskiwany przez telefon i pocztą e-mail
            // Możesz zapisać własnego dostawcę i dołączyć go tutaj.
            manager.RegisterTwoFactorProvider("Kod — telefon", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Twój kod zabezpieczający: {0}"
            });
            manager.RegisterTwoFactorProvider("Kod — e-mail", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Kod zabezpieczający",
                BodyFormat = "Twój kod zabezpieczający: {0}"
            });

            // Konfiguruj ustawienia domyślne blokady użytkownika
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

        public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
        {
            public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager) :
                base(userManager, authenticationManager)
            { }

            public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
            {
                return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
            }

            public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
            {
                return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
            }
        }
}
