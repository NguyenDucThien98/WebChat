namespace Model.user
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("customer")]
    public partial class customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customer()
        {
            messages = new HashSet<message>();
            messages1 = new HashSet<message>();
            notifies = new HashSet<notify>();
            relationships = new HashSet<relationship>();
            relationships1 = new HashSet<relationship>();
        }

        [Key]
        [StringLength(32)]
        public string app_user_id { get; set; }

        public string avatar { get; set; }

        [Required]
        [StringLength(200)]
        public string fullname { get; set; }

        public bool status_online { get; set; }

        public DateTimeOffset last_online { get; set; }

        [Required]
        [StringLength(254)]
        public string email { get; set; }

        [StringLength(10)]
        public string phone { get; set; }

        public bool gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime birth { get; set; }

        [StringLength(200)]
        public string city { get; set; }

        public string customer_description { get; set; }

        public virtual app_user app_user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<message> messages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<message> messages1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<notify> notifies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<relationship> relationships { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<relationship> relationships1 { get; set; }
    }
}
