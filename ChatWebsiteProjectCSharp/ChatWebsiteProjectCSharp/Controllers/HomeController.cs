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
        public JsonResult getLeftChatBox(int? page) {
            int pagesize = 10;
            List<Chatbox> list = new List<Chatbox>();
            regsiterlist r = new regsiterlist();
            int pageNum = (page ?? 1);
            using (var db = new WebChat2Entities()) {
                string user = Session["UserID"].ToString();
                var listMess = db.messages.Where(u => u.user_1.ToString() == user || u.user_2.ToString() == user).ToList();
                r.totalcount = listMess.Count;
                listMess = listMess.ToPagedList(pageNum,pagesize).ToList();
                foreach (var item in listMess) {
                    Chatbox c = new Chatbox();
                    if (item.user_1.ToString() != user) {
                        var customer = db.customers.Where(u => u.app_user_id == item.user_1).FirstOrDefault();
                        var messinfor = db.message_info.Where(u => u.message_id == item.message_id).OrderByDescending(u => u.send_time).FirstOrDefault();
                        c.id = customer.app_user_id;
                        c.avatar = customer.avatar;
                        c.name = customer.fullname;
                        c.mess = messinfor.message;
                        c.time = caculateTime(messinfor.send_time.DateTime);
                        r.registerdata.Add(c);
                        list.Add(c);
                    } else {
                        var customer = db.customers.Where(u => u.app_user_id == item.user_2).FirstOrDefault();
                        var messinfor = db.message_info.Where(u => u.message_id == item.message_id).OrderByDescending(u => u.send_time).FirstOrDefault();
                        c.id = customer.app_user_id;
                        c.avatar = customer.avatar;
                        c.name = customer.fullname;
                        c.mess = messinfor.message;
                        c.time = caculateTime(messinfor.send_time.DateTime);
                        list.Add(c);
                    }
                }
                r.registerdata = list;
            }
            return Json(r,JsonRequestBehavior.AllowGet);
        }
        string caculateTime(DateTime b) {
            string s = "";
            DateTime a = DateTime.Now;
            TimeSpan interval = a.Subtract(b);
            if (interval.Days > 0) {
                s += interval.Days + " Ngày";
                if (interval.Hours > 0) {
                    s += interval.Hours + " Giờ Trước";
                }
            } else {
                if (interval.Hours > 0) {
                    s += interval.Hours + " Giờ";
                }
                if (interval.Minutes > 0) {
                    s += interval.Minutes + " Phút";
                }
                if (interval.Seconds > 0) {
                    s += interval.Seconds + " Giây Trước";
                }
            }

            return s;
        }


    }
}