namespace Model.user
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class app_role
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public app_role()
        {
            app_user = new HashSet<app_user>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long role_id { get; set; }

        [Required]
        [StringLength(30)]
        public string role_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<app_user> app_user { get; set; }
    }
}
