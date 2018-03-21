using KarayelTasarimEticaret2016.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KarayelTasarimEticaret2016.Controllers
{
    public class HomeController : Controller
    {
        private Eticaret2016Entities db = new Eticaret2016Entities();

        public ActionResult Index()
        {
            ViewBag.KategoriListesi = db.Kategorilers.ToList();
            ViewBag.SonUrunler = db.Urunlers.OrderByDescending(a=>a.UrunID).Skip(0).Take(12).ToList();
            return View();
        }

        public ActionResult Kategori(int id)
        {
            ViewBag.KategoriListesi = db.Kategorilers.ToList();
            ViewBag.Kategori = db.Kategorilers.Find(id);
            return View(db.Urunlers.Where(a=> a.RefKategoriID == id).OrderBy(a=>a.UrunAdi).ToList());
        }


        

        public ActionResult Urun(int id)
        {
            ViewBag.KategoriListesi = db.Kategorilers.ToList();
            return View(db.Urunlers.Find(id));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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