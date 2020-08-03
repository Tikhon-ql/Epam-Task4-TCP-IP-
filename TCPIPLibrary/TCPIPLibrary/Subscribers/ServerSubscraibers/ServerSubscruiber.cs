using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TCPIPLibrary.MyServer;

namespace TCPIPLibrary.Subscribers
{
    public class ServerSubscruiber
    {
        Server server = null;
        List<string> messages = new List<string>();
        public ServerSubscruiber(IPAddress ip, int port)
        {
            server = new Server(ip,port);
        }
        public void Subscraide()
        {
            if(server != null)
            {
                server.RecivedMessageFromClient += delegate (object sender, EventArgs e)
                {

                };
            }
        }
        public void Unsubscribe()
        {
        }
    }
}
