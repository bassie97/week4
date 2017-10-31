using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Energieweb.Models;

namespace Energieweb.Controllers
{
    public class ApparaatController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Apparaat
        public ActionResult Index()
        {
            return View(db.Apparaats.ToList());
        }

        // GET: Apparaat/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apparaat apparaat = db.Apparaats.Find(id);
            if (apparaat == null)
            {
                return HttpNotFound();
            }
            return View(apparaat);
        }

        // GET: Apparaat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Apparaat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naam,Max,Merk,TypeFk")] Apparaat apparaat)
        {
            if (ModelState.IsValid)
            {
                db.Apparaats.Add(apparaat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(apparaat);
        }

        // GET: Apparaat/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apparaat apparaat = db.Apparaats.Find(id);
            if (apparaat == null)
            {
                return HttpNotFound();
            }
            return View(apparaat);
        }

        // POST: Apparaat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naam,Max,Merk,TypeFk")] Apparaat apparaat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apparaat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(apparaat);
        }

        // GET: Apparaat/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apparaat apparaat = db.Apparaats.Find(id);
            if (apparaat == null)
            {
                return HttpNotFound();
            }
            return View(apparaat);
        }

        // POST: Apparaat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Apparaat apparaat = db.Apparaats.Find(id);
            db.Apparaats.Remove(apparaat);
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
