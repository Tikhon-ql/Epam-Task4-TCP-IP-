using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TcpChatLibrary.Models;
using TranslatorLibrary.Models;

namespace _Server.Tests
{
    [TestClass]
    public class _ServerUnitTests
    {
        Client client = new Client(IPAddress.Parse("127.0.0.1"), "Иван");
        Server server = new Server(IPAddress.Parse("127.0.0.2"), 8080);
        [TestMethod]
        [DataRow("При вет", "Pri vet")]
        [DataRow("Хлеб.  ", "Hleb.  ")]
        [DataRow("Ча ща:", "Cha scha:")]
        [DataRow("Перпен дику ляр/,;", "Perpen diku lyar/,;")]
        public void SendMessageToClient_expected_tranlsate_message(string message, string expectedMessage)
        {
            client.Connect(IPAddress.Parse("127.0.0.2"), 8080);
            client.RecivedMessageFromServer += (sender, mmessage) =>
            { 
                string actual = Translator.Translate(mmessage);
                //assert
                Assert.AreEqual(expectedMessage, actual);
            };
            //act
            server.TellAllClients(message);
        }
    }
}
