using MailServer.DB.Method;
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
        public async Task<byte[]> GetRequest(string[] message)
        {
            Check check;
            SetData setData;
            GetDatesUser getDatesUser;
            Delete delete;
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
                    if (await check.Registration(message) == true)
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
                    data = Encoding.Unicode.GetBytes(await getDatesUser.Data(message[1]));
                    break;
                case "Save data":
                    setData = new SetData();
                  await  setData.SetDatas(message[1]);
                    break;
                case "Delete":
                    delete = new Delete();
                   await delete.DeleteData(message[1]);
                    break;
                default:
                    break;
            }
            Console.WriteLine(data);
            return data;
        }
    }
}
