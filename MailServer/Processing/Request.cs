using Server.DB.Method;
using ServerMail.DB.Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailServer.Processing
{
    public class Request
    {
        public byte[] GetRequest(string[] message)
        {
            Check check;
            SetData setData;
            GetDatesUser getDatesUser;
            byte[] data=null;
            switch (message[0])
            {
                case "+":
                    check = new Check();
                    if (check.Checked(message) == true)
                    {
                        data = Encoding.Unicode.GetBytes("+");
                    }
                    else
                    {
                        data = Encoding.Unicode.GetBytes("-");
                    }
                    break;
                case "AddUser":
                    check = new Check();
                    if (check.Registration(message) == true)
                    {
                        data = Encoding.Unicode.GetBytes("+");
                    }
                    else
                    {
                        data = Encoding.Unicode.GetBytes("-");
                    }
                    break;
                case "Get Data":
                    getDatesUser = new GetDatesUser();
                    data = Encoding.Unicode.GetBytes(getDatesUser.Data(message[1]));
                    break;
                case "Save data":
                    setData = new SetData();
                    setData.SetDatas(message[1]);
                    break;

                default:
                    break;
            }
            return data;
        }
    }
}
