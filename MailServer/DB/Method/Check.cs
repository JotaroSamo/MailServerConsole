using Server.DB.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server.DB.Method
{
    class Check
    {
        public bool Checked(string [] m)
        {
            using (UserContext db = new UserContext())
            {
                User user = JsonSerializer.Deserialize<User>(m[1]);
                if (m[0]=="+")
                {
                    foreach (var item in db.Users)
                    {
                        if (item.Mail == user.Mail&& item.Passowrd == user.Passowrd)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                else
                {
                    foreach (var item in db.Users)
                    {
                        if (item.Mail == user.Mail)
                        {
                            return false;
                        }
                    }
                    return true;
                }
               
            }
        }
        public bool Registration(string[] m)
        {

            using (UserContext db = new UserContext())
            {
                User users = JsonSerializer.Deserialize<User>(m[1]);
                if (Checked(m)==true)
                {
                    User user = new User { Mail = users.Mail, Passowrd = users.Passowrd };
                    db.Users.Add(user);
                    db.SaveChanges();
                    return true;
                   
                }
                else
                {
                    return false;
                }
       
            }
        }
    }
}
