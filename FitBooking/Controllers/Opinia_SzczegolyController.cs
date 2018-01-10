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
    [RoutePrefix("OpiniaSzczegoly")]
    public class Opinia_SzczegolyController : Controller
    {
        private Entities3 db = new Entities3();

        // GET: Opinia_Szczegoly
        [Route("")]
        public ActionResult Index()
        {
            var opinia_Szczegoly = db.Opinia_Szczegoly.Include(o => o.Opinia).Include(o => o.Uzytkownik);
            return View(opinia_Szczegoly.ToList());
        }

        // GET: Opinia_Szczegoly/Details/5
        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opinia_Szczegoly opinia_Szczegoly = db.Opinia_Szczegoly.Find(id);
            if (opinia_Szczegoly == null)
            {
                return HttpNotFound();
            }
            return View(opinia_Szczegoly);
        }

        // GET: Opinia_Szczegoly/Create
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.id_opinia = new SelectList(db.Opinia, "Id", "opis");
            ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie");
            return View();
        }

        // POST: Opinia_Szczegoly/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,data,id_opinia,id_uzytkownik")] Opinia_Szczegoly opinia_Szczegoly)
        {
            if (ModelState.IsValid)
            {
                db.Opinia_Szczegoly.Add(opinia_Szczegoly);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_opinia = new SelectList(db.Opinia, "Id", "opis", opinia_Szczegoly.id_opinia);
            ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie", opinia_Szczegoly.id_uzytkownik);
            return View(opinia_Szczegoly);
        }

        // GET: Opinia_Szczegoly/Edit/5
        [Route("Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opinia_Szczegoly opinia_Szczegoly = db.Opinia_Szczegoly.Find(id);
            if (opinia_Szczegoly == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_opinia = new SelectList(db.Opinia, "Id", "opis", opinia_Szczegoly.id_opinia);
            ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie", opinia_Szczegoly.id_uzytkownik);
            return View(opinia_Szczegoly);
        }

        // POST: Opinia_Szczegoly/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,data,id_opinia,id_uzytkownik")] Opinia_Szczegoly opinia_Szczegoly)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opinia_Szczegoly).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_opinia = new SelectList(db.Opinia, "Id", "opis", opinia_Szczegoly.id_opinia);
            ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie", opinia_Szczegoly.id_uzytkownik);
            return View(opinia_Szczegoly);
        }

        // GET: Opinia_Szczegoly/Delete/5
        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opinia_Szczegoly opinia_Szczegoly = db.Opinia_Szczegoly.Find(id);
            if (opinia_Szczegoly == null)
            {
                return HttpNotFound();
            }
            return View(opinia_Szczegoly);
        }

        // POST: Opinia_Szczegoly/Delete/5
        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Opinia_Szczegoly opinia_Szczegoly = db.Opinia_Szczegoly.Find(id);
            db.Opinia_Szczegoly.Remove(opinia_Szczegoly);
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
