using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TCPIPLibrary.MyClient
{
    public class Client
    {
        public string Fio { get; set; }
        public IPAddress IP { get; private set; }
        Socket socket = new Socket(SocketType.Stream,ProtocolType.Tcp);
        public Client(string fio, IPAddress iP)
        {
            Fio = fio;
            IP = iP;
        }
        public bool Connect(int port)
        {
            try 
            {
                IPEndPoint ipEndPoint = new IPEndPoint(IP, port);
                socket.Connect(ipEndPoint);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Disconnect()
        {
            try
            {
                //False - cannot be reused
                //True - can be reused
                socket.Disconnect(true);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SendMessage(string message)
        {
            try
            {
                if (socket.IsBound)
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(message);
                    socket.Send(bytes);
                    message.ToLower();
                    if (message != "конец" || message != "зе енд" || message != "konec" || message != "the end")
                    {
                        Disconnect();
                    }
                }
                else
                    throw new Exception();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public event EventHandler<EventArgs> RecievedMessageFromServer = (object sender, EventArgs eventArgs) =>
        {
            Client client = (Client)sender;
            if (client.socket.IsBound)
            {
                string message = "";
                byte[] bytes = new byte[256];
                int resBytes = client.socket.Receive(bytes);
                message = Encoding.UTF8.GetString(bytes,0,resBytes);
            }
        };
    }
}
