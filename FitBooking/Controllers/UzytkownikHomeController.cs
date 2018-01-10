using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FitBooking.Models;

namespace FitBooking.Controllers
{
    public class UzytkownikHomeController : Controller
    {
        private Entities3 db = new Entities3();

        // GET: UzytkowkiHome
        public ActionResult Index()
        {
            ModelUserProfil p = new ModelUserProfil();
            Uzytkownik u = new Uzytkownik();
            try
            {

                var uzytkownikID = db.AspNetUsers.SingleOrDefault(x => x.Email == User.Identity.Name);
                u = db.Uzytkownik.SingleOrDefault(m => m.id_aspUser == uzytkownikID.Id);
                p.user = u;
                p.adres = db.Adres.SingleOrDefault(n => n.id_uzytkownik == u.Id);
                p.spolecznosc = db.Spolecznosc.SingleOrDefault(n => n.id_uzytkownik == u.Id);


                return View(p);
            }
            catch
            {
                return RedirectToAction("Create", "Uzytkowniks", new { area = "" });
            }
        }
    }
}