using EPAM_Task4.ClientModels;
using System;
using System.Collections.Generic;

namespace EPAM_Task4.ServerModels
{
    /// <summary>
    /// Class for working with class Server.
    /// </summary>
    public class Server : NetworkElement
    {
        /// <summary>
        /// The delegate to add a message to the client.
        /// </summary>
        public Action<string, Client> AddedMessageToClient;

        /// <summary>
        /// Constructor to initialize server through a ip address, a mask and to initialize delegate.
        /// </summary>
        /// <param name="ipAddress">Ip Address</param>
        /// <param name="mask">Mask</param>
        public Server(string ipAddress, int mask) : base(ipAddress, mask)
        {
        }

        /// <summary>
        /// The method sends message to the specified address.
        /// </summary>
        /// <param name="ipAddress">Ip Address</param>
        /// <param name="mask">Mask</param>
        /// <param name="message">Message</param>
        /// <param name="networkElementsCollection">Collection of servers and clients</param>
        /// <returns>Translated message</returns>
        public string SendMessage(string ipAddress, int mask, string message, IEnumerable<NetworkElement> networkElementsCollection)
        {
            foreach (NetworkElement element in networkElementsCollection)
            {
                if ((element.IpAddress == ipAddress) && (element.Mask == mask))
                {
                    if ((ipAddress == IpAddress) && (mask == Mask))
                    {
                        throw new ArgumentException("You cannot send messages to yourself.");
                    }

                    var client = (Client)element;
                    return client.TranslatedMessage(message);
                }
            }

            throw new ArgumentException("This address does not exist.");
        }
    }
}
