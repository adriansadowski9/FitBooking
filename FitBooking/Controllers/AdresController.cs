using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FitBooking.Models;
using System.Xml.Linq;

namespace FitBooking.Controllers
{
    [RoutePrefix("Adres")]
    public class AdresController : Controller
    {
       
        private Entities3 db = new Entities3();

        // GET: Adres
        [Route("")]
        [Authorize(Roles = "administrator")]
        public ActionResult Index()
        {
            var adres = db.Adres.Include(a => a.Uzytkownik);
            return View(adres.ToList());
        }

        // GET: Adres/Details/5
        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adres adres = db.Adres.Find(id);
            if (adres == null)
            {
                return HttpNotFound();
            }
            return View(adres);
        }

        // GET: Adres/Create    
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie");
            return View();
        }

        // POST: Adres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ulica,nr_domu,kod_pocztowy,miasto,panstwo,id_uzytkownik,szerokosc,dlugosc")] Adres adres)
        {
            if (ModelState.IsValid)
            {
                
                var u = db.AspNetUsers.SingleOrDefault(x => x.Email == User.Identity.Name);
                Uzytkownik p = db.Uzytkownik.SingleOrDefault(x => x.id_aspUser == u.Id);
                Adres a = db.Adres.SingleOrDefault(x => x.id_uzytkownik== p.Id);
                if (a != null)
                {
                    return Redirect("/UzytkownikHome/Index");
                }
                else
                {
                    string requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(adres.ulica+"+"+adres.nr_domu+"+"+adres.kod_pocztowy+"+"+adres.miasto+"+"+adres.panstwo));

                    WebRequest request = WebRequest.Create(requestUri);
                    WebResponse response = request.GetResponse();
                    XDocument xdoc = XDocument.Load(response.GetResponseStream());

                    XElement result = xdoc.Element("GeocodeResponse").Element("result");
                    XElement locationElement = result.Element("geometry").Element("location");
                    XElement lat = locationElement.Element("lat");
                    XElement lng = locationElement.Element("lng");

                    adres.szerokosc = (string)lat;
                    adres.dlugosc = (string)lng;

                    adres.id_uzytkownik = p.Id;
                    db.Adres.Add(adres);
                    db.SaveChanges();
                    return Redirect("/Spolecznosc/Create");
                }
            }

            ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie", adres.id_uzytkownik);
            return View(adres);
        }

        // GET: Adres/Edit/5
        [Route("Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adres adres = db.Adres.Find(id);
            if (adres == null)
            {
                return Redirect("/UzytkownikHome/Index");
            }
           // ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie", adres.id_uzytkownik);
            return View(adres);
        }

        // POST: Adres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ulica,nr_domu,kod_pocztowy,miasto,panstwo,id_uzytkownik,szerokosc,dlugosc")] Adres adres)
        {
            if (ModelState.IsValid)
            {
                var u = db.AspNetUsers.SingleOrDefault(x => x.Email == User.Identity.Name);
                Uzytkownik p = db.Uzytkownik.SingleOrDefault(x => x.id_aspUser == u.Id);
                adres.id_uzytkownik = p.Id;

                string requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(adres.ulica+"+"+adres.nr_domu+"+"+adres.kod_pocztowy+"+"+adres.miasto+"+"+adres.panstwo));

                    WebRequest request = WebRequest.Create(requestUri);
                    WebResponse response = request.GetResponse();
                    XDocument xdoc = XDocument.Load(response.GetResponseStream());

                    XElement result = xdoc.Element("GeocodeResponse").Element("result");
                    XElement locationElement = result.Element("geometry").Element("location");
                    XElement lat = locationElement.Element("lat");
                    XElement lng = locationElement.Element("lng");

                    adres.szerokosc = (string)lat;
                    adres.dlugosc = (string)lng;


                db.Entry(adres).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("/UzytkownikHome/Index");
            }
           // ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie", adres.id_uzytkownik);
            return View(adres);
        }

        // GET: Adres/Delete/5
        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adres adres = db.Adres.Find(id);
            if (adres == null)
            {
                return Redirect("/UzytkownikHome/Index");
            }
            return View(adres);
        }

        // POST: Adres/Delete/5
        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adres adres = db.Adres.Find(id);
            db.Adres.Remove(adres);
            db.SaveChanges();
            return Redirect("/UzytkownikHome/Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
