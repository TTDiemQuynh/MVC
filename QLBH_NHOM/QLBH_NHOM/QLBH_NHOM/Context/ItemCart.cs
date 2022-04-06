using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLBH_NHOM.Models
{
    public class ItemCart
    {
        public string MASP { get; set; }
        public string MANHOM { get; set; }
        public string TENSP { get; set; }
        public Nullable<int> DONGIA { get; set; }
        public double GIAGIAM { get; set; }
        public int DH_SOLUONG { get; set; }
        public string LINK_HINHANH { get; set; }
        public double tonggia()
        {
            return DH_SOLUONG * GIAGIAM;
        }
    }
}