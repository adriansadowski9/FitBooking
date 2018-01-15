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
    [Authorize(Roles = "administrator")]
    public class SpotkaniesController : Controller
    {
        private Entities3 db = new Entities3();

        // GET: Spotkanies      
       
        public ActionResult Index()
        {
            return View(db.Spotkanie.ToList());
        }

        // GET: Spotkanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spotkanie spotkanie = db.Spotkanie.Find(id);
            if (spotkanie == null)
            {
                return HttpNotFound();
            }
            return View(spotkanie);
        }

        // GET: Spotkanies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Spotkanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,opis,data_start,data_koniec,color")] Spotkanie spotkanie)
        {
            if (ModelState.IsValid)
            {
                db.Spotkanie.Add(spotkanie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(spotkanie);
        }

        // GET: Spotkanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spotkanie spotkanie = db.Spotkanie.Find(id);
            if (spotkanie == null)
            {
                return HttpNotFound();
            }
            return View(spotkanie);
        }

        // POST: Spotkanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,opis,data_start,data_koniec,color")] Spotkanie spotkanie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spotkanie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(spotkanie);
        }

        // GET: Spotkanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spotkanie spotkanie = db.Spotkanie.Find(id);
            if (spotkanie == null)
            {
                return HttpNotFound();
            }
            return View(spotkanie);
        }

        // POST: Spotkanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Spotkanie spotkanie = db.Spotkanie.Find(id);
            db.Spotkanie.Remove(spotkanie);
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
