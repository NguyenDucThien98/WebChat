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
                r.totalCountLeftBox = listMess.Count;
                listMess = listMess.ToPagedList(pageNum,pagesize).ToList();

                foreach (var item in listMess) {
                    Chatbox c = new Chatbox();
                    if (item.user_1.ToString() != user) {
                        var customer = db.customers.Where(u => u.app_user_id == item.user_1).FirstOrDefault();
                        var messinfor = db.message_info.Where(u => u.message_id == item.message_id).OrderByDescending(u => u.send_time).FirstOrDefault();
                        c.id = item.message_id.ToString();
                        c.avatar = customer.avatar;
                        c.name = customer.fullname;
                        c.mess = messinfor.message;
                        c.time = caculateTime(messinfor.send_time.DateTime);
                        list.Add(c);
                    } else {
                        var customer = db.customers.Where(u => u.app_user_id == item.user_2).FirstOrDefault();
                        var messinfor = db.message_info.Where(u => u.message_id == item.message_id).OrderByDescending(u => u.send_time).FirstOrDefault();
                        c.id = item.message_id.ToString();
                        c.avatar = customer.avatar;
                        c.name = customer.fullname;
                        c.mess = messinfor.message;
                        c.time = caculateTime(messinfor.send_time.DateTime);
                        list.Add(c);
                    }
                }
                r.registerDataLeftBox = list;
            }
            return Json(r,JsonRequestBehavior.AllowGet);
        }
        public JsonResult getRightChatBox(int? page,string messID) {
            int pagesize = 10;
            List<ChatBoxInfor> list = new List<ChatBoxInfor>();
            List<headerRightChatBox> list2 = new List<headerRightChatBox>();
            regsiterlist r = new regsiterlist();
            int pageNum = (page ?? 1);
            using (var db = new WebChat2Entities()) {
                string user = Session["UserID"].ToString();
                var listMess = db.message_info.Where(u => u.message_id.ToString() == messID).OrderByDescending(u => u.send_time).ToList();
                r.totalCountRightBox = listMess.Count;
                listMess = listMess.ToPagedList(pageNum,pagesize).Reverse().ToList();
                var sent_Cus = db.customers.Where(u => u.app_user_id.ToString() == user).FirstOrDefault();
                customer reserve_Cus = null;
                foreach (var item in listMess) {
                    ChatBoxInfor c = new ChatBoxInfor();
                    headerRightChatBox h = new headerRightChatBox();
                    if (reserve_Cus == null) {
                        if (item.cus_send_id.ToString() != user) {
                            reserve_Cus = db.customers.Where(u => u.app_user_id == item.cus_send_id).FirstOrDefault();
                        } else {
                            reserve_Cus = db.customers.Where(u => u.app_user_id == item.cus_receive_id).FirstOrDefault();
                        }
                        h.messid = messID;
                        h.name = reserve_Cus.fullname;
                        h.id = reserve_Cus.app_user_id.ToString();
                        h.avt = reserve_Cus.avatar;
                        h.onlineStatus = isOnline(reserve_Cus.last_online.DateTime);
                        list2.Add(h);
                    }
                    if (item.cus_send_id.ToString() == user) {
                        c.userID = item.cus_send_id.ToString();
                        c.userAVT = sent_Cus.avatar;
                    } else {
                        c.userID = item.cus_receive_id.ToString();
                        c.userAVT = reserve_Cus.avatar;
                    }
                    c.textChat = item.message;
                    c.time = caculateTime(item.send_time.DateTime);
                    list.Add(c);

                }
                r.header = list2;
                r.registerDataRightBox = list;
            }
            return Json(r,JsonRequestBehavior.AllowGet);
        }
        string isOnline(DateTime d) {
            if (DateTime.Now.Subtract(d).Minutes < 10) {
                return "Online";
            } else {
                return "Online " + caculateTime(d);
            }
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