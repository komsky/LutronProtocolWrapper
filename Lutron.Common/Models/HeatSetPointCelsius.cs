using System;

namespace Lutron.Common.Models
{
    public class HeatSetPointCelsius
    {
        private readonly int _heatSetPoint;

        public HeatSetPointCelsius(int heatSetPoint)
        {
            if (heatSetPoint < 0) throw new ArgumentException(nameof(heatSetPoint));
            if (heatSetPoint > 100 && heatSetPoint != 255) throw new ArgumentException(nameof(heatSetPoint));
            _heatSetPoint = heatSetPoint;
        }

        public override string ToString()
        {
            return $"{_heatSetPoint}";
        }
    }
}