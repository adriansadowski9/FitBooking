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
        string facebook = "brak";
        string snapchat = "brak";
        string twitter = "brak";
        string instagram = "brak";
        string miasto = "brak";
        string oMnie = "brak";
        string szerokosc;
        string dlugosc;
        int id;
        Uzytkownik user;
        Spolecznosc spolecznosc;
        Info info;
        Adres adres;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                id = Int32.Parse(Request.QueryString["id"]);
                user = db.Uzytkownik.SingleOrDefault(k => k.Id == id);

                spolecznosc = db.Spolecznosc.Where(x => x.id_uzytkownik == id).FirstOrDefault();
                info = db.Info.Where(x => x.id_uzytkownik == id).FirstOrDefault();
                adres = db.Adres.Where(x => x.id_uzytkownik == id).FirstOrDefault();

                if (spolecznosc != null)
                {
                    if (spolecznosc.facebook != null)
                        facebook = spolecznosc.facebook;

                    if (spolecznosc.twitter != null)
                        twitter = spolecznosc.twitter;

                    if (spolecznosc.instagram != null)
                        instagram = spolecznosc.instagram;

                    if (spolecznosc.snapchat != null)
                        snapchat = spolecznosc.snapchat;
                }
                if (user.Adres.ElementAtOrDefault(0).miasto != null)
                    miasto = user.Adres.ElementAtOrDefault(0).miasto;

                if (info != null)
                {
                    if (info.oMnie != null)
                        oMnie = info.oMnie;
                }

                if (adres != null)
                {
                    if (adres.miasto != null)
                        miasto = adres.miasto;
                    if (adres.szerokosc != null)
                        szerokosc = adres.szerokosc;
                    if (adres.dlugosc != null)
                        dlugosc = adres.dlugosc;
                }

            }

            else
            {
                Response.Redirect("~");
            }
        }
        public string Facebook { get { return facebook; } }
        public string Twitter { get { return twitter; } }
        public string Instagram { get { return instagram; } }
        public string Snapchat { get { return snapchat; } }
        public Uzytkownik User { get { return user; } }
        public string OMnie { get { return oMnie; } }
        public string Miasto { get { return miasto; } }
        public string Szerokosc { get { return szerokosc; } }
        public string Dlugosc { get { return dlugosc; } }
    }

}