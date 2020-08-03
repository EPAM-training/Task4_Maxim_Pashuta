using EPAM_Task4.ClientModels;
using EPAM_Task4.ServerModels;
using NUnit.Framework;

namespace EPAM_Task4_NUnitTest.ServerModelsTest
{
    /// <summary>
    /// Class for testing class MessageStore.
    /// </summary>
    public class MessageStoreNUnitTest
    {
        private MessageStore _messageStore;

        /// <summary>
        /// Initializes MessageStore test object.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _messageStore = new MessageStore();
        }

        /// <summary>
        /// The method tests a method AddMessageToClient.
        /// </summary>
        /// <param name="ipAddressClient"></param>
        /// <param name="maskClient"></param>
        /// <param name="actualResult"></param>
        [TestCase("192.168.0.3", 26, "bfsgbsj")]
        [TestCase("192.168.3.1", 47, "пштвтшвшв")]
        public void Test_AddMessageToClient(string ipAddressClient, int maskClient, string actualResult)
        {
            var client = new Client(ipAddressClient, maskClient);

            _messageStore.AddMessageToClient(actualResult, client);

            var result = _messageStore.ClientMessageDictionary[client][0];
            Assert.AreEqual(result, actualResult);
        }
    }
}
