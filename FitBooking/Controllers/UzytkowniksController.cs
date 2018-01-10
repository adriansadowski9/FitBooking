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
    [RoutePrefix("Uzytkownik")]
    public class UzytkowniksController : Controller
    {
        private Entities3 db = new Entities3();

        // GET: Uzytkowniks
        [Route("")]
        [Authorize(Roles = "administrator")]
        public ActionResult Index()
        {
            var uzytkownik = db.Uzytkownik.Include(u => u.AspNetUsers);
            return View(uzytkownik.ToList());
        }

        [Route("Details")]
        [Authorize(Roles = "administrator")] // GET: Uzytkowniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzytkownik uzytkownik = db.Uzytkownik.Find(id);
            if (uzytkownik == null)
            {
                return HttpNotFound();
            }
            return View(uzytkownik);
        }

        // GET: Uzytkowniks/Create
        [Route("Create")]
        public ActionResult Create()
        {
            //uzytkownik.id_aspUser = db.AspNetUsers.Find(Environment.UserName).Id;

           
            //var user = System.Web.HttpContext.Current.User.Identity.Name;
            //ViewBag.id_aspUser = db.AspNetUsers.Find(user).Id;

            return View();
        }

        // POST: Uzytkowniks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,imie,nazwisko,data_urodzenia,email,telefon")] Uzytkownik uzytkownik)
        {
            if (ModelState.IsValid)
            {
              
                var u = db.AspNetUsers.SingleOrDefault(x => x.Email == User.Identity.Name);
                Uzytkownik a = db.Uzytkownik.SingleOrDefault(x => x.id_aspUser == u.Id);
                if (a != null)
                {
                    return Redirect("/UzytkownikHome/Index");
                }
                else
                {
                    uzytkownik.id_aspUser = u.Id;
                    db.Uzytkownik.Add(uzytkownik);
                    db.SaveChanges();
                    return Redirect("/Adres/Create");
                }

               
            }

     
    
           

            return View(uzytkownik);
        }

        // GET: Uzytkowniks/Edit/5
        [Route("Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzytkownik uzytkownik = db.Uzytkownik.Find(id);
            if (uzytkownik == null)
            {
                return HttpNotFound();
            }
                  return View(uzytkownik);
        }

        // POST: Uzytkowniks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,imie,nazwisko,data_urodzenia,email,telefon")] Uzytkownik uzytkownik)
        {
            if (ModelState.IsValid)
            {
                var u = db.AspNetUsers.SingleOrDefault(x => x.Email == User.Identity.Name);
                uzytkownik.id_aspUser = u.Id;

                db.Entry(uzytkownik).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("/UzytkownikHome/Index");
            }
               return View(uzytkownik);
        }
        [Authorize(Roles = "administrator")]
        // GET: Uzytkowniks/Delete/5
        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzytkownik uzytkownik = db.Uzytkownik.Find(id);
            if (uzytkownik == null)
            {
                return HttpNotFound();
            }
            return View(uzytkownik);
        }

        // POST: Uzytkowniks/Delete/5
        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uzytkownik uzytkownik = db.Uzytkownik.Find(id);
            db.Uzytkownik.Remove(uzytkownik);
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
