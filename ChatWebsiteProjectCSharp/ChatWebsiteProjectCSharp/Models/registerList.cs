﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatWebsiteProjectCSharp.Models {
  

    public class regsiterlist {

        public List<Chatbox> registerDataLeftBox {
            get; set;
        }

        public int totalCountLeftBox {
            get; set;
        }
        public List<ChatBoxInfor> registerDataRightBox {
            get; set;
        }
        public int totalCountRightBox {
            get; set;
        }
        public List<headerRightChatBox> header {
            get; set;
        }

    }

}
