//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLBH_NHOM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            this.DONHANGs = new HashSet<DONHANG>();
            this.DONHANGs1 = new HashSet<DONHANG>();
        }
    
        public string MANV { get; set; }
        public string HOTENNV { get; set; }
        public Nullable<bool> GIOITINH { get; set; }
        public string EMAIL_NV { get; set; }
        public string SDT { get; set; }
        public Nullable<int> QUYENNV { get; set; }
        public string TENDANGNHAP { get; set; }
        [DataType(DataType.Password)]
        public string MATKHAU { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs1 { get; set; }
    }
}
