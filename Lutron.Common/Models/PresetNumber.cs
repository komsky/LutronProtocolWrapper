using System;

namespace Lutron.Common.Models
{
    public class PresetNumber
    {
        private readonly int _number;

        public PresetNumber(int number)
        {
            if (number < 0) throw new ArgumentException(nameof(number));
            if (number > 30) throw new ArgumentException(nameof(number));
            _number = number;
        }

        public override string ToString()
        {
            return $"{_number}";
        }
    }
}