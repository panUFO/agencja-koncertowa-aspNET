using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using agencja.DAL;
using agencja.Models;
using agencja.CustomFilters;

namespace agencja.Controllers
{
    public class KlubController : Controller
    {
        private AgencjaContext db = new AgencjaContext();

        // GET: Klub
       public ActionResult Index()
        {
            return View(db.Kluby.ToList());
        }


        /*
               public ActionResult Index(string sortOrder)
               {
                   ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                   ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "miasto_desc" : "";

                   var kluby = from k in db.Kluby
                                  select k;
                   switch (sortOrder)
                   {
                       case "name_desc":
                           kluby = kluby.OrderByDescending(k => k.Nazwa);
                           break;
                       case "miasto":
                           kluby = kluby.OrderBy(k => k.Miasto);
                           break;
                       case "miasto_desc":
                           kluby = kluby.OrderByDescending(k => k.Miasto);
                           break;
                       default:
                           kluby = kluby.OrderBy(k => k.Nazwa);
                           break;
                   }
                   return View(db.Kluby.ToList());
               }

       */




        public ActionResult OrderByNazwa()
        {
            var kluby = from k in db.Kluby
                           orderby k.Nazwa ascending
                           select k;
            return View(kluby);
        }

        public ActionResult OrderByMiasto()
        {
            var kluby = from k in db.Kluby
                        orderby k.Miasto ascending
                        select k;
            return View(kluby);
        }



        // GET: Klub/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klub klub = db.Kluby.Find(id);
            if (klub == null)
            {
                return HttpNotFound();
            }
            return View(klub);
        }

        // GET: Klub/Create
        [AuthLog(Roles = "Pracownik")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Klub/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nazwa,Miasto,Ilosc_miejsc")] Klub klub)
        {
            if (ModelState.IsValid)
            {
                db.Kluby.Add(klub);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(klub);
        }


        // GET: Klub/Edit/5
        [AuthLog(Roles = "Pracownik")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klub klub = db.Kluby.Find(id);
            if (klub == null)
            {
                return HttpNotFound();
            }
            return View(klub);
        }

        // POST: Klub/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nazwa,Miasto,Ilosc_miejsc")] Klub klub)
        {
            if (ModelState.IsValid)
            {
                db.Entry(klub).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(klub);
        }

        // GET: Klub/Delete/5
        [AuthLog(Roles = "Pracownik")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klub klub = db.Kluby.Find(id);
            if (klub == null)
            {
                return HttpNotFound();
            }
            return View(klub);
        }

        // POST: Klub/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Klub klub = db.Kluby.Find(id);
            db.Kluby.Remove(klub);
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
