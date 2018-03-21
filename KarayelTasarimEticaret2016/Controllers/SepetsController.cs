using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KarayelTasarimEticaret2016.Models;
using Microsoft.AspNet.Identity;

namespace KarayelTasarimEticaret2016.Controllers
{

    // User ile ilgili bilgiler olması için kullanıcı girişi yapmamış birisinin buraya gelmesi engelleniyor.
    [Authorize] // Giriş yapmış kişilerin buraya erişmesi için
    public class SepetsController : Controller
    {
        private Eticaret2016Entities db = new Eticaret2016Entities();

        public ActionResult SepeteEkle(int? adet, int id) // adet boş gelirse otomatik 1 ekliyoruz
        {

            // Sepette Ürün var mı Kontrol Ediyoruz

            // user id yi string değişken alıyoruz. 
            string userID = User.Identity.GetUserId(); // using Microsoft.AspNet.Identity; bunu eklediğimiz zaman .GetUserId() fonksiyonunu kullanabiliyoruz.

            Sepet sepettekiUrun = db.Sepets.FirstOrDefault( a=> a.RefUrunID == id && a.RefAspNetUserID == userID);

            Urunler urun = db.Urunlers.Find(id);

            if (sepettekiUrun == null) // sepette urun yoksa
            {
                Sepet yeniUrun = new Sepet()
                {
                    RefAspNetUserID = userID,
                    RefUrunID = id,
                    Adet = adet ?? 1,
                    ToplamTutar = (adet ?? 1) * urun.UrunFiyati
                };
                db.Sepets.Add(yeniUrun);
            }
            else
            {
                sepettekiUrun.Adet = sepettekiUrun.Adet + (adet ?? 1);
                sepettekiUrun.ToplamTutar = sepettekiUrun.Adet * urun.UrunFiyati;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            string userID = User.Identity.GetUserId();
            var sepets = db.Sepets.Where(a=>a.RefAspNetUserID == userID).Include(s => s.Urunler);
            return View(sepets.ToList());
        }

        public ActionResult SepeteGuncelle(int? adet, int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Sepet sepet = db.Sepets.Find(id);

            if (sepet == null)
            {
                return HttpNotFound();
            }

            Urunler urun = db.Urunlers.Find(sepet.RefUrunID);

            sepet.Adet = adet ?? 1;
            sepet.ToplamTutar = sepet.Adet * urun.UrunFiyati;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            Sepet sepet = db.Sepets.Find(id);
            db.Sepets.Remove(sepet);
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
