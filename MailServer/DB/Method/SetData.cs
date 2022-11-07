
using Server.DB;
using Server.DB.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
namespace ServerMail.DB.Method
{
    public class SetData
    {
        public bool SetDatas(string mess)
        {
            using (UserContext db = new UserContext())
            {

                db.Messeges.Add(JsonSerializer.Deserialize<Messege>(mess));
                    db.SaveChanges();
                    
            }
            return true;
        }
    }
}
