using projee.Models;
using System;
using System.Linq;
using System.Web.Mvc;
namespace projee.Controllers
{
    public class SepetController : Controller
    {
        private CariEntities db = new CariEntities();

        // GET: Sepet
        public ActionResult List()
        {
            var model = db.Sepet.ToArray();
            
          
            return View(model);
        }                

        [HttpPost]
        public JsonResult Sepeteekle(Sepet sepet)
        {
            
            using (var ctx=new CariEntities())
            {
                ctx.Configuration.LazyLoadingEnabled = false;                       
                try
                {
                    ctx.Sepet.Add(sepet);
                    ctx.SaveChanges();
                    return Json("OK");
                   
                }
                catch (Exception ex)
                {
                    return Json("FAIL");
                }
            }

        }


        
        public ActionResult delete(int id)
        {
            var sil = db.Sepet.Find(id);
            db.Sepet.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("List");
        }

       //public ActionResult edit(int id)
       //{
       //    Sepet model = new Sepet();
       //    model = db.Sepet.Find(id);
       //    return View(model);
       //}
        [HttpPost]
        public JsonResult edit(Sepet sepet  )
        {
            Sepet edt = db.Sepet.Where(x=> x.SPT_ID== sepet.SPT_ID).FirstOrDefault();
            edt.MIKTAR = sepet.MIKTAR;
            db.SaveChanges();
            return Json("OK");
        }
    }

}