using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPIPLibrary.Another
{
    public class MessageList:Dictionary<string,string>
    {
        public List<string> GetMessagesOfOneClient(string fioClient)
        {
            return this.Where(i => i.Key == fioClient).Select(i => i.Value).ToList();
        }
    }
}
