using Server.DB;
using Server.DB.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MailServer.DB.Method
{
    public class Delete
    {
        public void DeleteData(string a)
        {
            using (UserContext db = new UserContext())
            {
                int b = int.Parse(a);
                Messege del = db.Messeges.Where(c => c.Id == b).First();
                db.Messeges.Remove(del);
                db.SaveChanges();
            }
        }
    }
}
