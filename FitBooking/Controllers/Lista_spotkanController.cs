using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FitBooking.Models;
namespace FitBooking.Controllers
{
    [RoutePrefix("ListaSpotkan")]
    public class Lista_spotkanController : Controller
    {
        private Entities3 db = new Entities3();

        // GET: Lista_spotkan
        [Route("")]
        public ActionResult Index()
        {
            var lista_spotkan = db.Lista_spotkan.Include(l => l.Spotkanie).Include(l => l.Uzytkownik).Include(l => l.Uzytkownik1);
            return View(lista_spotkan.ToList());
        }

        // GET: Lista_spotkan/Details/5
        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista_spotkan lista_spotkan = db.Lista_spotkan.Find(id);
            if (lista_spotkan == null)
            {
                return HttpNotFound();
            }
            return View(lista_spotkan);
        }

        // GET: Lista_spotkan/Create
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.id_spotkanie = new SelectList(db.Spotkanie, "Id", "opis");
            ViewBag.id_funkcyjna = new SelectList(db.Uzytkownik, "Id", "imie");
            ViewBag.id_klient = new SelectList(db.Uzytkownik, "Id", "imie");
            return View();
        }

        // POST: Lista_spotkan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,id_funkcyjna,id_klient,id_spotkanie,status")] Lista_spotkan lista_spotkan)
        {
            if (ModelState.IsValid)
            {
                db.Lista_spotkan.Add(lista_spotkan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_spotkanie = new SelectList(db.Spotkanie, "Id", "opis", lista_spotkan.id_spotkanie);
            ViewBag.id_funkcyjna = new SelectList(db.Uzytkownik, "Id", "imie", lista_spotkan.id_funkcyjna);
            ViewBag.id_klient = new SelectList(db.Uzytkownik, "Id", "imie", lista_spotkan.id_klient);
            return View(lista_spotkan);
        }

        // GET: Lista_spotkan/Edit/5
        [Route("Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista_spotkan lista_spotkan = db.Lista_spotkan.Find(id);
            if (lista_spotkan == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_spotkanie = new SelectList(db.Spotkanie, "Id", "opis", lista_spotkan.id_spotkanie);
            ViewBag.id_funkcyjna = new SelectList(db.Uzytkownik, "Id", "imie", lista_spotkan.id_funkcyjna);
            ViewBag.id_klient = new SelectList(db.Uzytkownik, "Id", "imie", lista_spotkan.id_klient);
            return View(lista_spotkan);
        }

        // POST: Lista_spotkan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,id_funkcyjna,id_klient,id_spotkanie,status")] Lista_spotkan lista_spotkan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lista_spotkan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_spotkanie = new SelectList(db.Spotkanie, "Id", "opis", lista_spotkan.id_spotkanie);
            ViewBag.id_funkcyjna = new SelectList(db.Uzytkownik, "Id", "imie", lista_spotkan.id_funkcyjna);
            ViewBag.id_klient = new SelectList(db.Uzytkownik, "Id", "imie", lista_spotkan.id_klient);
            return View(lista_spotkan);
        }

        // GET: Lista_spotkan/Delete/5
        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista_spotkan lista_spotkan = db.Lista_spotkan.Find(id);
            if (lista_spotkan == null)
            {
                return HttpNotFound();
            }
            return View(lista_spotkan);
        }

        // POST: Lista_spotkan/Delete/5
        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lista_spotkan lista_spotkan = db.Lista_spotkan.Find(id);
            db.Lista_spotkan.Remove(lista_spotkan);
            db.SaveChanges();
            return RedirectToAction("Index");
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
