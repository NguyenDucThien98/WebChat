namespace Model.user
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class app_user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public app_user()
        {
            app_role = new HashSet<app_role>();
        }

        [Key]
        [StringLength(32)]
        public string app_user_id { get; set; }

        [Required]
        [StringLength(150)]
        public string username { get; set; }

        [Required]
        [StringLength(150)]
        public string encrypted_password { get; set; }

        public virtual customer customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<app_role> app_role { get; set; }
    }
}
