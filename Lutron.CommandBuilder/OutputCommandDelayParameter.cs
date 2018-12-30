using System;

namespace Lutron.CommandBuilder
{
    public class OutputCommandDelayParameter
    {
        private readonly TimeSpan _timeSpan;

        public OutputCommandDelayParameter(TimeSpan timeSpan)
        {
            _timeSpan = timeSpan;
        }

        public string Value => _timeSpan.ToString();
    }
}