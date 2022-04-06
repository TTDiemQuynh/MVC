using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLBH_NHOM.Controllers;
//using QLBH_NHOM.Filters;
using QLBH_NHOM.Models;
using ServiceStack;

namespace QLBH_NHOM.Controllers
{
    [Authenticate]
    
    public class OrderController : BaseController
    {
        
        
        string LayMaHD()
        {
            var maMax = dbObj.DONHANGs.ToList().Select(n => n.MADON).Max();
            int maHD = int.Parse(maMax.Substring(2)) + 1;
            string HD = String.Concat("00", maHD.ToString());
            return "HD" + HD.Substring(maHD.ToString().Length - 1);
        }
        public ActionResult Detail(string Id)
        {
            var model = dbObj.DONHANGs.Find(Id);
            
            return View(model);
        }
        public ActionResult Checkout()
        {
            if (Session["MaKH"] == null || Session["MaKH"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "Account");
            }
            else
            {
                var model = new DONHANG();
                KHACHHANG user = Session["User"] as KHACHHANG;

                model.NGAYDAT = DateTime.Now;
                model.TIEN = ShoppingCart.Cart.Amount;
                ViewBag.TenKH = user.TENKH;
                model.MAKH = user.MAKH;
                model.DIACHIGIAO = user.DIACHI;
                
              
                model.NGAYGIAO = DateTime.Now;
                model.TINHTRANG = "1";
                
                model.MADON = LayMaHD();
                model.MANV_DUYET = null;
                model.MANV_GIAO = null;
                return View(model);
            }

        }
        [HttpPost]
        public ActionResult Checkout(DONHANG model)
        {
            if (model.DIACHIGIAO == null)
            {
                ViewBag.DiaChi = "Điền Đầy Đủ Thông Tin";
            }
            var user = Session["User"] as KHACHHANG;
           
            try
            {
                
                dbObj.DONHANGs.Add(model);
                dbObj.SaveChanges();
;               
                foreach (var p in ShoppingCart.Cart.Items)
                {
                    var detail = new CHITIET_DONHANG
                    {

                        DONHANG = model,
                        MADON = model.MADON,
                        MASP = p.MASP,
                        DH_SOLUONG = (byte)p.SOLUONG,
                        DH_GIABAN = (int)p.GIAGIAM
                    };
                    dbObj.CHITIET_DONHANG.Add(detail);
                    dbObj.SaveChanges();
                }
                dbObj.SaveChanges();
                ModelState.AddModelError("", "Đặt Hàng Thành Công!");
                ShoppingCart.Cart.Clear();
                return RedirectToAction("Detail", new { Id = model.MADON });
            }
            catch
            {
                ModelState.AddModelError("", "Đặt Hàng Thất Bại!");
            }

            return View(model);
        }

    }
}


