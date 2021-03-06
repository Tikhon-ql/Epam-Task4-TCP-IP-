﻿using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TcpChatLibrary.Models;
using TranslatorLibrary.Models;

namespace _Server.Tests
{
    [TestClass]
    public class _ServerUnitTests
    {
        /// <summary>
        /// Server
        /// </summary>
        static Client client = new Client(IPAddress.Parse("127.0.0.3"), "Иван");
        /// <summary>
        /// Client
        /// </summary>
        static Server server = new Server(IPAddress.Parse("127.0.0.4"), 8080);
        static _ServerUnitTests()
        {
            client.Connect(IPAddress.Parse("127.0.0.4"), 8080);
        }
        /// <summary>
        /// Check send message from server to client
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="expectedMessage">Expected message</param>
        [TestMethod]
        [DataRow("При вет", "Pri vet")]
        [DataRow("Хлеб.  ", "Hleb.  ")]
        [DataRow("Ча ща:", "Cha scha:")]
        [DataRow("Перпен дику ляр/,;", "Perpen diku lyar/,;")]
        public void SendMessageToClient_expected_tranlsate_message(string message, string expectedMessage)
        {
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
