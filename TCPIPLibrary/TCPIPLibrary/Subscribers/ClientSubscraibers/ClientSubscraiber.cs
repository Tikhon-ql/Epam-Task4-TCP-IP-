using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TCPIPLibrary.MyClient;

namespace TCPIPLibrary.Subscribers.ClientSubscraibers
{
    public class ClientSubscraiber
    {
        Client client = null;
        List<string> messages = new List<string>();
        public ClientSubscraiber(string Fio,IPAddress ip)
        {
            client = new Client(Fio, ip);
        }
        public void Subscraide()
        {
            if(client != null)
            {
                client.RecievedMessageFromServer += delegate (object sender, EventArgs e)
                {

                };
            }
            
        }
        public void Unsubscribe()
        {
        }
    }
}
