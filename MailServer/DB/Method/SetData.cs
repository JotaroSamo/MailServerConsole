
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
        public async Task<bool> SetDatas(string mess)
        {
            using (UserContext db = new UserContext())
            {
               var message = JsonSerializer.Deserialize<Message>(mess);

               await db.AddAsync(message);
                  await  db.SaveChangesAsync();
                    
            }
            return true;
        }
    }
}
