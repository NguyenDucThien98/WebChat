﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatWebsiteProjectCSharp.Controllers
{
    public class HomeController : AuthenticationController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}