using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageListLibrary.Models
{
    public class MessageList : Dictionary<string,List<string>>
    {
        public void AddMessage(string cl, string str)
        {
            if (TryGetValue(cl, out List<string> value))
            {
                value.Add(str);
            }
            else
                Add(cl, new List<string> { str });
        }
    }
}
