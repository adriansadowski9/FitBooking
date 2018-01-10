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
    [RoutePrefix("Dyscyplina")]
    public class DyscyplinasController : Controller
    {
        private Entities3 db = new Entities3();

        // GET: Dyscyplinas
        [Route("")]
        public ActionResult Index()
        {
            return View(db.Dyscyplina.ToList());
        }

        // GET: Dyscyplinas/Details/5
        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dyscyplina dyscyplina = db.Dyscyplina.Find(id);
            if (dyscyplina == null)
            {
                return HttpNotFound();
            }
            return View(dyscyplina);
        }

        // GET: Dyscyplinas/Create
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dyscyplinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nazwa,opis")] Dyscyplina dyscyplina)
        {
            if (ModelState.IsValid)
            {
                db.Dyscyplina.Add(dyscyplina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dyscyplina);
        }

        // GET: Dyscyplinas/Edit/5
        [Route("Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dyscyplina dyscyplina = db.Dyscyplina.Find(id);
            if (dyscyplina == null)
            {
                return HttpNotFound();
            }
            return View(dyscyplina);
        }

        // POST: Dyscyplinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nazwa,opis")] Dyscyplina dyscyplina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dyscyplina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dyscyplina);
        }

        // GET: Dyscyplinas/Delete/5
        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dyscyplina dyscyplina = db.Dyscyplina.Find(id);
            if (dyscyplina == null)
            {
                return HttpNotFound();
            }
            return View(dyscyplina);
        }

        // POST: Dyscyplinas/Delete/5
        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dyscyplina dyscyplina = db.Dyscyplina.Find(id);
            db.Dyscyplina.Remove(dyscyplina);
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
