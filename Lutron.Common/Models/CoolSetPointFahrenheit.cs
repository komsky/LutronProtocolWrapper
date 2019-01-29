using System;

namespace Lutron.Common.Models
{
    public class CoolSetPointFahrenheit
    {
        private readonly int _coolSetPoint;

        public CoolSetPointFahrenheit(int coolSetPoint)
        {
            if (coolSetPoint < 32) throw new ArgumentException(nameof(coolSetPoint));
            if (coolSetPoint > 212 && coolSetPoint != 255) throw new ArgumentException(nameof(coolSetPoint));
            _coolSetPoint = coolSetPoint;
        }

        public override string ToString()
        {
            return $"{_coolSetPoint}";
        }
    }
}