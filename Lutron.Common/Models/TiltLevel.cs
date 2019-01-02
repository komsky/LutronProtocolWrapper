using System;

namespace Lutron.Common.Models
{
    public class TiltLevel
    {
        private readonly double _level;

        public TiltLevel(double level)
        {
            if(level < 0) throw new ArgumentException(nameof(level));
            if(level > 100) throw new ArgumentException(nameof(level));
            _level = level;
        }

        public override string ToString()
        {
            return $"{_level}";
        }
    }
}