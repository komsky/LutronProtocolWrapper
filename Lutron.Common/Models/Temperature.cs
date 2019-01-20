using System;

namespace Lutron.Common.Models
{
    public class Temperature
    {
        private readonly int _temperature;

        public Temperature(int temperature)
        {
            if (temperature < 32) throw new ArgumentException(nameof(temperature));
            if (temperature > 212) throw new ArgumentException(nameof(temperature));
            _temperature = temperature;
        }

        public override string ToString()
        {
            return $"{_temperature}";
        }
    }
}