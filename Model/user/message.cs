namespace Model.user
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("message")]
    public partial class message
    {
        [StringLength(32)]
        public string id { get; set; }

        [Required]
        [StringLength(32)]
        public string cus_send_id { get; set; }

        [Required]
        [StringLength(32)]
        public string cus_receive_id { get; set; }

        [Column("message")]
        [Required]
        public string message1 { get; set; }

        public DateTimeOffset send_time { get; set; }

        public int message_status { get; set; }

        public virtual customer customer { get; set; }

        public virtual customer customer1 { get; set; }
    }
}
