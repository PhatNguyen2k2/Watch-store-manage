namespace WatchStoreManage.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MESSAGE")]
    public partial class MESSAGE
    {
        [Key]
        public int SOTN { get; set; }

        [StringLength(10)]
        public string NGGUI { get; set; }

        [StringLength(10)]
        public string NGNHAN { get; set; }

        [StringLength(1000)]
        public string NOIDUNG { get; set; }

        public DateTime? THOIGIAN { get; set; }
    }
}
