using System;

namespace Lutron.Common.Models
{
    public class HeatSetPointFahrenheit
    {
        private readonly int _setPointHeat;

        public HeatSetPointFahrenheit(int setPointHeat)
        {
            if (setPointHeat < 32) throw new ArgumentException(nameof(setPointHeat));
            if (setPointHeat > 212 && setPointHeat != 255) throw new ArgumentException(nameof(setPointHeat));
            _setPointHeat = setPointHeat;
        }

        public override string ToString()
        {
            return $"{_setPointHeat}";
        }
    }
}