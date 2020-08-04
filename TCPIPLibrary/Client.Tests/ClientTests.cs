using System;
using System.Net;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TCPIPLibrary.Another;
using TCPIPLibrary.MyClient;
using TCPIPLibrary.MyServer;

namespace MyClient.Tests
{
    [TestClass]
    public class ClientTests
    {
        static IPHostEntry hostEntry = Dns.GetHostEntry("localhost");
        static Server server = null;
        static Client client = null;
       
        static ClientTests()
        {
            server = new Server(hostEntry.AddressList[0], 8080);
            client = new Client("Петров Петр Петрович", hostEntry.AddressList[1]);
        }
        [TestCase("Hello")]
        [TestCase("Хелло")]
        [TestCase("Пока")]
        [TestCase("Гуд бай")]
        [TestMethod]
        public void SendMessageToServer(string message)
        {
            client.Connect(hostEntry.AddressList[0],8080);
            bool res = client.SendMessage(message);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(res);
            client.Disconnect();
        }
        [TestMethod]
        //[TestCase("Hello")]
        //[TestCase("Хелло")]
        //[TestCase("Пока")]
        //[TestCase("Гуд бай")]
        public void ReciveMessageFromServer()
        {
            //arrange
            client.Connect(hostEntry.AddressList[0], 8080);
         
            string expected = Translator.Translate("Hello");
            client.RecievedMessageFromServer += (object sender, string actual) =>
            {
                //assert
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, actual);
            };

            //act
            client.SendMessage("Hello");
            client.ReciveMessage();
        }
    }
}
