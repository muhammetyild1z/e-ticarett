using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projee.Models;
namespace projee.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Stok_List()
        {
            CariEntities db = new CariEntities();
            var Urunliste = db.Stok.ToList();
            return Json(Urunliste);
        }
    }
}