using System;
using System.Collections.Generic;
using System.Data;
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
        /// <summary>
        /// Message recived event
        /// </summary>
        /// <param name="sender">Sender of message</param>
        /// <param name="message">Messgae</param>
        public delegate void MyEventHandler(object sender, string message);
        public event MyEventHandler RecivedMessageFromServer;

        public Client(IPAddress iP, string name)
        {
            client = new TcpClient();
            Name = name;
            Ip = iP;
        }
        /// <summary>
        /// Connection to the server
        /// </summary>
        /// <param name="ip">Ip adress of server</param>
        /// <param name="port">Port of server</param>
        /// <returns></returns>
        public bool Connect(IPAddress ip, int port)
        {
            try
            {
                client.Connect(ip, port);
                Thread reciveMessageThread = new Thread(ReciveMessage);
                reciveMessageThread.Start();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Reciveing messages method
        /// </summary>
        private void ReciveMessage()
        {
            while (true)
            {
                if(stream != null)
                {
                    StringBuilder builder = new StringBuilder();
                    byte[] bytes = new byte[1024];
                    do
                    {
                        if (stream.CanRead)
                        {
                            int byteCount = stream.Read(bytes, 0, bytes.Length);
                            builder.Append(Encoding.Unicode.GetString(bytes, 0, byteCount));
                        }
                    }
                    while (stream.DataAvailable);
                    RecivedMessageFromServer?.Invoke(this, builder.ToString());
                }
            }
        }
        /// <summary>
        /// Sending message method
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            if(client != null && message != "")
            {
                message = Name + ":" + message;
                byte[] bytes = Encoding.Unicode.GetBytes(message);
                stream = client.GetStream();
                stream.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
