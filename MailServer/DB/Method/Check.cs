using Server.DB.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DB.Method
{
    class Check
    {
        public bool Checked(string[] m)
        {
            using (UserContext db = new UserContext())
            {

                if (m[0]=="+")
                {
                    foreach (var item in db.Users)
                    {
                        if (item.Mail == m[1]&& item.Passowrd == m[2])
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
                        if (item.Mail == m[1])
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
                if (Checked(m)==true)
                {
                    User user = new User { Mail = m[1], Passowrd = m[2] };
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
