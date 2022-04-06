using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBH_NHOM.Areas.Admin.Controllers
{
    public class HOMEsController : Controller
    {
        // GET: Admin/HOME
        public ActionResult Intro()

        {
            //if (Session["HoTen"] == null || Session["HoTen"].ToString() == "")
            //{
            //    return RedirectToAction("DangNhapAD", "AccountAD");
            //}
            //else
                return View();
            
        }
    }
}