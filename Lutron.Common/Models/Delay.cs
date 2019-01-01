using System;

namespace Lutron.Common.Models
{
    public class Delay
    {
        private readonly int _fractional;
        private readonly int _hours;
        private readonly int _minutes;
        private readonly int _seconds;

        public Delay(int hours = 0, int minutes = 0, int seconds = 0, int fractional = 0)
        {
            if (hours < 0) throw new ArgumentException(nameof(hours));
            if (minutes < 0) throw new ArgumentException(nameof(minutes));
            if (minutes > 59) throw new ArgumentException(nameof(minutes));
            if (seconds < 0) throw new ArgumentException(nameof(seconds));
            if (seconds > 59) throw new ArgumentException(nameof(seconds));
            if (fractional < 0) throw new ArgumentException(nameof(fractional));
            if (fractional > 99) throw new ArgumentException(nameof(fractional));
            _hours = hours;
            _minutes = minutes;
            _seconds = seconds;
            _fractional = fractional;
        }

        public override string ToString()
        {
            if (_hours > 0 && _minutes > 0 && _seconds > 0) return $"{_hours}:{_minutes}:{_seconds}";

            if (_minutes > 0 && _seconds > 0) return $"{_minutes}:{_seconds}";

            if (_seconds > 0 && _fractional > 0) return $"{_seconds}.{_fractional}";

            return _seconds > 0 ? $"{_seconds}" : "0";
        }
    }
}