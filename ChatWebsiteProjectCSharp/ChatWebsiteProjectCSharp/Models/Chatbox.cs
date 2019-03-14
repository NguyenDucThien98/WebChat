using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatWebsiteProjectCSharp.Models {
    public class Chatbox {
        public Guid id {
            get; set;
        }
        public string avatar {
            get; set;
        }
        public string name {
            get; set;
        }
        public string mess {
            get; set;
        }
        public DateTimeOffset time {
            get; set;
        }
    }
}