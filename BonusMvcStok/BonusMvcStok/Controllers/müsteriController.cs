using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusMvcStok.Models.entity;
using PagedList;
using PagedList.Mvc;

namespace BonusMvcStok.Controllers
{
    public class müsteriController : Controller
    {
        // GET: müsteri
        DbMvcStokEntities db = new DbMvcStokEntities();
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            //var musterıliste = db.TBLMUSTERILER.ToList();
            var musterıliste = db.TBLMUSTERILER.Where(m=>m.durum==true).ToList().ToPagedList(sayfa, 3);
            return View(musterıliste);
        }
        [HttpGet]
        public ActionResult yenimusteri()
        {
            return View();

        }
        [HttpPost]
        public ActionResult yenimusteri(TBLMUSTERILER p)
        {
            if (!ModelState.IsValid)
            {
                return View("yenimusteri");
            }
            p.durum = true;
            db.TBLMUSTERILER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult müsterisil(TBLMUSTERILER p)
        {
            var mbul = db.TBLMUSTERILER.Find(p.id);
            mbul.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult musterigetir(int id)
        {
            var mus = db.TBLMUSTERILER.Find(id);
            return View("musterigetir",mus);
        }
        public ActionResult güncelle(TBLMUSTERILER p)
        {
            var mus = db.TBLMUSTERILER.Find(p.id);
            mus.ad = p.ad;
            mus.soyad = p.soyad;
            mus.sehir = p.sehir;
            mus.bakiye = p.bakiye;
            db.SaveChanges();
            return RedirectToAction("Index",mus);
        }
    }
}