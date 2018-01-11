using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using FitBooking.CsScripts;

namespace FitBooking
{
    public partial class Wyszukaj : Page
    {
        private string szerokosc;
        private string dlugosc;
        private double szerokoscDouble;
        private double dlugoscDouble;
        private string typ;
        private string adres;
        private double odleglosc;
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

                szerokoscDouble = Convert.ToDouble(szerokosc.Replace('.', ','));
                dlugoscDouble = Convert.ToDouble(dlugosc.Replace('.', ','));

                /*var distance = new Coordinates(Convert.ToDouble(szerokosc), Convert.ToDouble(dlugosc))
                .DistanceTo(new Coordinates(48.237867, 16.389477),UnitOfLength.Kilometers);*/

                var distance = new Coordinates(54.3186888, 18.5676637)
                .DistanceTo(
                    new Coordinates(szerokoscDouble, dlugoscDouble),
                    UnitOfLength.Kilometers
                );

                odleglosc = distance;


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
        public double Odleglosc { get { return odleglosc; } }
    }
}