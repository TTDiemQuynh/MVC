using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLBH_NHOM.Models;

namespace QLBH_NHOM.Areas.Admin.Controllers
{
    public class SANPHAMsController : Controller
    {
        private QLBH_NHOMEntities db = new QLBH_NHOMEntities();

        // GET: Admin/SANPHAMs
        string LayMaSP()
        {
            var maMax = db.SANPHAMs.ToList().Select(n => n.MASP).Max();
            int maSP= int.Parse(maMax.Substring(2)) + 1;
            string SP = String.Concat("0", maSP.ToString());
            return "SP" + SP.Substring(maSP.ToString().Length - 1);
        }
        public ActionResult Index()
        {
            var sANPHAMs = db.SANPHAMs.Include(s => s.NHOMSANPHAM);
            return View(sANPHAMs.ToList());
        }
        public ActionResult SPBanchay()
        {
            var sANPHAMs = db.SANPHAMs.SqlQuery("Select sp.MASP, sp.MANHOM, sp.TENSP, sp.DONGIA, sp.GIAGIAM, sp.LINK_HINHANH, sp.TINHTRANG, sp.MOTA, sp.Soluong from SANPHAM sp join CHITIET_DONHANG ctdh on sp.MASP = ctdh.MASP");
            return View(sANPHAMs.ToList());
        }

        // GET: Admin/SANPHAMs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // GET: Admin/SANPHAMs/Create
        public ActionResult Create()
        {
            ViewBag.MASP = LayMaSP();
            ViewBag.MANHOM = new SelectList(db.NHOMSANPHAMs, "MANHOM", "TENNHOM");
            return View();
        }

        // POST: Admin/SANPHAMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MASP,MANHOM,TENSP,DONGIA,GIAGIAM,MOTA,TINHTRANG,LINK_HINHANH,SOLUONG")] SANPHAM sANPHAM)
        {
            var imgSV = Request.Files["ANHMA"];
            string postedFileName = System.IO.Path.GetFileName(imgSV.FileName);

            var path = Server.MapPath("/Content/img" + postedFileName);
            imgSV.SaveAs(path);

            if (ModelState.IsValid)
            {
                var masp = LayMaSP();
                sANPHAM.MASP = masp;
                sANPHAM.LINK_HINHANH = postedFileName;
                db.SANPHAMs.Add(sANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MANHOM = new SelectList(db.NHOMSANPHAMs, "MANHOM", "TENNHOM", sANPHAM.MANHOM);
            return View(sANPHAM);
        }

        // GET: Admin/SANPHAMs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            ViewBag.MANHOM = new SelectList(db.NHOMSANPHAMs, "MANHOM", "TENNHOM", sANPHAM.MANHOM);
            return View(sANPHAM);
        }

        // POST: Admin/SANPHAMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MASP,MANHOM,TENSP,DONGIA,GIAGIAM,MOTA,TINHTRANG,LINK_HINHANH,SOLUONG")] SANPHAM sANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sANPHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MANHOM = new SelectList(db.NHOMSANPHAMs, "MANHOM", "TENNHOM", sANPHAM.MANHOM);
            return View(sANPHAM);
        }

        // GET: Admin/SANPHAMs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            if (sANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(sANPHAM);
        }

        // POST: Admin/SANPHAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SANPHAM sANPHAM = db.SANPHAMs.Find(id);
            db.SANPHAMs.Remove(sANPHAM);
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
