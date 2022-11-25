namespace WatchStoreManage.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHD")]
    public partial class CTHD
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SOHD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string MASP { get; set; }

        public int SOLUONG { get; set; }

        public decimal? DONGIASP { get; set; }

        public decimal? THANHTIENSP { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }

        public virtual HOADON HOADON { get; set; }
    }
}
