using MailServer.Processing;
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
                byte[] data = new byte[512];
                while (true)
                {
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


                    string[] message = builder.ToString().Split('`');
                    Request request = new Request();
                    data= request.GetRequest(message);
                    if (data!=null)
                    {
                        stream.Write(data, 0, data.Length);
                    }
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
