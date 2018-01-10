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

    [RoutePrefix("ListaKwalifikacji")]
    public class Lista_kwalifikacjiController : Controller
    {
        private Entities3 db = new Entities3();

        // GET: Lista_kwalifikacji

        [Route("")]
        public ActionResult Index()
        {
            var lista_kwalifikacji = db.Lista_kwalifikacji.Include(l => l.Kwalifikacja).Include(l => l.Uzytkownik);
            return View(lista_kwalifikacji.ToList());
        }

        // GET: Lista_kwalifikacji/Details/5
        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista_kwalifikacji lista_kwalifikacji = db.Lista_kwalifikacji.Find(id);
            if (lista_kwalifikacji == null)
            {
                return HttpNotFound();
            }
            return View(lista_kwalifikacji);
        }

        // GET: Lista_kwalifikacji/Create
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.id_kwalifikacja = new SelectList(db.Kwalifikacja, "Id", "nazwa");
            ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie");
            return View();
        }

        // POST: Lista_kwalifikacji/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,id_uzytkownik,id_kwalifikacja")] Lista_kwalifikacji lista_kwalifikacji)
        {
            if (ModelState.IsValid)
            {
                db.Lista_kwalifikacji.Add(lista_kwalifikacji);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_kwalifikacja = new SelectList(db.Kwalifikacja, "Id", "nazwa", lista_kwalifikacji.id_kwalifikacja);
            ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie", lista_kwalifikacji.id_uzytkownik);
            return View(lista_kwalifikacji);
        }

        // GET: Lista_kwalifikacji/Edit/5
        [Route("Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista_kwalifikacji lista_kwalifikacji = db.Lista_kwalifikacji.Find(id);
            if (lista_kwalifikacji == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_kwalifikacja = new SelectList(db.Kwalifikacja, "Id", "nazwa", lista_kwalifikacji.id_kwalifikacja);
            ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie", lista_kwalifikacji.id_uzytkownik);
            return View(lista_kwalifikacji);
        }

        // POST: Lista_kwalifikacji/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,id_uzytkownik,id_kwalifikacja")] Lista_kwalifikacji lista_kwalifikacji)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lista_kwalifikacji).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_kwalifikacja = new SelectList(db.Kwalifikacja, "Id", "nazwa", lista_kwalifikacji.id_kwalifikacja);
            ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie", lista_kwalifikacji.id_uzytkownik);
            return View(lista_kwalifikacji);
        }

        // GET: Lista_kwalifikacji/Delete/5
        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista_kwalifikacji lista_kwalifikacji = db.Lista_kwalifikacji.Find(id);
            if (lista_kwalifikacji == null)
            {
                return HttpNotFound();
            }
            return View(lista_kwalifikacji);
        }

        // POST: Lista_kwalifikacji/Delete/5
        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lista_kwalifikacji lista_kwalifikacji = db.Lista_kwalifikacji.Find(id);
            db.Lista_kwalifikacji.Remove(lista_kwalifikacji);
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
