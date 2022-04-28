using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusMvcStok.Models.entity;

namespace BonusMvcStok.Controllers
{
    public class adminController : Controller
    {
        // GET: admin
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult yeniadmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yeniadmin(TBLADMİN p)
        {
            db.TBLADMİN.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}