using PagedList;
using QLBH_NHOM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace QLBH_NHOM.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        QLBH_NHOMEntities dbObj = new QLBH_NHOMEntities();

        public ActionResult Index()
        {
            BaseModel baseModel = new BaseModel();

            var listCate = dbObj.NHOMSANPHAMs.ToList();
            baseModel.listCate = listCate;

            var listpro = dbObj.SANPHAMs.ToList();
            baseModel.listpro = listpro;
            return View(baseModel);
            //return View(db.SANPHAMs.ToList());
        }
        public ActionResult SPtheoloai(String maloai)
        {
            BaseModel baseModel = new BaseModel();
            var listCate = dbObj.NHOMSANPHAMs.ToList();
            baseModel.listCate = listCate;

            var tk = dbObj.SANPHAMs.SqlQuery("select* from SANPHAM where MANHOM ='" + maloai + "'").ToList();

            baseModel.listpro = tk;
            return View(baseModel);
        }
        public ActionResult Search(String tuKhoa)
        {
            BaseModel baseModel = new BaseModel();
            var listCate = dbObj.NHOMSANPHAMs.ToList();
            baseModel.listCate = listCate;
            var tk = dbObj.SANPHAMs.SqlQuery("select* from SANPHAM where TENSP like '%"+ tuKhoa + "%'").ToList();
            baseModel.listpro = tk;
            return View(baseModel);
        }



    }
}