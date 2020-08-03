using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TCPIPLibrary.Another;

namespace TCPIPLibrary.MyServer
{
    public class Server
    {
        public int Port { get; private set; }
        public IPAddress Ip { get; private set; }

        Socket listner = new Socket(SocketType.Stream,ProtocolType.Tcp);
        public List<string> reciveMessages = new List<string>();
        public List<string> sendMessages = new List<string>();

        public Server(IPAddress ip,int port,int backlog = 1)
        {
            IPEndPoint ipEndPoint = new IPEndPoint(ip, port);
            listner.Bind(ipEndPoint);
            listner.Listen(backlog);
        }
        public event EventHandler<EventArgs> RecivedMessageFromClient = delegate (object sender, EventArgs eventArgs)
        {
            try
            {
                Server server = (Server)sender;
                Socket handler = server.listner.Accept();
                string message = "";
                byte[] bytes = new byte[256];
                int bytRes = handler.Receive(bytes);
                message = Encoding.UTF8.GetString(bytes, 0, bytRes);
                server.reciveMessages.Add(message);
                string result = Translator.Translate(message);
                bytes = Encoding.UTF8.GetBytes(result);
                message.ToLower();
                if (message != "конец" || message != "зе енд" || message != "konec" || message != "the end")
                {
                    handler.Send(bytes);
                    server.sendMessages.Add(result);
                }
                else
                {
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
            }
            catch
            {
                throw new Exception();
            }
        };
    }
}
