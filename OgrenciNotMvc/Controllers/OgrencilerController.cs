using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class OgrencilerController : Controller
    {
        // GET: Ogrenciler
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var ogrenciler = db.TBLOGRENCILER.ToList();
            return View(ogrenciler);
        }

        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.TLBKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }
                                           ).ToList();
            ViewBag.dgr = degerler;

            return View();
        }

        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCILER p)
        {
            var klp = db.TLBKULUPLER.Where(m => m.KULUPID == p.TLBKULUPLER.KULUPID).FirstOrDefault();
            p.TLBKULUPLER = klp;
            db.TBLOGRENCILER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ogrSil = db.TBLOGRENCILER.Find(id);
            db.TBLOGRENCILER.Remove(ogrSil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OgrenciGetir(int id)
        {
            var ogr = db.TBLOGRENCILER.Find(id);

            List<SelectListItem> degerler = (from i in db.TLBKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }
                                           ).ToList();
            ViewBag.dgr = degerler;

            return View("OgrenciGetir", ogr);
        }

        public ActionResult Güncelle(TBLOGRENCILER p)
        {
            var ogr = db.TBLOGRENCILER.Find(p.OGRRENCIID);
            ogr.OGRAD = p.OGRAD;
            ogr.OGRSOYAD = p.OGRSOYAD;
            ogr.OGRFOTO = p.OGRFOTO;
            ogr.OGRCINSIYET = p.OGRCINSIYET;
            ogr.OGRKULUP = p.OGRKULUP;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        //[HttpGet]
        //public ActionResult YeniOgrenci()
        //{
        //    List<SelectListItem> items = new List<SelectListItem>();

        //    items.Add(new SelectListItem { Text = "Matematik", Value = "0" });

        //    items.Add(new SelectListItem { Text = "Fen Bİlgisi", Value = "1" });

        //    items.Add(new SelectListItem { Text = "Türkçe", Value = "2" });

        //    items.Add(new SelectListItem { Text = "Beden eğitimi", Value = "3" });
        //    items.Add(new SelectListItem { Text = "Beden ", Value = "4" });

        //    ViewBag.dersad = items;

        //    return View();
        //}
    }
}