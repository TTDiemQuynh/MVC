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
    public class NHOMSANPHAMsController : Controller
    {
        private QLBH_NHOMEntities db = new QLBH_NHOMEntities();

        // GET: Admin/NHOMSANPHAMs
        string LayMaN()
        {
            var maMax = db.NHOMSANPHAMs.ToList().Select(n => n.MANHOM).Max();
            int maN = int.Parse(maMax.Substring(3)) + 1;
            
            string SP = String.Concat("0", maN.ToString());
            return "NSP" + SP.Substring(maN.ToString().Length - 1);
        }
        public ActionResult Index()
        {
            return View(db.NHOMSANPHAMs.ToList());
        }

        // GET: Admin/NHOMSANPHAMs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHOMSANPHAM nHOMSANPHAM = db.NHOMSANPHAMs.Find(id);
            if (nHOMSANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(nHOMSANPHAM);
        }

        // GET: Admin/NHOMSANPHAMs/Create
        public ActionResult Create()
        {
            ViewBag.MANHOM = LayMaN();
            return View();
        }

        // POST: Admin/NHOMSANPHAMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MANHOM,TENNHOM")] NHOMSANPHAM nHOMSANPHAM)
        {
            if (ModelState.IsValid)
            {
                var manhom = LayMaN();
                nHOMSANPHAM.MANHOM = manhom;
                db.NHOMSANPHAMs.Add(nHOMSANPHAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nHOMSANPHAM);
        }

        // GET: Admin/NHOMSANPHAMs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHOMSANPHAM nHOMSANPHAM = db.NHOMSANPHAMs.Find(id);
            if (nHOMSANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(nHOMSANPHAM);
        }

        // POST: Admin/NHOMSANPHAMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MANHOM,TENNHOM")] NHOMSANPHAM nHOMSANPHAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHOMSANPHAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nHOMSANPHAM);
        }

        // GET: Admin/NHOMSANPHAMs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHOMSANPHAM nHOMSANPHAM = db.NHOMSANPHAMs.Find(id);
            if (nHOMSANPHAM == null)
            {
                return HttpNotFound();
            }
            return View(nHOMSANPHAM);
        }

        // POST: Admin/NHOMSANPHAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NHOMSANPHAM nHOMSANPHAM = db.NHOMSANPHAMs.Find(id);
            db.NHOMSANPHAMs.Remove(nHOMSANPHAM);
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
