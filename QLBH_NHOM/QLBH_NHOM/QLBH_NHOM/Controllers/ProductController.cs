using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLBH_NHOM.Models;

namespace QLBH_NHOM.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        QLBH_NHOMEntities db = new QLBH_NHOMEntities();
        public ActionResult Index(String id)
        {
            var objproducts = db.SANPHAMs.Where(n => n.MASP == id).First();
            return View(objproducts);
        }
    }
}