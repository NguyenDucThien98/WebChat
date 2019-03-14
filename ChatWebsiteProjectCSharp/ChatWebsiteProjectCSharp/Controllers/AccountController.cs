using ChatWebsiteProjectCSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ChatWebsiteProjectCSharp.Controllers {
    public class AccountController : Controller {
        // GET: Account
        [HttpGet]
        public ActionResult Login() {
            var session = Session["UserID"];
            if (session != null) {
                return RedirectToAction("Index","Home");
            }
            System.Diagnostics.Debug.WriteLine("Chua xac thuc");
            return View();

        }
        [HttpGet]
        public ActionResult Register() {
            var session = Session["UserID"];
            if (session != null) {
                return RedirectToAction("Index","Home");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel entity) {
            if (!ModelState.IsValid) {
                return View("Register",entity);
            } else {
                try {
                    using (var db = new WebChat2Entities()) {
                        Guid id = Guid.NewGuid();
                        string username = entity.Username.Trim().ToLower();
                        var check = db.app_user.Where(u => u.username == username);
                        if (check.Count() == 0) {
                            string password = entity.Password.Trim().ToLower();
                            string encrypt_password = BCrypt.Net.BCrypt.HashPassword(password);
                            var loginInfo = new app_user {
                                app_user_id = id,
                                username = username,
                                encrypted_password = encrypt_password
                            };
                            db.app_user.Add(loginInfo);
                            db.SaveChanges();
                            string email = entity.Email.Trim().ToLower();
                            string fullname = entity.Name.Trim();
                            DateTime birth = entity.Birth;
                            bool gender = entity.Gender;
                            var customerInfo = new customer();
                            customerInfo.app_user_id = id;
                            customerInfo.fullname = fullname;
                            customerInfo.status_online = false;
                            customerInfo.last_online = DateTime.Now;
                            customerInfo.email = email;
                            customerInfo.gender = gender;
                            customerInfo.birth = birth;
                            if (gender) {
                                customerInfo.avatar = "1nam.png";
                            } else {
                                customerInfo.avatar = "0nu.png";
                            }
                            customerInfo.last_change_password = DateTime.Now;
                            db.customers.Add(customerInfo);
                            db.SaveChanges();
                            TempData["error"] = "Register successfuly!";
                            return View("Register",entity);
                        } else {
                            TempData["error"] = "username is duplicate!";
                            return View("Register",entity);
                        }

                    }
                } catch {
                    throw;
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(LoginModel model) {
            if (!ModelState.IsValid) {
                return View("Login",model);
            } else {
                using (var db = new WebChat2Entities()) {
                    var userInfoDB = db.app_user.Where(s => s.username == model.UserName.ToLower().Trim()).FirstOrDefault();
                    bool isLogin = false;
                    if (userInfoDB != null) {
                        var passwordDB = userInfoDB.encrypted_password;
                        isLogin = BCrypt.Net.BCrypt.Verify(model.PassWord,passwordDB);
                    } else {
                        TempData["error"] = "Wrong Username!";
                        return View("Login",model);
                    }
                    if (!isLogin) {
                        TempData["error"] = "Wrong Password!";
                        return View("Login",model);
                    } else {
                        SignInRemember(model.UserName,model.remember);
                        Session["UserID"] = userInfoDB.app_user_id;
                        setOnlineUser(db,userInfoDB.app_user_id);

                        return RedirectToAction("Index","Home");
                    }
                }
            }
        }
        [NonAction]
        private void SignInRemember(string userName,bool isPersistent = false) {
            FormsAuthentication.SignOut();
            FormsAuthentication.SetAuthCookie(userName,isPersistent);
        }
        private void setOnlineUser(WebChat2Entities db,Guid userID) {
            var isOnline = db.customers.Find(userID);
            isOnline.status_online = true;
            db.SaveChanges();
        }
    }
}