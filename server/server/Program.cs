using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace server
{
    class Program
    {
        const string adr = "127.0.0.1"; // я ничего не понял...
        const int port = 8888; // ... так что пусть будет такой ip
        static void Main(string[] args)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(adr), port);
            Socket sokc = new Socket(SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sokc.Bind(ip);
                sokc.Listen(10);
                Console.WriteLine("Ожидание подключения...");
                for (;;)
                {
                    Socket catcher = sokc.Accept();
                    StringBuilder mes = new StringBuilder();
                    int count = 0;
                    byte[] message = new byte[256];
                    do
                    {
                        count = catcher.Receive(message);
                        mes.Append(Encoding.Unicode.GetString(message, 0, count));
                    } while (catcher.Available > 0);
                    Console.WriteLine(DateTime.Now.ToLongTimeString() + ": " + message);
                    string check = "Сообщение отправлено";
                    message = Encoding.Unicode.GetBytes(check);
                    catcher.Send(message);
                    catcher.Shutdown(SocketShutdown.Both);
                    catcher.Close();
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
