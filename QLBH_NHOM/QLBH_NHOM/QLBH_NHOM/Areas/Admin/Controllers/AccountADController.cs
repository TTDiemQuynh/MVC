using QLBH_NHOM.Controllers;
using QLBH_NHOM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QLBH_NHOM.Areas.Admin.Controllers
{
    public class AccountADController : Controller
    {
        private QLBH_NHOMEntities db = new QLBH_NHOMEntities();
        // GET: Admin/AccountAD
        public ActionResult Index()
        {
            return View();
        }
        public bool CheckUser(string username, string pws)
        {
            var pass = Encryptor.MD5Hash(pws);
            var kq = db.NHANVIENs.Where(x => x.TENDANGNHAP == username && x.MATKHAU == pass).ToList();
            if (kq.Count() > 0)
            {
                Session["HoTenNV"] = kq.First().HOTENNV;
                Session["MaNV"] = kq.First().MANV;
                Session["pws"] = pws;
                return true;
            }
            else
            {
                Session["HoTenNV"] = null;
                Session["MaNV"] = null;
                return false;
            }
        }
        public ActionResult DangNhapAD()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhapAD(NHANVIEN qt)
        {
            if (ModelState.IsValid)
            {
                if (CheckUser(qt.TENDANGNHAP, qt.MATKHAU))
                {
                    FormsAuthentication.SetAuthCookie(qt.TENDANGNHAP, true);
                    return RedirectToAction("Intro", "HOMEs");
                }
                else
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            }
            return View(qt);
        }
        public ActionResult DangXuatAD()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "../Home");
        }
    }
}