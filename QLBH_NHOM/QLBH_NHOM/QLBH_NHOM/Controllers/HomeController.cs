using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBH_NHOM.Models;

namespace QLBH_NHOM.Controllers
{
    public class HomeController : Controller
    {
        QLBH_NHOMEntities db = new QLBH_NHOMEntities();
        public ActionResult Index()
        {
            return View(db.SANPHAMs.ToList());
        }
    }
}