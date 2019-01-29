using System;

namespace Lutron.Common.Models
{
    public class NegativeDriftCelsius
    {
        private readonly int _drift;

        public NegativeDriftCelsius(int drift)
        {
            if (drift < 0) throw new ArgumentException(nameof(drift));
            if (drift > 8 && drift != 255) throw new ArgumentException(nameof(drift));
            _drift = drift;
        }

        public override string ToString()
        {
            return $"{_drift}";
        }
    }
}