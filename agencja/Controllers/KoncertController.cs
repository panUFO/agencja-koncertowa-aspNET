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
    public class KoncertController : Controller
    {
        private AgencjaContext db = new AgencjaContext();

        // GET: Koncert
        public ActionResult Index()
        {
            var koncerty = db.Koncerty.Include(k => k.Klub);
            return View(db.Koncerty.ToList());
        }


        public ActionResult OrderByNazwa()
        {
            var koncerty = from k in db.Koncerty
                        orderby k.Nazwa ascending
                        select k;
            return View(koncerty);
        }

        public ActionResult OrderByCena()
        {
            var koncerty = from k in db.Koncerty
                           orderby k.cena_biletu ascending
                           select k;
            return View(koncerty);
        }


        // GET: Koncert/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Koncert koncert = db.Koncerty.Find(id);
            if (koncert == null)
            {
                return HttpNotFound();
            }
            return View(koncert);
        }

        // GET: Koncert/Create
        [AuthLog(Roles = "Pracownik")]
        public ActionResult Create()
        {
            ViewBag.KlubID = new SelectList(db.Kluby, "ID", "Nazwa");
            return View();
        }

        // POST: Koncert/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDKlub,Nazwa,cena_biletu")] Koncert koncert)
        {
            if (ModelState.IsValid)
            {
                db.Koncerty.Add(koncert);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KlubID = new SelectList(db.Kluby, "ID", "Nazwa", koncert.IDKlub);
            return View(koncert);
        }

        // GET: Koncert/Edit/5
        [AuthLog(Roles = "Pracownik")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Koncert koncert = db.Koncerty.Find(id);
            if (koncert == null)
            {
                return HttpNotFound();
            }
            ViewBag.KlubID = new SelectList(db.Kluby, "ID", "Nazwa", koncert.IDKlub);
            return View(koncert);
        }

        // POST: Koncert/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDKlub,Nazwa,cena_biletu")] Koncert koncert)
        {
            if (ModelState.IsValid)
            {
                db.Entry(koncert).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KlubID = new SelectList(db.Kluby, "ID", "Nazwa", koncert.IDKlub);
            return View(koncert);
        }

        // GET: Koncert/Delete/5
        [AuthLog(Roles = "Pracownik")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Koncert koncert = db.Koncerty.Find(id);
            if (koncert == null)
            {
                return HttpNotFound();
            }
            return View(koncert);
        }

        // POST: Koncert/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Koncert koncert = db.Koncerty.Find(id);
            db.Koncerty.Remove(koncert);
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
