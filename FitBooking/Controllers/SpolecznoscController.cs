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
    [RoutePrefix("Spolecznosc")]
    public class SpolecznoscController : Controller
    {
        private Entities3 db = new Entities3();

        // GET: Spolecznoscs
        [Route("")]
       // [Authorize(Roles = "administrator")]
        public ActionResult Index()
        {
            var spolecznosc = db.Spolecznosc.Include(s => s.Uzytkownik);
            return View(spolecznosc.ToList());
        }

        // GET: Spolecznoscs/Details/5
        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spolecznosc spolecznosc = db.Spolecznosc.Find(id);
            if (spolecznosc == null)
            {
                return HttpNotFound();
            }
            return View(spolecznosc);
        }

        // GET: Spolecznoscs/Create
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie");
            return View();
        }

        // POST: Spolecznoscs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,facebook,instagram,snapchat,twitter,id_uzytkownik")] Spolecznosc spolecznosc)
        {
            if (ModelState.IsValid)
            {
                var u = db.AspNetUsers.SingleOrDefault(x => x.Email == User.Identity.Name);
                Uzytkownik p = db.Uzytkownik.SingleOrDefault(x => x.id_aspUser == u.Id);
                Spolecznosc a = db.Spolecznosc.SingleOrDefault(x => x.id_uzytkownik == p.Id);
                if (a != null)
                {
                    return Redirect("/UzytkownikHome/Index");
                }
                else { 
                spolecznosc.id_uzytkownik = p.Id;
                db.Spolecznosc.Add(spolecznosc);
                db.SaveChanges();
                return Redirect("/UzytkownikHome/Index");
                }
            }

          //  ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie", spolecznosc.id_uzytkownik);
            return View(spolecznosc);
        }

        // GET: Spolecznoscs/Edit/5
        [Route("Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spolecznosc spolecznosc = db.Spolecznosc.Find(id);
            if (spolecznosc == null)
            {
                return Redirect("/UzytkownikHome/Index");
            }
           // ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie", spolecznosc.id_uzytkownik);
            return View(spolecznosc);
        }

        // POST: Spolecznoscs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,facebook,instagram,snapchat,twitter,id_uzytkownik")] Spolecznosc spolecznosc)
        {
            if (ModelState.IsValid)
            {
                var u = db.AspNetUsers.SingleOrDefault(x => x.Email == User.Identity.Name);
                Uzytkownik p = db.Uzytkownik.SingleOrDefault(x => x.id_aspUser == u.Id);
                spolecznosc.id_uzytkownik = p.Id;

                db.Entry(spolecznosc).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("/UzytkownikHome/Index");
            }
           // ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie", spolecznosc.id_uzytkownik);
            return View(spolecznosc);
        }

        // GET: Spolecznoscs/Delete/5
        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spolecznosc spolecznosc = db.Spolecznosc.Find(id);
            if (spolecznosc == null)
            {
                return Redirect("/UzytkownikHome/Index");
            }
            return View(spolecznosc);
        }

        // POST: Spolecznoscs/Delete/5
        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Spolecznosc spolecznosc = db.Spolecznosc.Find(id);
            db.Spolecznosc.Remove(spolecznosc);
            db.SaveChanges();
            return Redirect("/UzytkownikHome/Index");
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
