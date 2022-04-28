using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusMvcStok.Models.entity;

namespace BonusMvcStok.Controllers
{
    public class ürünController : Controller
    {
        // GET: ürün
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index(string p)
        {
           // var urunler = db.TBLURUNLER.Where(x=>x.durum==true).ToList();
           var urunler=db.TBLURUNLER.Where(x=>x.durum==true);
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(x => x.ad.Contains(p) && x.durum == true);
            }
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult yeniurun()
        {
            List<SelectListItem> ktg = (from x in db.TBLKATEGORI.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad,
                                            Value = x.id.ToString(),
                                        }).ToList();

            ViewBag.dropdeger = ktg;
            return View();

        }
        [HttpPost]
        public ActionResult yeniurun(TBLURUNLER p)
        {
            var ktg = db.TBLKATEGORI.Where(m => m.id == p.TBLKATEGORI.id).FirstOrDefault();
            p.TBLKATEGORI = ktg;
            db.TBLURUNLER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult ürüngetir(int id)
        {
            List<SelectListItem> urun = (from x in db.TBLKATEGORI.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad,
                                             Value = x.id.ToString()
                                         }).ToList();
            ViewBag.dropdeger2 = urun;
            var ürn = db.TBLURUNLER.Find(id);
            return View("ürüngetir", ürn);
        }
        public ActionResult ürüngüncelle(TBLURUNLER p)
        {
            var ürün = db.TBLURUNLER.Find(p.id);
            ürün.ad = p.ad;
            ürün.marka = p.marka;
            ürün.stok = p.stok;
            ürün.alisfiyat = p.satisfiyat;
            var ürn = db.TBLKATEGORI.Where(m => m.id == p.TBLKATEGORI.id).FirstOrDefault();
            ürün.kategori = ürn.id;
            db.SaveChanges();
            return RedirectToAction("Index", "ürün");
        }
        public ActionResult UrunSil(TBLURUNLER p)
        {
            var urun = db.TBLURUNLER.Find(p.id);
            urun.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}