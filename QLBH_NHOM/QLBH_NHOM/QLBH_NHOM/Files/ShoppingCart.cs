using QLBH_NHOM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class ShoppingCart
    {
        public static ShoppingCart Cart
        {
            get
            {
                var cart = HttpContext.Current.Session["Cart"] as ShoppingCart;
                if (cart == null)
                {
                    cart = new ShoppingCart();
                    HttpContext.Current.Session["Cart"] = cart;
                }
                return cart;
            }
        }


    public List<SANPHAM> Items = new List<SANPHAM>();

    public int Count
        {
            get
            {
                return (int)Items.Sum(p => p.SOLUONG);
            }
        }


        public int Amount
        {
            get
            {
                return (int)Items.Sum(p => p.SOLUONG * p.GIAGIAM);
            }
        }


        public void Add(string id)
        {
            try
            {
                var p = Items.Single(i => i.MASP == id);
                p.SOLUONG++;
            }
            catch
            {
                using (var db = new QLBH_NHOMEntities())
                {
                    var p = db.SANPHAMs.Find(id);
                    p.SOLUONG = 1;
                    Items.Add(p);
                }
            }
        }

        public void Remove(string id)
        {
            var p = Items.Single(i => i.MASP == id);
            Items.Remove(p);
        }


        public void Update(string id, byte newQty)
        {
            var p = Items.Single(i => i.MASP == id);
            p.SOLUONG = newQty;
        }

        public void Clear()
        {
            Items.Clear();
        }
    }
