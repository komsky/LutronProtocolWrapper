using System;

namespace Lutron.Common.Models
{
    public class TemperatureCelsius
    {
        private readonly int _temperature;

        public TemperatureCelsius(int temperature)
        {
            if (temperature < 0) throw new ArgumentException(nameof(temperature));
            if (temperature > 100) throw new ArgumentException(nameof(temperature));
            _temperature = temperature;
        }

        public override string ToString()
        {
            return $"{_temperature}";
        }
    }
}