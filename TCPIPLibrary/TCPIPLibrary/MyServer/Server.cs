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
        MessageList messageList = new MessageList();

        public Server(IPAddress ip,int port,int backlog = 1)
        {
            IPEndPoint ipEndPoint = new IPEndPoint(ip, port);
            listner.Bind(ipEndPoint);
            listner.Listen(backlog);
        }
        public bool ReciveMessage()
        {
            try
            {
                Socket handler = listner.Accept();

                string message = "";
                byte[] bytes = new byte[256];
                int bytRes = handler.Receive(bytes);
                message = Encoding.UTF8.GetString(bytes, 0, bytRes);

                string[] strs = message.Split(':');
                messageList.Add(strs[0], strs[1]);

                string result = Translator.Translate(strs[1]);
                bytes = Encoding.UTF8.GetBytes(result);

                strs[1].ToLower();
                if (strs[1] != "конец" || strs[1] != "зе енд" || strs[1] != "konec" || strs[1] != "the end")
                {
                    handler.Send(bytes);
                }
                else
                {
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }
                RecivedMessageFromClient?.Invoke(this, result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public delegate void MyEventHandler(object sender, string message);
        public event MyEventHandler RecivedMessageFromClient;
    }
}
