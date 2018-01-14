using FitBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FitBooking.Controllers
{
    [RoutePrefix("All")]
    public class TrenerzyController : Controller
    {
        private Entities3 db = new Entities3();
        private ApplicationDbContext db1 = new ApplicationDbContext();

        // GET: Trenerzy 
        //  [Authorize(Roles = "administrator")]
        [Route("")]
        public ActionResult Index()
        {
            var listOfUsers = (from u in db1.Users
                               let query = (from ur in db1.Set<IdentityUserRole>()
                                            where ur.UserId.Equals(u.Id)
                                            join r in db1.Roles on ur.RoleId equals r.Id
                                            select r.Name)
                               select new UserRoleInfo() { User = u, Roles = query.ToList<string>() })
                         .ToList();

            var trenerzy = listOfUsers.Where(x => x.Roles.ElementAtOrDefault(0) == "trener").ToList();
            var dietetycy = listOfUsers.Where(x => x.Roles.ElementAtOrDefault(0) == "dietetyk").ToList();

            List<Uzytkownik> listaTrener = new List<Uzytkownik>();

            List<Uzytkownik> listaDietetyk = new List<Uzytkownik>();
            List<ModelUserProfil> listaM= new List<ModelUserProfil>();
            
            foreach (UserRoleInfo user in listOfUsers)
            {
                if (user.Roles.FirstOrDefault() != "administrator" && user.Roles.FirstOrDefault() != "klient")
                {

                    Uzytkownik t = db.Uzytkownik.SingleOrDefault(k => k.id_aspUser == user.User.Id);
                    if (t != null)
                    {
                        ModelUserProfil m = new ModelUserProfil();
                        m.user = t;
                        m.rola = user.Roles.ElementAtOrDefault(0);
                        listaM.Add(m);
                    }
                }
            }

            return View(listaM); 
        }

  

        // GET: Trenerzy/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Trenerzy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trenerzy/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Trenerzy/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Trenerzy/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Trenerzy/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Trenerzy/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
