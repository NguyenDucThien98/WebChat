using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.Models;

namespace WebChat.Controllers {
    public class LoginController : Controller {
        // GET: Login
        [HttpGet]
        public ActionResult Login() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model) {
            var result = new AccontModel().Login(model.Username,model.Encrypted_password);
            if (result && ModelState.IsValid) {
            } else {
                ModelState.AddModelError("","Sai Username hoặc Password");
            }
            return View();
        }
    }
}