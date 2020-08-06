using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpChatLibrary.Models
{
    public class Client
    {
        public IPAddress Ip { get; set; }
        public NetworkStream stream { get; private set; }
        TcpClient client;
        public string Name { get; set; }

        public delegate void MyEventHandler(object sender, string message);
        public event MyEventHandler RecivedMessageFromServer;

        public Client(IPAddress iP, string name)
        {
            client = new TcpClient();
            Name = name;
            Ip = iP;
        }

        public bool Connect(IPAddress ip, int port)
        {
            try
            {
                client.Connect(ip, port);
                Thread reciveMessageThread = new Thread(ReciveMessage);
                Thread joiningThread = new Thread(Joining);
                reciveMessageThread.Start();
                joiningThread.Start();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void Joining()
        {
            string message = "";
            while (true)
            {
                SendMessage(message);
            }
        }
        private void ReciveMessage()
        {
            while (true)
            {
                StringBuilder builder = new StringBuilder();
                byte[] bytes = new byte[1024];
                do
                {
                    int byteCount = stream.Read(bytes, 0, bytes.Length);
                    builder.Append(Encoding.Unicode.GetString(bytes, 0, byteCount));
                }
                while (stream.DataAvailable);
                RecivedMessageFromServer?.Invoke(this,builder.ToString());
            }
        }
        private void SendMessage(string message)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(message);
            stream = client.GetStream();
            stream.Write(bytes, 0, bytes.Length);
        }
    }
}
