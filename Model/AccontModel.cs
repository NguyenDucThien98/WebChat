using Model.user;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public class AccontModel {
        private ChatDbContext contex = null;
        public AccontModel() {
            contex = new ChatDbContext();
        }
        public bool Login(string user,string pass) {
            object[] ob = {
                new SqlParameter("@username",user),
                new SqlParameter("@encrypted_password",pass),
            };
            var res = contex.Database.SqlQuery<bool>("Login @username,@encrypted_password",ob).SingleOrDefault();
            return res;
        }
    }
}
