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
    public class Server
    {
        List<TcpClient> connectedClients = new List<TcpClient>();

        TcpListener listner = null;
        NetworkStream stream = null;
        public IPAddress Ip { get;private set; }
        public int Port { get; private set; }
     
        public delegate string MyEventHandler(object sender, string message);
        public event MyEventHandler RecivedMessageFromClient;

        public Server(IPAddress ip, int port)
        {
            Ip = ip;
            Port = port;
            listner = new TcpListener(ip,port);
            listner.Start();
            Thread listenThread = new Thread(StartListen);
            listenThread.Start();
        }

        public void AddConnection(TcpClient client)
        {
            connectedClients.Add(client);
        }

        public void TellAllClients(string message)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(message);
            foreach (TcpClient item in connectedClients)
            {
                item.GetStream().Write(bytes, 0, bytes.Length);
            }
        }
        public void StartListen()
        {
            while (true)
            {
                TcpClient client = listner.AcceptTcpClient();
                AddConnection(client);
                Thread thread = new Thread(ReciveMessage);
                thread.Start(client);
            }
        }
        private void ReciveMessage(object client)
        {
            if(client != null)
            {
                using (TcpClient tcpClient = (TcpClient)client)
                {
                    string message = "";
                    stream = tcpClient.GetStream();
                    while (true)
                    {
                        ///
                        message = GetMessage();
                    }
                }       
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetMessage()
        {
            StringBuilder builder = new StringBuilder();
            byte[] bytes = new byte[1024];
            do
            {
                int byteCount = stream.Read(bytes, 0, bytes.Length);
                builder.Append(Encoding.Unicode.GetString(bytes, 0, byteCount));
            }
            while (stream.DataAvailable);
            RecivedMessageFromClient?.Invoke(this, builder.ToString());
            return builder.ToString();
        }
    }
}
