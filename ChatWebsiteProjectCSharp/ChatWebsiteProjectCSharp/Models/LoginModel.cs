using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChatWebsiteProjectCSharp.Models {
    public class LoginModel {
        [Required]
        [MinLength(6)]
        [MaxLength(30)]
        public string UserName {
            get; set;
        }
        [Required]
        [MinLength(6)]
        [MaxLength(30)]
        public string PassWord {
            get; set;
        }
        public bool remember {
            get; set;
        }

    }
}