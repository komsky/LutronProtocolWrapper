using System;

namespace Lutron.Common.Models
{
    public class NegativeDriftFahrenheit
    {
        private readonly int _drift;

        public NegativeDriftFahrenheit(int drift)
        {
            if (drift < 0) throw new ArgumentException(nameof(drift));
            if (drift > 15 && drift != 255) throw new ArgumentException(nameof(drift));
            _drift = drift;
        }

        public override string ToString()
        {
            return $"{_drift}";
        }
    }
}