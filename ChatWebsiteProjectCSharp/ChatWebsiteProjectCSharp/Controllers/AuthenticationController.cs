using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatWebsiteProjectCSharp.Controllers {
    public class AuthenticationController : Controller {
        protected override void OnActionExecuting(ActionExecutingContext fillter) {
            var session = Session["UserID"];
            if (session == null) {
                fillter.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new {
                    Controller = "Account",
                    action = "Login"
                }));
            }
            base.OnActionExecuting(fillter);
        }
    }
}