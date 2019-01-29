using System;

namespace Lutron.Common.Models
{
    public class CoolSetPointCelsius
    {
        private readonly int _coolSetPoint;

        public CoolSetPointCelsius(int coolSetPoint)
        {
            if (coolSetPoint < 0) throw new ArgumentException(nameof(coolSetPoint));
            if (coolSetPoint > 100 && coolSetPoint != 255) throw new ArgumentException(nameof(coolSetPoint));
            _coolSetPoint = coolSetPoint;
        }

        public override string ToString()
        {
            return $"{_coolSetPoint}";
        }
    }
}