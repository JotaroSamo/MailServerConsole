using Server.DB.Method;
using ServerMail.DB.Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerMail.Network
{
    public class ClientObject
    {
        public TcpClient client;
        public ClientObject(TcpClient tcpClient)
        {
            client = tcpClient;
        }

        public void Process()
        {
            NetworkStream stream = null;
            try
            {
                stream = client.GetStream();
                byte[] data = new byte[512]; // буфер для получаемых данных
                while (true)
                {
                    // получаем сообщение
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                        Console.WriteLine(bytes);
                        Console.WriteLine(builder.ToString());
                    }
                    while (stream.DataAvailable);
                    

                    string [] message = builder.ToString().Split('`');
                    Check check;
                    SetData setData;
                    //GetDatesUser getDatesUser;
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
                        //case "GetData":
                        //    GetDatesUser datesUser = new GetDatesUser();
                        //    data = Encoding.Unicode.GetBytes(datesUser.Data(message[1]));
                            //break;
                        case "Save data":
                           setData = new SetData();
                            setData.SetDatas(message[1]);
                            break;
                         
                        default:
                            break;
                    }
                    stream.Write(data, 0, data.Length);
                    break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }
    }
}
