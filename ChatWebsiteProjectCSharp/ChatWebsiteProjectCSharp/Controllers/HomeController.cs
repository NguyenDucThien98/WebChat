using ChatWebsiteProjectCSharp.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatWebsiteProjectCSharp.Controllers {
    public class HomeController : AuthenticationController {
        // GET: Home
        public ActionResult Index() {
            return View();
        }
        public PartialViewResult getLeftChatBox(int? page) {
            int pagesize = 1;
            List<Chatbox> list = new List<Chatbox>();
            int pageNum = (page ?? 1);
            using (var db = new WebChat2Entities()) {
                string user = Session["UserID"].ToString();
                var listMess = db.messages.Where(u => u.user_1.ToString() == user || u.user_2.ToString() == user).ToList();
                Chatbox c = new Chatbox();
                foreach (var item in listMess) {
                    if (item.user_1.ToString() != user) {
                        var customer = db.customers.Where(u => u.app_user_id == item.user_1).FirstOrDefault();
                        var messinfor = db.message_info.Where(u => u.message_id == item.message_id).OrderByDescending(u => u.send_time).FirstOrDefault();
                        c.id = customer.app_user_id;
                        c.avatar = customer.avatar;
                        c.name = customer.fullname;
                        c.mess = messinfor.message;
                        c.time = messinfor.send_time;
                        list.Add(c);
                    } else {
                        var customer = db.customers.Where(u => u.app_user_id == item.user_2).FirstOrDefault();
                        var messinfor = db.message_info.Where(u => u.message_id == item.message_id).OrderByDescending(u => u.send_time).FirstOrDefault();
                        c.id = customer.app_user_id;
                        c.avatar = customer.avatar;
                        c.name = customer.fullname;
                        c.mess = messinfor.message;
                        c.time = messinfor.send_time;
                        list.Add(c);
                    }
                }
            }
            return PartialView("_getLeftChatBox",list.ToPagedList(pageNum,pagesize));
        }


    }
}