using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusMvcStok.Models.entity;

namespace BonusMvcStok.Controllers
{
    public class kategorilerController : Controller
    {
        // GET: kategoriler
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index()
        {
            var kategoriler = db.TBLKATEGORI.ToList();
            return View(kategoriler);
        }
        [HttpGet]
        public ActionResult kategoriekle()
        {
            return View();

        }
        [HttpPost]
        public ActionResult kategoriekle(TBLKATEGORI p)
        {
            
            db.TBLKATEGORI.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult kategorisil(int id)
        {
            var ktg = db.TBLKATEGORI.Find(id);
            db.TBLKATEGORI.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult kategorigetir(int id)
        {
            var ktg = db.TBLKATEGORI.Find(id);
            return View("kategorigetir",ktg);
        }
        [HttpPost]
        public ActionResult kategorigüncelle(TBLKATEGORI p)
        {
            var ktg = db.TBLKATEGORI.Find(p.id);
            ktg.ad = p.ad;
            db.SaveChanges();
            return RedirectToAction("Index","kategoriler");
        }
    }
}