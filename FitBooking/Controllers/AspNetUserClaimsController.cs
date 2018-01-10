using FitBooking.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FitBooking.Controllers
{
    [RoutePrefix("Claim")]
    [Authorize(Roles = "administrator")]
    public class AspNetUserClaimsController : Controller
    {
        private Entities3 db = new Entities3();

        // GET: AspNetUserClaims
        [Route("")]
        public ActionResult Index()
        {
            var aspNetUserClaims = db.AspNetUserClaims.Include(a => a.AspNetUsers);
            return View(aspNetUserClaims.ToList());
        }

        // GET: AspNetUserClaims/Details/5
        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserClaims aspNetUserClaims = db.AspNetUserClaims.Find(id);
            if (aspNetUserClaims == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUserClaims);
        }

        // GET: AspNetUserClaims/Create
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: AspNetUserClaims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,ClaimType,ClaimValue")] AspNetUserClaims aspNetUserClaims)
        {
            if (ModelState.IsValid)
            {
                db.AspNetUserClaims.Add(aspNetUserClaims);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", aspNetUserClaims.UserId);
            return View(aspNetUserClaims);
        }

        // GET: AspNetUserClaims/Edit/5
        [Route("Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserClaims aspNetUserClaims = db.AspNetUserClaims.Find(id);
            if (aspNetUserClaims == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", aspNetUserClaims.UserId);
            return View(aspNetUserClaims);
        }

        // POST: AspNetUserClaims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,ClaimType,ClaimValue")] AspNetUserClaims aspNetUserClaims)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspNetUserClaims).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", aspNetUserClaims.UserId);
            return View(aspNetUserClaims);
        }

        // GET: AspNetUserClaims/Delete/5
        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUserClaims aspNetUserClaims = db.AspNetUserClaims.Find(id);
            if (aspNetUserClaims == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUserClaims);
        }

        // POST: AspNetUserClaims/Delete/5
        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AspNetUserClaims aspNetUserClaims = db.AspNetUserClaims.Find(id);
            db.AspNetUserClaims.Remove(aspNetUserClaims);
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
