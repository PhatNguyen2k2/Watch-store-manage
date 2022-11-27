namespace WatchStoreManage.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            CTHDs = new HashSet<CTHD>();
        }

        [Key]
        public int SOHD { get; set; }

        [Required]
        [StringLength(10)]
        public string MANV { get; set; }

        public int MAKH { get; set; }

        public DateTime NGAYLAPHOADON { get; set; }

        public decimal? THANHTIENHD { get; set; }

        [StringLength(50)]
        public string TRANGTHAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }
    }
}
