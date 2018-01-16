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
    [RoutePrefix("Info")]
    public class InfoesController : Controller
    {
        private Entities3 db = new Entities3();

        // GET: Infoes
        [Authorize(Roles = "administrator")]
        [Route("")]
        [Authorize(Roles = "administrator")]
        public ActionResult Index()
        {
            var info = db.Info.Include(i => i.Uzytkownik);
            return View(info.ToList());
        }

        // GET: Infoes/Details/5
        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Info info = db.Info.Find(id);
            if (info == null)
            {
                return HttpNotFound();
            }
            return View(info);
        }

        // GET: Infoes/Create
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie");
            return View();
        }

        // POST: Infoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,oMnie,id_uzytkownik")] Info info)
        {
            if (ModelState.IsValid)
            {
                var u = db.AspNetUsers.SingleOrDefault(x => x.Email == User.Identity.Name);
                Uzytkownik p = db.Uzytkownik.SingleOrDefault(x => x.id_aspUser == u.Id);
                Info a = db.Info.SingleOrDefault(x => x.id_uzytkownik == p.Id);
                if (a != null)
                {
                    return Redirect("/UzytkownikHome/Index");
                }
                else
                {
                    info.id_uzytkownik = p.Id; 
                    db.Info.Add(info);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie", info.id_uzytkownik);
            return View(info);
        }

        // GET: Infoes/Edit/5
        [Route("Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Info info = db.Info.Find(id);
            if (info == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie", info.id_uzytkownik);
            return View(info);
        }

        // POST: Infoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,oMnie")] Info info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           // ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie", info.id_uzytkownik);
            return View(info);
        }

        // GET: Infoes/Delete/5
        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Info info = db.Info.Find(id);
            if (info == null)
            {
                return HttpNotFound();
            }
            return View(info);
        }

        // POST: Infoes/Delete/5
        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Info info = db.Info.Find(id);
            db.Info.Remove(info);
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
