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
    public partial class Wyszukaj : Page
    {
        private Entities3 db = new Entities3();
        private ApplicationDbContext db1 = new ApplicationDbContext();

        private string szerokosc;
        private string dlugosc;
        private string typ;
        private string adres;
        private string htmlText;
        private string tempSzer;
        private string tempDlug;
        private int iloscWynikow = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["adres"]) && !String.IsNullOrEmpty(Request.QueryString["typwyszukania"]))
            {
                adres = Request.QueryString["adres"];
                typ = Request.QueryString["typwyszukania"];
                string requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(adres));
                try { 
                WebRequest request = WebRequest.Create(requestUri);
                WebResponse response = request.GetResponse();
                XDocument xdoc = XDocument.Load(response.GetResponseStream());

                XElement result = xdoc.Element("GeocodeResponse").Element("result");
                XElement locationElement = result.Element("geometry").Element("location");
                XElement lat = locationElement.Element("lat");
                XElement lng = locationElement.Element("lng");

                szerokosc = (string)lat;
                dlugosc = (string)lng;
                }

                catch
                {
                    Response.Redirect(Request.RawUrl);
                }

                /*var distance = new Coordinates(Convert.ToDouble(szerokosc), Convert.ToDouble(dlugosc))
                .DistanceTo(new Coordinates(48.237867, 16.389477),UnitOfLength.Kilometers);*/


                var listOfUsers = (from u in db1.Users
                                   let query = (from ur in db1.Set<IdentityUserRole>()
                                                where ur.UserId.Equals(u.Id)
                                                join r in db1.Roles on ur.RoleId equals r.Id
                                                select r.Name)
                                   select new UserRoleInfo() { User = u, Roles = query.ToList<string>() })
                         .ToList();

                List<UserRoleInfo> listaTyp = new List<UserRoleInfo>();
                if (typ == "trener")
                    listaTyp = listOfUsers.Where(x => x.Roles.ElementAtOrDefault(0) == "trener").ToList();
                else listaTyp = listOfUsers.Where(x => x.Roles.ElementAtOrDefault(0) == "dietetyk").ToList();


                List<ModelUserProfil> listaM = new List<ModelUserProfil>();


                foreach (UserRoleInfo user in listaTyp)
                {
                    if (user.Roles.FirstOrDefault() != "administrator" && user.Roles.FirstOrDefault() != "klient")
                    {
                        Uzytkownik t = db.Uzytkownik.SingleOrDefault(k => k.id_aspUser == user.User.Id);
                        if (t != null)
                        {
                            Adres a = db.Adres.SingleOrDefault(k => k.id_uzytkownik == t.Id);
                            ModelUserProfil m = new ModelUserProfil();
                            m.user = t;
                            m.adres = a;
                            m.rola = user.Roles.FirstOrDefault();
                            listaM.Add(m);
                        }
                    }
                }

                ModelUserProfil wynik;
                List<ModelUserProfil> lista = new List<ModelUserProfil>(); ;

                foreach (var item in listaM)
                {
                    tempSzer = item.adres.szerokosc;
                    tempDlug = item.adres.dlugosc;

                    var distance = new Coordinates(Convert.ToDouble(tempSzer, CultureInfo.InvariantCulture), Convert.ToDouble(tempDlug, CultureInfo.InvariantCulture)).DistanceTo(new Coordinates(Convert.ToDouble(szerokosc, CultureInfo.InvariantCulture), Convert.ToDouble(dlugosc, CultureInfo.InvariantCulture)), UnitOfLength.Kilometers);
                    if (distance < 30)
                    {
                        iloscWynikow++;
                        wynik = item;
                        wynik.dystans = distance;
                        lista.Add(wynik);
                    }
                }

                ////TUUUUU 
                List<ModelUserProfil> SortedList = lista.OrderBy(o => o.dystans).ToList();
                htmlText += "<div class='searchBoxes'>";
                foreach (var item in SortedList)
                {
                    htmlText += "<div class='containerSearchCard'>";
                    htmlText += "<div class='img-container'>";
                    if (typ == "trener")
                        htmlText += "<img src='images/trainerIcon2.png'/>";
                    else
                        htmlText += "<img src='images/dietIcon.png'/>";
                    htmlText += "</div>";
                    htmlText += "<div class='contentSearchCard'>";
                    htmlText += "<div class='titleSearchCard'>";
                    htmlText += "  <p><a href='/profil?id=" + item.user.Id + "'>" + item.user.imie + " " + item.user.nazwisko + "</a></p>";
                    if (typ == "trener")
                        htmlText += "  <span>Trener personalny</span>";
                    else
                        htmlText += "  <span>Dietetyk</span>";
                    htmlText += " </div>";
                    htmlText += "<div class='distance'><img src='images/distance.png'/><br>";
                    htmlText += Math.Round(item.dystans, 1) + " km </div>";

                    htmlText += "  <div class='followSearchCard'><a href='/profil?id=" + item.user.Id + "'>Przejdz do profilu </a></div>";
                    htmlText += " </div>";
                    htmlText += " </div>";


                }
                htmlText += "</div>";

                if (iloscWynikow == 0)
                    htmlText += "Brak wyników";

            }

            else
            {
                Response.Redirect("~");
            }



        }
        public string Szerokosc { get { return szerokosc; } }
        public string Dlugosc { get { return dlugosc; } }
        public string Typ { get { return typ; } }
        public string Adres { get { return adres; } }
        public string HtmlText { get { return htmlText; } }
    }
}