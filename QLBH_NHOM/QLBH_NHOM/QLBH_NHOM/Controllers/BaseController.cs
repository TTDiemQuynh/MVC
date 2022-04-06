using QLBH_NHOM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBH_NHOM.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected QLBH_NHOMEntities dbObj = new QLBH_NHOMEntities();
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbObj.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}