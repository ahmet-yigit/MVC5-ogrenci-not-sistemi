using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMvc.Controllers
{
    public class HesapTestController : Controller
    {
        // GET: HesapTest
        public ActionResult Index(int sayi1=0, int sayi2=0)
        {
            int sonuc = sayi1 + sayi2;
            ViewBag.snc = sonuc;
            return View();
        }
        public ActionResult DortIslem(int sayi1 = 0, int sayi2 = 0)
        {
            int toplam = sayi1 + sayi2;
            ViewBag.snc1 = toplam;
            int cikarma = sayi1 - sayi2;
            ViewBag.snc2 = cikarma;
            int bolme = sayi1 + sayi2;
            ViewBag.snc3 = bolme;
            int carpma = sayi1 * sayi2;
            ViewBag.snc4 = carpma;
            return View();
        }
    }
}