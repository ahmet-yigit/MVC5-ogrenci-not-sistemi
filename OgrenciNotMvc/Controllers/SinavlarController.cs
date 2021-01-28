using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
using OgrenciNotMvc.Models;

namespace OgrenciNotMvc.Controllers
{
    public class SinavlarController : Controller
    {
        // GET: Sinavlar

        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var sinavlar = db.TBLNOTLAR.ToList();
            return View(sinavlar);
        }

        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSinav(TBLNOTLAR p)
        {
            db.TBLNOTLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SinavGetir(int id)
        {
            var not = db.TBLNOTLAR.Find(id);
            return View("SinavGetir", not);
        }
        [HttpPost]
        public ActionResult SinavGetir(TBLNOTLAR p, Class1 cls1, int Sinav1 = 0, int Sinav2 = 0, int Sinav3 = 0, int Proje = 0)
        {
            if (cls1.islem == "HESAPLA")
            {
                //işlem 1
                int ORTALAMA = (Sinav1 + Sinav2 + Sinav3 + Proje) / 4;
                ViewBag.ort = ORTALAMA;
            }
            if (cls1.islem == "NOTGUNCELLE")
            {
                //işlem 2
                var not = db.TBLNOTLAR.Find(p.NOTID);
                not.SINAV1 = p.SINAV1;
                not.SINAV2 = p.SINAV2;
                not.SINAV3 = p.SINAV3;
                not.PROJE = p.PROJE;
                not.ORTALAMA = p.ORTALAMA;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}