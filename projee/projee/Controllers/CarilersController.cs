using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using projee.Models;

namespace projee.Controllers
{
    
    public class CarilersController : Controller
    {
        private CariEntities db = new CariEntities();

        // GET: Carilers
       public ActionResult Index()
        {
            return View(db.Cariler.ToList());
        }
      

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cariler cariler = db.Cariler.Find(id);
            if (cariler == null)
            {
                return HttpNotFound();
            }
            return View(cariler);
        }

        // GET: Carilers/Create
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Carid,CDate,Carikod,Cariad,Adres,Telefon,Vergikimlik,Silindimi")] Cariler cariler)
        {
            if (ModelState.IsValid)
            {
                db.Cariler.Add(cariler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cariler);
        }

        // GET: Carilers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cariler cariler = db.Cariler.Find(id);
            if (cariler == null)
            {
                return HttpNotFound();
            }
            return View(cariler);

        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Carid,CDate,Carikod,Cariad,Adres,Telefon,Vergikimlik,Silindimi")] Cariler cariler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cariler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cariler);
        }

        // GET: Carilers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cariler cariler = db.Cariler.Find(id);
            if (cariler == null)
            {
                return HttpNotFound();
            }
            return View(cariler);
        }

        // POST: Carilers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cariler cariler = db.Cariler.Find(id);
            db.Cariler.Remove(cariler);
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
