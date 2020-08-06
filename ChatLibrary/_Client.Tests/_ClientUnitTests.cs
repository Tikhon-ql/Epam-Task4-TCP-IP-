using System;
using System.CodeDom;
using System.Linq;
using System.Net;
using MessageListLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TcpChatLibrary.Models;

namespace _Client.Tests
{
    [TestClass]
    public class _ClientUnitTests
    {
        static Client client = new Client(IPAddress.Parse("127.0.0.1"), "Иван");
        static Server server = new Server(IPAddress.Parse("127.0.0.2"), 8080);
        static _ClientUnitTests()
        {
            client.Connect(IPAddress.Parse("127.0.0.2"), 8080);
        }
        
        static MessageList list = new MessageList();
        /// <summary>
        /// Check send message from client to server
        /// </summary>
        /// <param name="message">Message</param>
        [TestMethod]
        [DataRow("При вет")]
        [DataRow("Hleb.  ")]
        [DataRow("Ча ща:")]
        [DataRow("Perpen diku lyar/,;")]
        public void SendMessageToServer_expected_stranlsate_message(string message)
        {
            server.RecivedMessageFromClient += delegate (object sender, string mmessage)
            {
                list.AddMessage(sender.ToString(),mmessage);
                Assert.AreEqual(message, list.GetClientMessages(sender.ToString()).Last());
            };
            client.SendMessage(message);
        }
    }
}
