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
    public class PracownikController : Controller
    {
        private AgencjaContext db = new AgencjaContext();

        // GET: Pracownik
        public ActionResult Index()
        {
            return View(db.Pracownicy.ToList());
        }

        public ActionResult OrderByNazwisko()
        {
            var pracownicy = from p in db.Pracownicy
                           orderby p.Nazwisko ascending
                           select p;
            return View(pracownicy);
        }

        public ActionResult OrderByPesel()
        {
            var pracownicy = from p in db.Pracownicy
                             orderby p.Nazwisko ascending
                             select p;
            return View(pracownicy);
        }


        // GET: Pracownik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownik pracownik = db.Pracownicy.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            return View(pracownik);
        }

        // GET: Pracownik/Create
        [AuthLog(Roles = "Pracownik")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pracownik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Imie,Nazwisko,Plec,Stanowisko,Pesel")] Pracownik pracownik)
        {
            if (ModelState.IsValid)
            {
                db.Pracownicy.Add(pracownik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pracownik);
        }

        // GET: Pracownik/Edit/5
        [AuthLog(Roles = "Pracownik")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownik pracownik = db.Pracownicy.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            return View(pracownik);
        }

        // POST: Pracownik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Imie,Nazwisko,Plec,Stanowisko,Pesel")] Pracownik pracownik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pracownik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pracownik);
        }

        // GET: Pracownik/Delete/5
        [AuthLog(Roles = "Pracownik")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pracownik pracownik = db.Pracownicy.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            return View(pracownik);
        }

        // POST: Pracownik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pracownik pracownik = db.Pracownicy.Find(id);
            db.Pracownicy.Remove(pracownik);
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
