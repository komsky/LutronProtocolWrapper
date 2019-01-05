using System;
using System.Text.RegularExpressions;

namespace Lutron.Common.Models
{
    public class SerialNumber
    {
        private readonly string _serialNumber;

        public SerialNumber(string serialNumber)
        {
            var regex = new Regex("[0-9A-F]{8}");
            var match = regex.Match(serialNumber);
            if (!match.Success) throw new ArgumentException(nameof(serialNumber));
            _serialNumber = serialNumber;
        }

        public override string ToString()
        {
            return $"{_serialNumber}";
        }
    }
}