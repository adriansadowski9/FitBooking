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

                WebRequest request = WebRequest.Create(requestUri);
                WebResponse response = request.GetResponse();
                XDocument xdoc = XDocument.Load(response.GetResponseStream());

                XElement result = xdoc.Element("GeocodeResponse").Element("result");
                XElement locationElement = result.Element("geometry").Element("location");
                XElement lat = locationElement.Element("lat");
                XElement lng = locationElement.Element("lng");

                szerokosc = (string)lat;
                dlugosc = (string)lng;

                /*var distance = new Coordinates(Convert.ToDouble(szerokosc), Convert.ToDouble(dlugosc))
                .DistanceTo(new Coordinates(48.237867, 16.389477),UnitOfLength.Kilometers);*/


                var listOfUsers = (from u in db1.Users
                                   let query = (from ur in db1.Set<IdentityUserRole>()
                                                where ur.UserId.Equals(u.Id)
                                                join r in db1.Roles on ur.RoleId equals r.Id
                                                select r.Name)
                                   select new UserRoleInfo() { User = u, Roles = query.ToList<string>() })
                         .ToList();

                var trenerzy = listOfUsers.Where(x => x.Roles.ElementAtOrDefault(0) == "trener").ToList();
                var dietetycy = listOfUsers.Where(x => x.Roles.ElementAtOrDefault(0) == "dietetyk").ToList();

                List<Uzytkownik> listaTrener = new List<Uzytkownik>();
                List<ModelUserProfil> listaM = new List<ModelUserProfil>();
                List<Uzytkownik> listaDietetyk = new List<Uzytkownik>();

                foreach (UserRoleInfo user in listOfUsers)
                {
                    if (user.Roles.ElementAtOrDefault(0) != "administrator" && user.Roles.ElementAtOrDefault(0) != "klient")
                    {
                        Uzytkownik t = db.Uzytkownik.SingleOrDefault(k => k.id_aspUser == user.User.Id);
                        Adres a = db.Adres.SingleOrDefault(k => k.id_uzytkownik == t.Id);
                        ModelUserProfil m = new ModelUserProfil();
                        m.user = t;
                        m.adres = a;
                        m.rola = user.Roles.ElementAtOrDefault(0);
                        listaM.Add(m);
                    }
                }

                ModelUserProfil wynik; 
                List<ModelUserProfil> lista = new List<ModelUserProfil>(); ;

                foreach (var item in listaM)
                {
                    tempSzer = item.adres.szerokosc;
                    tempDlug = item.adres.dlugosc;

                    var distance = new Coordinates(Convert.ToDouble(tempSzer, CultureInfo.InvariantCulture), Convert.ToDouble(tempDlug, CultureInfo.InvariantCulture)).DistanceTo(new Coordinates(Convert.ToDouble(szerokosc, CultureInfo.InvariantCulture), Convert.ToDouble(dlugosc, CultureInfo.InvariantCulture)), UnitOfLength.Kilometers);
                    if ((distance < 30) && item.rola == typ)
                    {
                        
                        htmlText += "</br>Imie i nazwisko: " + item.user.imie + " " + item.user.nazwisko;
                        htmlText += "</br>Profesja: " + item.rola;
                        htmlText += "</br>Odległość: " + Math.Round(distance, 1) +" km";
                        iloscWynikow++;


                        wynik = item;
                        wynik.dystans = distance; 
                        lista.Add(wynik);
                        

                    }
                }

                ////TUUUUU 
                List<ModelUserProfil> SortedList = lista.OrderBy(o => o.dystans).ToList();

                foreach (var item in SortedList)
                {
                    htmlText += "</br>Imie i nazwisko: " + item.user.imie + " " + item.user.nazwisko;
                    htmlText += "</br>Profesja: " + item.rola;
                    htmlText += "</br>Odległość: " + Math.Round(item.dystans, 1) + " km";

                }





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