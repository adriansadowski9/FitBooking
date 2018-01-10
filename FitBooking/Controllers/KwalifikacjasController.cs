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
    [RoutePrefix("Kwalifikacja")]
    public class KwalifikacjasController : Controller
    {
        private Entities3 db = new Entities3();

        // GET: Kwalifikacjas
        [Route("")]
        public ActionResult Index()
        {
            return View(db.Kwalifikacja.ToList());
        }

        // GET: Kwalifikacjas/Details/5
        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kwalifikacja kwalifikacja = db.Kwalifikacja.Find(id);
            if (kwalifikacja == null)
            {
                return HttpNotFound();
            }
            return View(kwalifikacja);
        }

        // GET: Kwalifikacjas/Create
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kwalifikacjas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nazwa,opis")] Kwalifikacja kwalifikacja)
        {
            if (ModelState.IsValid)
            {
                db.Kwalifikacja.Add(kwalifikacja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kwalifikacja);
        }

        // GET: Kwalifikacjas/Edit/5
        [Route("Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kwalifikacja kwalifikacja = db.Kwalifikacja.Find(id);
            if (kwalifikacja == null)
            {
                return HttpNotFound();
            }
            return View(kwalifikacja);
        }

        // POST: Kwalifikacjas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nazwa,opis")] Kwalifikacja kwalifikacja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kwalifikacja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kwalifikacja);
        }

        // GET: Kwalifikacjas/Delete/5
        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kwalifikacja kwalifikacja = db.Kwalifikacja.Find(id);
            if (kwalifikacja == null)
            {
                return HttpNotFound();
            }
            return View(kwalifikacja);
        }

        // POST: Kwalifikacjas/Delete/5
        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kwalifikacja kwalifikacja = db.Kwalifikacja.Find(id);
            db.Kwalifikacja.Remove(kwalifikacja);
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
