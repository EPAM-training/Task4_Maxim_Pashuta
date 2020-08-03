using EPAM_Task4.ServerModels;
using System;
using System.Collections.Generic;

namespace EPAM_Task4.ClientModels
{
    /// <summary>
    /// Class for working the class Client.
    /// </summary>
    public class Client : NetworkElement
    {
        /// <summary>
        /// The delegate to translate message.
        /// </summary>
        public Func<string, string> TranslatedMessage;

        /// <summary>
        /// Constructor to initialize the client via IP address, mask and delegate initialization.
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="mask"></param>
        public Client(string ipAddress, int mask) : base(ipAddress, mask)
        {
        }

        /// <summary>
        /// The method sends message to the specified address.
        /// </summary>
        /// <param name="ipAddress">Ip Address</param>
        /// <param name="mask">Mask</param>
        /// <param name="message">Message</param>
        /// <param name="networkElementsCollection">Collection of servers and clients</param>
        public void SendMessage(string ipAddress, int mask, string message, IEnumerable<NetworkElement> networkElementsCollection)
        {
            foreach (NetworkElement element in networkElementsCollection)
            {
                if ((element.IpAddress == ipAddress) && (element.Mask == mask))
                {
                    if ((ipAddress == IpAddress) && (mask == Mask))
                    {
                        throw new ArgumentException("You cannot send messages to yourself.");
                    }

                    var server = (Server)element;
                    server.AddedMessageToClient(message, this);
                    return;
                }
            }

            throw new ArgumentException("This address does not exist.");
        }
    }
}
