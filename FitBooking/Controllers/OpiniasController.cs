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
    [RoutePrefix("Opinia")]
    public class OpiniasController : Controller
    {
        private Entities3 db = new Entities3();

        // GET: Opinias
        [Route("")]
        public ActionResult Index()
        {
            return View(db.Opinia.ToList());
        }

        // GET: Opinias/Details/5
        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opinia opinia = db.Opinia.Find(id);
            if (opinia == null)
            {
                return HttpNotFound();
            }
            return View(opinia);
        }

        // GET: Opinias/Create
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Opinias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ocena,opis")] Opinia opinia)
        {
            if (ModelState.IsValid)
            {
                db.Opinia.Add(opinia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(opinia);
        }

        // GET: Opinias/Edit/5
        [Route("Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opinia opinia = db.Opinia.Find(id);
            if (opinia == null)
            {
                return HttpNotFound();
            }
            return View(opinia);
        }

        // POST: Opinias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ocena,opis")] Opinia opinia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opinia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opinia);
        }

        // GET: Opinias/Delete/5
        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opinia opinia = db.Opinia.Find(id);
            if (opinia == null)
            {
                return HttpNotFound();
            }
            return View(opinia);
        }

        // POST: Opinias/Delete/5
        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Opinia opinia = db.Opinia.Find(id);
            db.Opinia.Remove(opinia);
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
