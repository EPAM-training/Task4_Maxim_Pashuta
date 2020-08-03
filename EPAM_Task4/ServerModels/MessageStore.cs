using EPAM_Task4.ClientModels;
using System.Collections.Generic;

namespace EPAM_Task4.ServerModels
{
    /// <summary>
    /// Class for storing messages.
    /// </summary>
    public class MessageStore
    {
        /// <summary>
        /// Initialaze dictionary of client message.
        /// </summary>
        public MessageStore()
        {
            ClientMessageDictionary = new Dictionary<Client, List<string>>();
        }

        /// <summary>
        /// The property for storing a dictionary of client message.
        /// </summary>
        public Dictionary<Client, List<string>> ClientMessageDictionary { get; private set; }

        /// <summary>
        /// The method adds a message to the message store.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="client"></param>
        public void AddMessageToClient(string message, Client client)
        {
            if (!ClientMessageDictionary.ContainsKey(client))
            {
                var messageList = new List<string>();
                messageList.Add(message);
                ClientMessageDictionary.Add(client, messageList);
            }
            else
            {
                ClientMessageDictionary[client].Add(message);
            }
        }
    }
}
