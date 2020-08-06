using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageListLibrary.Models
{
    public class MessageList : Dictionary<string,List<string>>
    {
        /// <summary>
        /// Add message method
        /// </summary>
        /// <param name="cl"></param>
        /// <param name="str"></param>
        public void AddMessage(string cl, string str)
        {
            if (TryGetValue(cl, out List<string> value))
            {
                value.Add(str);
            }
            else
                Add(cl, new List<string> { str });
        }
        /// <summary>
        /// Get client's messages method
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public List<string> GetClientMessages(string client)
        {
            if (TryGetValue(client, out List<string> value))
            {
                return value;
            }
            else
                throw new Exception("Данный клиент не существует, или не отправлял ни одного сообщения");
        }
    }
}
