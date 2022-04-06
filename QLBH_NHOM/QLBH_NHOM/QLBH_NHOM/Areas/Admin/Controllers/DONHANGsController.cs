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
    public class DONHANGsController : Controller
    {
        private QLBH_NHOMEntities db = new QLBH_NHOMEntities();
        SANPHAM spham;

        // GET: Admin/DONHANGs
        public ActionResult Index()
        {
            var dONHANGs = db.DONHANGs.Include(d => d.KHACHHANG).Include(d => d.NHANVIEN).Include(d => d.NHANVIEN1).Include(d => d.TINHTRANGDON);
            return View(dONHANGs.ToList());
        }

        // GET: Admin/DONHANGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONHANG dONHANG = db.DONHANGs.Find(id);
            if (dONHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONHANG);
        }

        // GET: Admin/DONHANGs/Create
        public ActionResult Create()
        {
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENKH");
            ViewBag.MANV_DUYET = new SelectList(db.NHANVIENs, "MANV", "HOTENNV");
            ViewBag.MANV_GIAO = new SelectList(db.NHANVIENs, "MANV", "HOTENNV");
            ViewBag.TINHTRANG = new SelectList(db.TINHTRANGDONs, "TINHTRANG", "MOTA");
            return View();
        }

        // POST: Admin/DONHANGs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MADON,MAKH,MANV_DUYET,MANV_GIAO,NGAYDAT,NGAYGIAO,DIACHIGIAO,TINHTRANG,TIEN")] DONHANG dONHANG)
        {
            if (ModelState.IsValid)
            {
                db.DONHANGs.Add(dONHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENKH", dONHANG.MAKH);
            ViewBag.MANV_DUYET = new SelectList(db.NHANVIENs, "MANV", "HOTENNV", dONHANG.MANV_DUYET);
            ViewBag.MANV_GIAO = new SelectList(db.NHANVIENs, "MANV", "HOTENNV", dONHANG.MANV_GIAO);
            ViewBag.TINHTRANG = new SelectList(db.TINHTRANGDONs, "TINHTRANG", "MOTA", dONHANG.TINHTRANG);
            return View(dONHANG);
        }

        // GET: Admin/DONHANGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONHANG dONHANG = db.DONHANGs.Find(id);
            if (dONHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENKH", dONHANG.MAKH);
            ViewBag.MANV_DUYET = new SelectList(db.NHANVIENs, "MANV", "HOTENNV", dONHANG.MANV_DUYET);
            ViewBag.MANV_GIAO = new SelectList(db.NHANVIENs, "MANV", "HOTENNV", dONHANG.MANV_GIAO);
            ViewBag.TINHTRANG = new SelectList(db.TINHTRANGDONs, "TINHTRANG", "MOTA", dONHANG.TINHTRANG);
            return View(dONHANG);
        }

        // POST: Admin/DONHANGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MADON,MAKH,MANV_DUYET,MANV_GIAO,NGAYDAT,NGAYGIAO,DIACHIGIAO,TINHTRANG,TIEN")] DONHANG dONHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dONHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENKH", dONHANG.MAKH);
            ViewBag.MANV_DUYET = new SelectList(db.NHANVIENs, "MANV", "HOTENNV", dONHANG.MANV_DUYET);
            ViewBag.MANV_GIAO = new SelectList(db.NHANVIENs, "MANV", "HOTENNV", dONHANG.MANV_GIAO);
            ViewBag.TINHTRANG = new SelectList(db.TINHTRANGDONs, "TINHTRANG", "MOTA", dONHANG.TINHTRANG);
            return View(dONHANG);
        }

        public ActionResult XacNhanDon(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONHANG dONHANG = db.DONHANGs.Find(id);
            if (dONHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENKH", dONHANG.MAKH);
            ViewBag.MANV_DUYET = new SelectList(db.NHANVIENs, "MANV", "HOTENNV", dONHANG.MANV_DUYET);
            ViewBag.MANV_GIAO = new SelectList(db.NHANVIENs, "MANV", "HOTENNV", dONHANG.MANV_GIAO);
            ViewBag.TINHTRANG = new SelectList(db.TINHTRANGDONs, "TINHTRANG", "MOTA", dONHANG.TINHTRANG);
            return View(dONHANG);
        }

        // POST: Admin/DONHANGs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult XacNhanDon([Bind(Include = "MADON,MAKH,MANV_DUYET,MANV_GIAO,NGAYDAT,NGAYGIAO,DIACHIGIAO,TINHTRANG,TIEN")] DONHANG dONHANG)
        {
            if (ModelState.IsValid)
            {
                dONHANG.MANV_DUYET = Session["MaNV"].ToString() ;
                db.Entry(dONHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DuyetDon");
            }
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENKH", dONHANG.MAKH);
            ViewBag.MANV_DUYET = new SelectList(db.NHANVIENs, "MANV", "HOTENNV", dONHANG.MANV_DUYET);
            ViewBag.MANV_GIAO = new SelectList(db.NHANVIENs, "MANV", "HOTENNV", dONHANG.MANV_GIAO);
            ViewBag.TINHTRANG = new SelectList(db.TINHTRANGDONs, "TINHTRANG", "MOTA", dONHANG.TINHTRANG);
           
            return View(dONHANG);
        }
      
        public ActionResult DuyetDon()
        {
            //BaseModel baseModel = new BaseModel();
            //var ctdh = db.CHITIET_DONHANG.ToList();
            //baseModel.listCT_DONHANG = ctdh;

            var DHs = (from l in db.DONHANGs
                       where l.TINHTRANG == "1"|| l.TINHTRANG==null
                       select l);
            //baseModel.listDONHANG = DHs;

            //var sp= db.SANPHAMs.ToList();
            //baseModel.listSP = sp;
            return View(DHs.ToList());
        }


        public ActionResult SPDAT(string Id)
        {
            var model = db.DONHANGs.Find(Id);
            return PartialView(model);
        }

        // GET: Admin/DONHANGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONHANG dONHANG = db.DONHANGs.Find(id);
            if (dONHANG == null)
            {
                return HttpNotFound();
            }
            return View(dONHANG);
        }

        // POST: Admin/DONHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DONHANG dONHANG = db.DONHANGs.Find(id);
            db.DONHANGs.Remove(dONHANG);
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
