using EPAM_Task4;
using EPAM_Task4.ClientModels;
using EPAM_Task4.ServerModels;
using NUnit.Framework;
using System.Collections.Generic;

namespace EPAM_Task4_NUnitTest.ClientModesTest
{
    /// <summary>
    /// Class for testing the class Client.
    /// </summary>
    public class ClientNUnitTest
    {
        private Client _client;

        /// <summary>
        /// Initializes Client test object.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            string ipAddressClient = "192.168.0.2";
            int maskClient = 41;

            _client = new Client(ipAddressClient, maskClient);
        }

        /// <summary>
        /// The method tests the method SendMessage.
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="mask"></param>
        /// <param name="actualResult"></param>
        [TestCase("192.168.0.1", 24, "gsgsgs")]
        [TestCase("192.168.4.4", 86, "тгыатыг")]
        public void Test_SendMessage(string ipAddress, int mask, string actualResult)
        {
            var messageStore = new MessageStore();

            var networkElements = new List<NetworkElement>()
            {
                new Server(ipAddress, mask),
                _client
            };

            ((Server)networkElements[0]).AddedMessageToClient += messageStore.AddMessageToClient;

            _client.SendMessage(ipAddress, mask, actualResult, networkElements);

            string result = messageStore.ClientMessageDictionary[_client][0];

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
            string ipAddressServer = "192.168.4.5";
            int maskServer = 56;

            var messageStore = new MessageStore();

            var networkElements = new List<NetworkElement>()
            {
                new Server(ipAddressServer, maskServer),
                _client
            };

            ((Server)networkElements[0]).AddedMessageToClient += messageStore.AddMessageToClient;

            Assert.That(() => _client.SendMessage(ipAddress, mask, message, networkElements), Throws.ArgumentException.With.Message.EqualTo(exceptionMessage));
        }
    }
}
