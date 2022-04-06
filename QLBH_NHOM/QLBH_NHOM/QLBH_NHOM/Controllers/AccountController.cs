using QLBH_NHOM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QLBH_NHOM.Controllers
{
    public class AccountController : Controller
    {
        private QLBH_NHOMEntities db = new QLBH_NHOMEntities();
        // GET: Account
        string LayMaKH()
        {
            var maMax = db.KHACHHANGs.ToList().Select(n => n.MAKH).Max();
            int maKH = int.Parse(maMax.Substring(2)) + 1;
            string KH = String.Concat("0", maKH.ToString());
            return "KH" + KH.Substring(maKH.ToString().Length - 1);
        }
        public ActionResult DangKy()
            
        {
            ViewBag.MAKH = LayMaKH();
            return View();
        }

        // POST: Admin/KHACHHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(KHACHHANG _kh, String tenKH, bool gTinh, String emailKH, String sDT, String diaChi, String tenDangNhap, String password, String repassword)
        {
            if (ModelState.IsValid)
            {
                var kt_tenDN_NV = db.NHANVIENs.SqlQuery("select * from NHANVIEN where TENDANGNHAP = '" + tenDangNhap + "'");
                if (kt_tenDN_NV.Count() > 0)
                {
                    ModelState.AddModelError("", "Tên đăng nhập của bạn đã bị trùng với tên đăng nhập của nhân viên, vui lòng chọn tên đăng nhập khác.");
                    return View();
                }
                var kt_tenDN = db.KHACHHANGs.SqlQuery("select * from KHACHHANG where TENDANGNHAP = '" + tenDangNhap + "'");
                if (kt_tenDN.Count() == 1) // kiểm tra có tên DN nào trùng chưa
                { // nếu có
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại, vui lòng chọn tên đăng nhập khác.");
                }
                else  // nếu không
                {
                    if (password == repassword) // kiểm tra MK = MK nhập lại chưa
                    { //nếu có thì tiếng hành tạo mới   
                        var matKhau = Encryptor.MD5Hash(password);
                       
                        var gt = gTinh;
                        var maKH = LayMaKH();
                        _kh.MAKH = maKH;
                        _kh.TENKH = tenKH;
                        _kh.GIOITINH = gt;
                        _kh.EMAIL_KH = emailKH;
                        _kh.SDT = sDT;
                        _kh.DIACHI = diaChi;
                        _kh.TENDANGNHAP = tenDangNhap;
                        _kh.MATKHAU = matKhau;
                        db.KHACHHANGs.Add(_kh);
                        db.SaveChanges();
                        //db.KHACHHANG.SqlQuery("insert into dbo.KHACHHANG values ('" + maKH + "', N'" + tenKH + "',' + gt + ', '" + emailKH + "', '" + sDT + "', N'" + diaChi + "', '" + tenDangNhap + "', '" + matKhau + "')");
                        var kt = db.KHACHHANGs.SqlQuery("select* from KHACHHANG where MAKH = '" + maKH + "' and TENDANGNHAP = '" + tenDangNhap + "'");
                        if (kt.Count() == 0) ModelState.AddModelError("", "Đăng ký thất bại");
                        return RedirectToAction("DangNhap");
                    }
                    else // nếu không thì yêu cầu nhập lại MK và reMK
                        ModelState.AddModelError("", "Mật khẩu nhập lại khong chính xác");
                }
            }
            return View(DangNhap());
        }


        public bool CheckUserNV(string username, string pws)
        {
            var pass = Encryptor.MD5Hash(pws);
            var kq = db.NHANVIENs.Where(x => x.TENDANGNHAP == username && x.MATKHAU == pass && x.QUYENNV==1).ToList();
            if (kq.Count() > 0)
            {
                Session["HoTenNV"] = kq.First().HOTENNV;
                Session["MaNV"] = kq.First().MANV;
                
                return true;
            }
            else
            {

                Session["HoTenNV"] = null;
                Session["MaNV"] = null;
                return false;
            }
        }
        public bool CheckUserKH(string username, string pws)
        {
            var pass = Encryptor.MD5Hash(pws);
            var kq1 = db.KHACHHANGs.Where(x => x.TENDANGNHAP == username && x.MATKHAU == pass).ToList();
            if (kq1.Count() > 0)
            {
                Session["HoTenKH"] = kq1.First().TENKH;
                Session["MaKH"] = kq1.First().MAKH;
                Session["User"] =  db.KHACHHANGs.SingleOrDefault(x => x.TENDANGNHAP == username && x.MATKHAU == pass);
                return true;
            }
            else
            {

                Session["HoTenKH"] = null;
                Session["MaKH"] = null;
                return false;
            }

        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(NHANVIEN qt)
        {
            if (ModelState.IsValid)
            {
                if (CheckUserNV(qt.TENDANGNHAP, qt.MATKHAU))
                {
                    FormsAuthentication.SetAuthCookie(qt.TENDANGNHAP, true);
                    return RedirectToAction("Intro","Admin/HOMEs");
                   
                }
                else
                    if (CheckUserKH(qt.TENDANGNHAP, qt.MATKHAU))
                    {
                        FormsAuthentication.SetAuthCookie(qt.TENDANGNHAP, true);
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            }
            return View(qt);
        }
        public ActionResult DangXuat()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
    public static class Encryptor
    {
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}