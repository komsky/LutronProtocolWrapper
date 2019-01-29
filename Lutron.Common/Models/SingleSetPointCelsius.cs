using System;

namespace Lutron.Common.Models
{
    public class SingleSetPointCelsius
    {
        private readonly int _setPoint;

        public SingleSetPointCelsius(int setPoint)
        {
            if (setPoint < 0) throw new ArgumentException(nameof(setPoint));
            if (setPoint > 100 && setPoint != 255) throw new ArgumentException(nameof(setPoint));
            _setPoint = setPoint;
        }

        public override string ToString()
        {
            return $"{_setPoint}";
        }
    }
}