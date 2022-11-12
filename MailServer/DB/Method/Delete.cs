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
                db.Messeges.Remove(db.Messeges.Where(c => c.Id == int.Parse(a)).First());
                db.SaveChanges();
            }
        }
    }
}
