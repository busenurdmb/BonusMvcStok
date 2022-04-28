using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusMvcStok.Models.entity;

namespace BonusMvcStok.Controllers
{
    public class satısController : Controller
    {
        // GET: satıs
        DbMvcStokEntities db=new DbMvcStokEntities();
        public ActionResult Index()
        {
            var satıs = db.TBLSATISLAR.ToList();
            return View(satıs);
        }
        [HttpGet]
        public ActionResult yenisatis()
        {
            //ürünler
            List<SelectListItem> ürün = (from x in db.TBLURUNLER.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad,
                                             Value = x.id.ToString()
                                         }).ToList();
            ViewBag.dropürün = ürün;
            //personeller
            List<SelectListItem> per = (from x in db.TBLPERSONEL.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad +" " +x.soyad,
                                            Value = x.id.ToString()
                                        }).ToList();
            ViewBag.dropper = per;
            //müsteriler
            List<SelectListItem> mus = (from x in db.TBLMUSTERILER.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad+" "+x.soyad,
                                             Value = x.id.ToString()
                                         }).ToList();
            ViewBag.dropmus = mus;
            return View();
        }
        [HttpPost]
        public ActionResult yenisatis(TBLSATISLAR p)
        {
           var ürün = db.TBLURUNLER.Where(m => m.id == p.TBLURUNLER.id).FirstOrDefault();
            var musteri = db.TBLMUSTERILER.Where(m => m.id == p.TBLMUSTERILER.id).FirstOrDefault();
            var personel = db.TBLPERSONEL.Where(m => m.id == p.TBLPERSONEL.id).FirstOrDefault();
            p.TBLURUNLER = ürün;
            p.TBLMUSTERILER = musteri;
           p.TBLPERSONEL = personel;
            db.TBLSATISLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
           
        }
      
    }
}