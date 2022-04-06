using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using QLBH_NHOM.Models;
using QLBH_NHOM.Controllers;

namespace QLBH_NHOM.Areas.Admin.Controllers
{
    public class NHANVIENsController : Controller
    {
        private QLBH_NHOMEntities db = new QLBH_NHOMEntities();

        // GET: NHANVIENs
        string LayMaNV()
        {
            var maMax = db.NHANVIENs.ToList().Select(n => n.MANV).Max();
            int maNV = int.Parse(maMax.Substring(2)) + 1;
            string NV = String.Concat("0", maNV.ToString());
            return "NV" + NV.Substring(maNV.ToString().Length - 1);
        }
        public ActionResult Index()
        {
            return View(db.NHANVIENs.ToList());
        }
        public ActionResult NotFound()
        {
            return View();
        }

        // GET: NHANVIENs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }

            return View(nHANVIEN);
        }
        public ActionResult CT_TaiKhoan()
        {
            string id = (string)Session["MaNV"];
            if (id == null)
            {
                return RedirectToAction("NotFound", "NHANVIENs");
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return RedirectToAction("NotFound", "NHANVIENs");
            }
            ViewBag.MK = (string)Session["pws"];
            return View(nHANVIEN);
        }

        public ActionResult Intro()
        {
            if (Session["HoTenNV"] == null || Session["HoTenNV"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "NHANVIENs");
            }
            else
                return View();
        }
        // GET: NHANVIENs/Create
        public ActionResult Create()
        {
            ViewBag.MANV = LayMaNV();
            return View();
        }

        // POST: NHANVIENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MANV,HOTENNV,GIOITINH,EMAIL_NV,SDT,QUYENNV,TENDANGNHAP,MATKHAU")] NHANVIEN nHANVIEN)
        {

            if (ModelState.IsValid)
            {
                var manv = LayMaNV();
                nHANVIEN.MANV = manv;
                var pass = Encryptor.MD5Hash(nHANVIEN.MATKHAU);
                nHANVIEN.MATKHAU = pass;
                db.NHANVIENs.Add(nHANVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: NHANVIENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MANV,HOTENNV,GIOITINH,EMAIL_NV,SDT,QUYENNV,TENDANGNHAP,MATKHAU")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHANVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nHANVIEN);
        }

        // GET: NHANVIENs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: NHANVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            db.NHANVIENs.Remove(nHANVIEN);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
    
}


