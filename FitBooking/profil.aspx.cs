using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using FitBooking.CsScripts;
using FitBooking.Models;
using System.Globalization;

namespace FitBooking
{
    public partial class Profil : Page
    {
        private Entities3 db = new Entities3();
        private ApplicationDbContext db1 = new ApplicationDbContext();
        private string htmlText;
        private string pid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                pid = Request.QueryString["id"];

            }

            else
            {
                Response.Redirect("~");
            }

            int id = Int32.Parse(pid); 
           Uzytkownik user = db.Uzytkownik.SingleOrDefault(k => k.Id == id);

            string facebook = "brak";
            string twitter = "brak";
            string instagram = "brak";
            string miasto= "brak";
            string oMnie = "brak";

            var spolecznosc = db.Spolecznosc.Where(x => x.id_uzytkownik == id).FirstOrDefault();
            var info = db.Info.Where(x => x.id_uzytkownik == id).FirstOrDefault();
            var adres = db.Adres.Where(x => x.id_uzytkownik == id).FirstOrDefault();

            if (spolecznosc != null)
            {
                if (spolecznosc.facebook != null)
                    facebook = spolecznosc.facebook;

                if (spolecznosc.twitter != null)
                    twitter = spolecznosc.twitter;

                if (spolecznosc.instagram != null)
                    instagram = spolecznosc.instagram;
            }
                if (user.Adres.ElementAtOrDefault(0).miasto != null)
                    miasto = user.Adres.ElementAtOrDefault(0).miasto;

            if (info != null)
            {
                if (info.oMnie != null)
                    oMnie =info.oMnie;
            }

            if (adres!= null)
            {
                if (adres.miasto != null)
                   miasto = adres.miasto;
            }

            htmlText += user.imie;
            htmlText += user.nazwisko;
            htmlText += miasto;
            htmlText += user.AspNetUsers.Email;
            htmlText += facebook;
            htmlText += twitter;
            htmlText += instagram;
            htmlText += oMnie;

            htmlText += "<a href='/Kalendarz?id=" + user.Id + "'>Kalendarz </a></div>";







        }
    }
}