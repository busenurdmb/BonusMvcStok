using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusMvcStok.Models.entity;
using System.Web.Security;

namespace BonusMvcStok.Controllers
{
    public class girişyapController : Controller
    {
        // GET: girişyap
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult giriş()
        {
            return View();
        }
        [HttpPost]
        public ActionResult giriş(TBLADMİN p)
        {
            var bilgiler = db.TBLADMİN.FirstOrDefault(x => x.kullanici == p.kullanici && x.sifre == p.sifre);
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullanici, false);
                return RedirectToAction("Index", "müsteri");
            }
            else
            {
                return View();
            }
            
        }
        public ActionResult çıkış()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("giriş", "girişyap");

        }
    }
}