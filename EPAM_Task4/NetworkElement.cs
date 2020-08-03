using System;
using System.Collections.Generic;

namespace EPAM_Task4
{
    /// <summary>
    /// Class for working with servers and clients.
    /// </summary>
    public class NetworkElement
    {
        /// <summary>
        /// Constructor to initialize a network element through a ip address and a mask;
        /// </summary>
        /// <param name="ipAddress">Ip Address</param>
        /// <param name="mask">Mask</param>
        public NetworkElement(string ipAddress, int mask)
        {
            IpAddress = ipAddress;
            Mask = mask;
        }

        /// <summary>
        /// The property for storing ip address.
        /// </summary>
        public string IpAddress { get; }

        /// <summary>
        /// The property for storing port.
        /// </summary>
        public int Mask { get; }

        /// <summary>
        /// Method for equal the current object with the specified object.
        /// </summary>
        /// <param name="obj">Any object</param>
        /// <returns>True or False</returns>
        public override bool Equals(object obj)
        {
            if (GetType() != obj.GetType())
            {
                return false;
            }

            var networkElement = (NetworkElement)obj;

            return ((networkElement.IpAddress == IpAddress) && (networkElement.Mask == Mask));
        }

        /// <summary>
        /// The method calculates the hash code for the current object.
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return (IpAddress.GetHashCode() ^ Mask);
        }

        /// <summary>
        /// The method creates and returns a string representation of the object.
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return string.Format($"IpAddres: {IpAddress}\n" +
                                 $"Mask: {Mask}");
        }
    }
}
