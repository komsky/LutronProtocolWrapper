using System;

namespace Lutron.Common.Models
{
    public class LiftLevel
    {
        private readonly double _level;

        public LiftLevel(double level)
        {
            if (level < 0) throw new ArgumentException(nameof(level));
            if (level > 100) throw new ArgumentException(nameof(level));
            _level = level;
        }

        public override string ToString()
        {
            return $"{_level}";
        }
    }
}