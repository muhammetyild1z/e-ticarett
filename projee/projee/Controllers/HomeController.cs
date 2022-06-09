using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using projee.Models;

namespace projee.Controllers
{

    public class HomeController : Controller
    {
        private CariEntities db = new CariEntities();
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult sepet()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(Kullanicilar ctx)
        {
            var model = db.Kullanicilar.FirstOrDefault(x => x.kullanıcı_adi == ctx.kullanıcı_adi && x.Sifre == ctx.Sifre);
            if (model != null)
            {
                
                FormsAuthentication.SetAuthCookie(ctx.kullanıcı_adi, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.hata = "Kullanıcı adı veya şifre hatalı..";
                return View();
            }
        }
        public ActionResult Anasayfa()
        {
            return View();
        }
        public ActionResult login1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login1( Musteri dbx)
        {
            var model = db.Musteri.FirstOrDefault(x => x.Musteri_adi == dbx.Musteri_adi && x.Musteri_sifresi == dbx.Musteri_sifresi);
            if (model != null)
            {
                FormsAuthentication.SetAuthCookie(dbx.Musteri_adi, false);
                return RedirectToAction("Index", "Kullanici");
            }
            else
            {
                ViewBag.hata1 = "Kullanıcı adı veya şifre hatalı..";
             
                return View();
            }
           
        }
        public ActionResult register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult register(FormCollection form)
        {
            CariEntities db = new CariEntities();
            Musteri model = new Musteri();
            model.Musteri_adi = form["ad"];
            model.Musteri_eposta = form["mail"];
            model.Musteri_sifresi = form["sifre"];
            model.yetki = "M";
            model.Mdate = DateTime.Now;
            var count = db.Musteri.Where(z => z.Musteri_eposta == model.Musteri_eposta).Count();
            if (count > 0)
            {
                ViewBag.hata = "Bu e-posta daha önce kaydedilmiştir.";
                return View();
            }
            else
            {
                if (form["sifre"] == form["sifre1"])
                {
                    db.Musteri.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Kullanici");
                }
                else
                {
                    ViewBag.sifre = "Şifreler uyuşmuyor";
                    return RedirectToAction("login1", "Home");
                }
            }
        }
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login1","Home");
        }

    }
}