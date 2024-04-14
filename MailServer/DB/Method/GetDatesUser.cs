
using Microsoft.EntityFrameworkCore;
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
        public async Task<string> Data(string Mail)
        {
            string perm;
            using (UserContext db = new UserContext())
            {
                var message =
                perm = JsonSerializer.Serialize(await db.Messeges.Where(c => c.IdWhom == Mail|| c.IdHow == Mail).Include(c=>c.Files).ToListAsync());
            }
            return perm;
        }
    }
}

