using System;

namespace Lutron.Common.Models
{
    public class Fade
    {
        private readonly int _fractional;
        private readonly int _hours;
        private readonly int _minutes;
        private readonly int _seconds;

        public Fade(int hours = 0, int minutes = 0, int seconds = 0, int fractional = 0)
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
            if (_hours > 0 && _minutes > 0 && _seconds > 0) return $"{_hours:D2}:{_minutes:D2}:{_seconds:D2}";
            if (_hours > 0 && _minutes > 0 ) return $"{_hours:D2}:{_minutes:D2}:00";
            if (_hours > 0 ) return $"{_hours:D2}:00:00";

            if (_minutes > 0 && _seconds > 0) return $"{_minutes:D2}:{_seconds:D2}";
            if (_minutes > 0) return $"{_minutes:D2}:00";

            if (_seconds > 0 && _fractional > 0) return $"{_seconds}.{_fractional}";

            return _seconds > 0 ? $"{_seconds}" : "0";
        }
    }
}