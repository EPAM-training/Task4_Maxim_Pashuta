using EPAM_Task4;
using EPAM_Task4.ClientModels;
using EPAM_Task4.ServerModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPAM_Task4_NUnitTest.ServerModelsTest
{
    /// <summary>
    /// Class for testing the class Server.
    /// </summary>
    public class ServerNUnitTest
    {
        private Server _server;

        /// <summary>
        /// Initializes Server test object.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            string ipAddressServer = "192.168.0.2";
            int maskServer = 41;

            _server = new Server(ipAddressServer, maskServer);
        }

        /// <summary>
        /// The method tests the method SendMessage.
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="mask"></param>
        /// <param name="actualResult"></param>
        [TestCase("192.168.0.1", 24, "gsgsgs", "гсгсгс")]
        [TestCase("192.168.4.4", 86, "тгыатыг", "tgiatig")]
        public void Test_SendMessage(string ipAddress, int mask, string message, string actualResult)
        {
            List<NetworkElement> networkElements = new List<NetworkElement>()
            {
                new Client(ipAddress, mask),
                _server
            };

            ((Client)networkElements[0]).TranslatedMessage += Translator.TranslateMessage;

            string result = _server.SendMessage(ipAddress, mask, message, networkElements);

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests the method SendMessage throw ArguementException.
        /// </summary>
        /// <param name="exceptionMessage"></param>
        /// <param name="ipAddress"></param>
        /// <param name="mask"></param>
        /// <param name="message"></param>
        [TestCase("This address does not exist.", "192.168.1.1", 24, "gsgsgs")]
        [TestCase("You cannot send messages to yourself.", "192.168.0.2", 41, "тгыатыг")]
        public void Test_SendMessage_ThrowArgumentException(string exceptionMessage, string ipAddress, int mask, string message)
        {
            string ipAddressClient = "192.168.4.5";
            int maskClient = 56;

            List<NetworkElement> networkElements = new List<NetworkElement>()
            {
                new Client(ipAddressClient, maskClient),
                _server
            };

            ((Client)networkElements[0]).TranslatedMessage += Translator.TranslateMessage;

            Assert.That(() => _server.SendMessage(ipAddress, mask, message, networkElements), Throws.ArgumentException.With.Message.EqualTo(exceptionMessage));
        }
    }
}
