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
    [RoutePrefix("ListaUslug")]
    public class Lista_UslugController : Controller
    {
        private Entities3 db = new Entities3();

        // GET: Lista_Uslug
        [Route("")]
        public ActionResult Index()
        {
            var lista_Uslug = db.Lista_Uslug.Include(l => l.Usluga).Include(l => l.Uzytkownik);
            return View(lista_Uslug.ToList());
        }

        // GET: Lista_Uslug/Details/5
        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista_Uslug lista_Uslug = db.Lista_Uslug.Find(id);
            if (lista_Uslug == null)
            {
                return HttpNotFound();
            }
            return View(lista_Uslug);
        }

        // GET: Lista_Uslug/Create
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.id_usluga = new SelectList(db.Usluga, "Id", "nazwa");
            ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie");
            return View();
        }

        // POST: Lista_Uslug/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,id_uzytkownik,id_usluga")] Lista_Uslug lista_Uslug)
        {
            if (ModelState.IsValid)
            {
                db.Lista_Uslug.Add(lista_Uslug);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_usluga = new SelectList(db.Usluga, "Id", "nazwa", lista_Uslug.id_usluga);
            ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie", lista_Uslug.id_uzytkownik);
            return View(lista_Uslug);
        }

        // GET: Lista_Uslug/Edit/5
        [Route("Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista_Uslug lista_Uslug = db.Lista_Uslug.Find(id);
            if (lista_Uslug == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_usluga = new SelectList(db.Usluga, "Id", "nazwa", lista_Uslug.id_usluga);
            ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie", lista_Uslug.id_uzytkownik);
            return View(lista_Uslug);
        }

        // POST: Lista_Uslug/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,id_uzytkownik,id_usluga")] Lista_Uslug lista_Uslug)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lista_Uslug).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_usluga = new SelectList(db.Usluga, "Id", "nazwa", lista_Uslug.id_usluga);
            ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie", lista_Uslug.id_uzytkownik);
            return View(lista_Uslug);
        }

        // GET: Lista_Uslug/Delete/5
        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista_Uslug lista_Uslug = db.Lista_Uslug.Find(id);
            if (lista_Uslug == null)
            {
                return HttpNotFound();
            }
            return View(lista_Uslug);
        }

        // POST: Lista_Uslug/Delete/5
        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lista_Uslug lista_Uslug = db.Lista_Uslug.Find(id);
            db.Lista_Uslug.Remove(lista_Uslug);
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
