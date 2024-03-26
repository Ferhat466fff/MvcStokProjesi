using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Controllers;//mvcstok(projemızın ismi)içinde bulunan models(model klasorunun icinde bulunan) entity klasörünü sec
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class SatisController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(Tbl_Satis s)
        {
            db.Tbl_Satis.Add(s);
            db.SaveChanges();
            return View("Index");
        }






    }
}