using System;
using System.Net;

namespace Lutron.Common.Models
{
    public class IpAddress
    {
        private readonly string _ipAddress;

        public IpAddress(string ipAddress)
        {
            if (IPAddress.TryParse(ipAddress, out _) is false) throw new ArgumentException(nameof(ipAddress));
            _ipAddress = ipAddress;
        }

        public override string ToString()
        {
            return $"{_ipAddress}";
        }
    }
}