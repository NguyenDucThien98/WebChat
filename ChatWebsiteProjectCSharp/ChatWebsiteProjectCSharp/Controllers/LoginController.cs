﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatWebsiteProjectCSharp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LoginForm()
        {
            return View();
        }
    }
}