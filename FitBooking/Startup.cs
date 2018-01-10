using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FitBooking.Startup))]
namespace FitBooking
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
