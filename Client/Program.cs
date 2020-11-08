using System.Threading;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {   
            try
            {
                Int32 port = 13000;
                IPAddress addr = IPAddress.Parse("26.206.223.145");
                TcpClient client = new TcpClient();
                client.Connect(addr.ToString(), port);
                NetworkStream stream = client.GetStream();

                Byte[] bytes = new Byte[256];
                String data = "A";
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                stream.Write(msg, 0, msg.Length);

                int i;
                while((i = stream.Read(bytes, 0, bytes.Length))!=0)
                {
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Received: {0}", data);
          
                    if (data == ":)")
                        data = "A";

                    msg = System.Text.Encoding.ASCII.GetBytes(data);
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine("Sent: {0}", data);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }
    }
}
