namespace Model.user
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("notify")]
    public partial class notify
    {
        [Key]
        [StringLength(32)]
        public string notify_id { get; set; }

        [Required]
        [StringLength(32)]
        public string cus_id { get; set; }

        public DateTimeOffset date_create { get; set; }

        [Required]
        public string notify_content { get; set; }

        public virtual customer customer { get; set; }
    }
}
