namespace WatchStoreManage.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            CTHDs = new HashSet<CTHD>();
        }

        [Key]
        [StringLength(15)]
        public string MASP { get; set; }

        [Required]
        [StringLength(200)]
        public string TENSP { get; set; }

        public int SOLUONG { get; set; }

        public decimal GIAMUA { get; set; }

        public decimal GIABAN { get; set; }

        [Required]
        [StringLength(10)]
        public string MALSP { get; set; }

        [Required]
        [StringLength(10)]
        public string MANCC { get; set; }

        [Column(TypeName = "image")]
        public byte[] HinhAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }

        public virtual LOAISANPHAM LOAISANPHAM { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
    }
}
