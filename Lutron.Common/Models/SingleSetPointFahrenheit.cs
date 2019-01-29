using System;

namespace Lutron.Common.Models
{
    public class SingleSetPointFahrenheit
    {
        private readonly int _setPoint;

        public SingleSetPointFahrenheit(int setPoint)
        {
            if (setPoint < 32) throw new ArgumentException(nameof(setPoint));
            if (setPoint > 212 && setPoint != 255) throw new ArgumentException(nameof(setPoint));
            _setPoint = setPoint;
        }

        public override string ToString()
        {
            return $"{_setPoint}";
        }
    }
}