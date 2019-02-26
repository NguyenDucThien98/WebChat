using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebChat.Models {
    public class LoginModel {
        private string username, encrypted_password;
        private bool remember;
        [Required]
        public string Username {
            get {
                return username;
            }

            set {
                this.username = value;
            }
        }

        public string Encrypted_password {
            get {
                return encrypted_password;
            }

            set {
                this.encrypted_password = value;
            }
        }

        public bool Remember {
            get {
                return remember;
            }

            set {
                this.remember = value;
            }
        }

    }
}