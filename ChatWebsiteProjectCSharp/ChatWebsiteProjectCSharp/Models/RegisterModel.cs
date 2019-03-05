using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChatWebsiteProjectCSharp.Models {
    public class RegisterModel {
        [Required]
        [StringLength(30,MinimumLength = 6)]
        public string Username {
            get; set;
        }
        [Required]
        [StringLength(30,MinimumLength = 6)]

        public string Password {
            get; set;
        }
        [Required]
        [StringLength(30,MinimumLength = 6)]
        [Compare("Password")]
        public string Repassword {
            get; set;
        }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email {
            get; set;
        }
        [Required]
        [StringLength(30,MinimumLength = 3)]
        public string Name {
            get; set;
        }
        [Required]
        public bool Gender {
            get; set;
        }
        [Required]
        public DateTime Birth {
            get; set;
        }
    }
}