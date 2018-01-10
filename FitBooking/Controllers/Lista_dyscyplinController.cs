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
    [RoutePrefix("ListaDyscyplin")]
    public class Lista_dyscyplinController : Controller
    {
        private Entities3 db = new Entities3();

        // GET: Lista_dyscyplin
        [Route("")]
        public ActionResult Index()
        {
            var lista_dyscyplin = db.Lista_dyscyplin.Include(l => l.Dyscyplina).Include(l => l.Uzytkownik);
            return View(lista_dyscyplin.ToList());
        }

        // GET: Lista_dyscyplin/Details/5
        [Route("Details")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista_dyscyplin lista_dyscyplin = db.Lista_dyscyplin.Find(id);
            if (lista_dyscyplin == null)
            {
                return HttpNotFound();
            }
            return View(lista_dyscyplin);
        }

        // GET: Lista_dyscyplin/Create
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.id_dyscyplina = new SelectList(db.Dyscyplina, "Id", "nazwa");
            ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie");
            Dyscyplina dyscyplinal = new Dyscyplina();
            Lista_dyscyplin h = new Lista_dyscyplin();
            h.Dyscypliny = db.Dyscyplina.ToList<Dyscyplina>();


            return View(h);

        }

        // POST: Lista_dyscyplin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Lista_dyscyplin lista_dyscyplin)
        {
            if (ModelState.IsValid)
            {
                var selectDyscyplina = lista_dyscyplin.Dyscypliny.Where(x => x.IsChecked == true).ToList();
                for (int i = 0; i < selectDyscyplina.Count; i++)
                {
                    lista_dyscyplin.id_dyscyplina = selectDyscyplina[i].Id;

                    db.Lista_dyscyplin.Add(lista_dyscyplin);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            ViewBag.id_dyscyplina = new SelectList(db.Dyscyplina, "Id", "nazwa", lista_dyscyplin.id_dyscyplina);
            ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie", lista_dyscyplin.id_uzytkownik);
            return View(lista_dyscyplin);
        }

        // GET: Lista_dyscyplin/Edit/5
        [Route("Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista_dyscyplin lista_dyscyplin = db.Lista_dyscyplin.Find(id);
            if (lista_dyscyplin == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_dyscyplina = new SelectList(db.Dyscyplina, "Id", "nazwa", lista_dyscyplin.id_dyscyplina);
            ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie", lista_dyscyplin.id_uzytkownik);
            return View(lista_dyscyplin);
        }

        // POST: Lista_dyscyplin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,id_uzytkownik,id_dyscyplina")] Lista_dyscyplin lista_dyscyplin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lista_dyscyplin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_dyscyplina = new SelectList(db.Dyscyplina, "Id", "nazwa", lista_dyscyplin.id_dyscyplina);
            ViewBag.id_uzytkownik = new SelectList(db.Uzytkownik, "Id", "imie", lista_dyscyplin.id_uzytkownik);
            return View(lista_dyscyplin);
        }

        // GET: Lista_dyscyplin/Delete/5
        [Route("Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista_dyscyplin lista_dyscyplin = db.Lista_dyscyplin.Find(id);
            if (lista_dyscyplin == null)
            {
                return HttpNotFound();
            }
            return View(lista_dyscyplin);
        }

        // POST: Lista_dyscyplin/Delete/5
        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lista_dyscyplin lista_dyscyplin = db.Lista_dyscyplin.Find(id);
            db.Lista_dyscyplin.Remove(lista_dyscyplin);
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
