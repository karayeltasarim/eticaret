using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KarayelTasarimEticaret2016.Models;
using System.IO;

namespace KarayelTasarimEticaret2016.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UrunlersController : Controller
    {
        private Eticaret2016Entities db = new Eticaret2016Entities();

        // GET: Urunlers
        public ActionResult Index()
        {
            var urunlers = db.Urunlers.Include(u => u.Kategoriler);
            return View(urunlers.ToList());
        }

      
       
        // GET: Urunlers/Create
        public ActionResult Create()
        {
            ViewBag.RefKategoriID = new SelectList(db.Kategorilers, "KategoriID", "KategoriAdi");
            return View();
        }

        // POST: Urunlers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "UrunID,UrunAdi,RefKategoriID,UrunAciklamasi,UrunFiyati")] Urunler urunler, HttpPostedFileBase UrunResim)
        {
            if (ModelState.IsValid)
            {
                db.Urunlers.Add(urunler);
                db.SaveChanges();


                if (UrunResim != null && UrunResim.ContentLength > 0)
                {
                    string filePath = Path.Combine(Server.MapPath("~/Resim"), urunler.UrunID + ".jpg");
                    UrunResim.SaveAs(filePath);

                }

                return RedirectToAction("Index");
            }

            ViewBag.RefKategoriID = new SelectList(db.Kategorilers, "KategoriID", "KategoriAdi", urunler.RefKategoriID);
            return View(urunler);
        }

        // GET: Urunlers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urunler urunler = db.Urunlers.Find(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            ViewBag.RefKategoriID = new SelectList(db.Kategorilers, "KategoriID", "KategoriAdi", urunler.RefKategoriID);
            return View(urunler);
        }

        // POST: Urunlers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "UrunID,UrunAdi,RefKategoriID,UrunAciklamasi,UrunFiyati")] Urunler urunler, HttpPostedFileBase UrunResim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urunler).State = EntityState.Modified;
                db.SaveChanges();


                if (UrunResim != null && UrunResim.ContentLength > 0)
                {
                    string filePath = Path.Combine(Server.MapPath("~/Resim"), urunler.UrunID + ".jpg");
                    UrunResim.SaveAs(filePath);

                }

                return RedirectToAction("Index");
            }



            ViewBag.RefKategoriID = new SelectList(db.Kategorilers, "KategoriID", "KategoriAdi", urunler.RefKategoriID);
            return View(urunler);
        }

        // GET: Urunlers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urunler urunler = db.Urunlers.Find(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            return View(urunler);
        }

        // POST: Urunlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Urunler urunler = db.Urunlers.Find(id);
            db.Urunlers.Remove(urunler);
            db.SaveChanges();

            string filePath = Path.Combine(Server.MapPath("~/Resim"), urunler.UrunID + ".jpg");

            FileInfo fi = new FileInfo(filePath);

            if (fi.Exists)
                fi.Delete();

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
