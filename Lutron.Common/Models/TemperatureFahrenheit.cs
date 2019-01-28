using System;

namespace Lutron.Common.Models
{
    public class TemperatureFahrenheit
    {
        private readonly int _temperature;

        public TemperatureFahrenheit(int temperature)
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