namespace Model.user
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("relationship")]
    public partial class relationship
    {
        [Key]
        [StringLength(32)]
        public string relationship_id { get; set; }

        [Required]
        [StringLength(32)]
        public string cus1_id { get; set; }

        [Required]
        [StringLength(32)]
        public string cus2_id { get; set; }

        public int relationship_status { get; set; }

        public virtual customer customer { get; set; }

        public virtual customer customer1 { get; set; }
    }
}
