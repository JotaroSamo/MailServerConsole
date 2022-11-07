
using Server.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServerMail.DB.Method
{
    public class GetDatesUser
    {
        public string Data(string Mail)
        {
            string perm;
            using (UserContext db = new UserContext())
            {

                perm = JsonSerializer.Serialize(db.Messeges.Where(c => c.IdWhom == Mail));
            }
            return perm;
        }
    }
}

