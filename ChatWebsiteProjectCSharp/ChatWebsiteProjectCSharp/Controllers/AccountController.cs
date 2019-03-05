﻿using ChatWebsiteProjectCSharp.Models;
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
            return View();
        }
        [HttpGet]
        public ActionResult Register() {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel entity) {
            if (!ModelState.IsValid) {
                return View("Register",entity);
            } else {
                try {
                    using (var db = new WebChatEntitiesModel()) {
                        //Generate new id
                        Guid id = Guid.NewGuid();
                        string username = entity.Username.Trim().ToLower();
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
                        customerInfo.status_online = true;
                        customerInfo.last_online = DateTime.Now;
                        customerInfo.email = email;
                        customerInfo.gender = gender;
                        customerInfo.birth = birth;
                        db.customers.Add(customerInfo);
                        db.SaveChanges();
                        return RedirectToAction("Login","Account");
                    }
                } catch {
                    throw;
                }
            }
        }
    }
}