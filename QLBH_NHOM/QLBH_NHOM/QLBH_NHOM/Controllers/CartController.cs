
//using QLBH_NHOM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace QLBH_NHOM.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Add(string id)
        {
            ShoppingCart.Cart.Add(id);
            var response = new
            {
                Count = ShoppingCart.Cart.Count,
                Amount = ShoppingCart.Cart.Amount
            };
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Remove(string id)
        {
            ShoppingCart.Cart.Remove(id);
            var response = new
            {
                Count = ShoppingCart.Cart.Count,
                Amount = ShoppingCart.Cart.Amount
            };
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update(string id, byte newqty)
        {
            ShoppingCart.Cart.Update(id, newqty);
            var response = new
            {
                Count = ShoppingCart.Cart.Count,
                Amount = ShoppingCart.Cart.Amount
            };
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Clear()
        {
            ShoppingCart.Cart.Clear();
            return View("Index");
        }
       
        }
    }