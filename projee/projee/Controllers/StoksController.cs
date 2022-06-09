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

    
    public class StoksController : Controller
    {
        private CariEntities db = new CariEntities();

        // GET: Stoks
        public ActionResult Index()
        {
            return View(db.Stok.ToList());
        }

        // GET: Stoks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stok stok = db.Stok.Find(id);
            if (stok == null)
            {
                return HttpNotFound();
            }
            return View(stok);
        }

        // GET: Stoks/Create
        public ActionResult Create()
        {
            return View();
        }      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Stokid,CDate,Stokkodu,Stokadi,Silindimi,Resim,Fiyat")] Stok stok)
        {
            if (ModelState.IsValid)
            {
                stok.CDate = DateTime.Now;
                db.Stok.Add(stok);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stok);
        }

        // GET: Stoks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stok stok = db.Stok.Find(id);
            if (stok == null)
            {                
                return HttpNotFound();
            }
            return View(stok);
        }       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Stokid,CDate,Stokkodu,Stokadi,Silindimi")] Stok stok)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stok).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stok);
        }

        // GET: Stoks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stok stok = db.Stok.Find(id);
            if (stok == null)
            {
                return HttpNotFound();
            }
            return View(stok);
        }       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stok stok = db.Stok.Find(id);
            db.Stok.Remove(stok);
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
