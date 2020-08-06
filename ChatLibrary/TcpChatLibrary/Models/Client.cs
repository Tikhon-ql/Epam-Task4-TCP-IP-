using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        //public string GetMessage()
        //{
        //    if (stream != null)
        //    {
        //        byte[] bytes = new byte[1024];
        //        string message = "";
        //        while (stream.DataAvailable)
        //        {
        //            int byteCount = stream.Read(bytes, 0, bytes.Length);
        //            message += Encoding.Unicode.GetString(bytes, 0, byteCount);
        //        }
        //        return message;
        //    }
        //    else
        //        throw new NullReferenceException();
        //}
        //public void Close()
        //{
        //    if (stream != null)
        //        stream.Close();
        //    if (client != null)
        //        client.Close();
        //}
        public bool Connect(IPAddress ip, int port)
        {
            try
            {
                client.Connect(ip, port);
                Thread reciveMessageThread = new Thread(ReciveMessage);
                Thread joiningThread = new Thread(Joining);
                reciveMessageThread.Start();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public void Joining()
        {
            string message = Name;
            while (true)
            {
                SendMessage(message);
            }
        }
        public void ReciveMessage()
        {
            if (stream != null)
            {
                byte[] data = new byte[1024];
                int bytCount = stream.Read(data, 0, data.Length);
                string message = Encoding.Unicode.GetString(data, 0, bytCount);
                RecivedMessageFromServer?.Invoke(this, message);
            }
            else
                throw new NullReferenceException();
        }
        private void SendMessage(string message)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(message);
            stream.Write(bytes, 0, bytes.Length);
        }
    }
