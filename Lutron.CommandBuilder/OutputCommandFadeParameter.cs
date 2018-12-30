using System;

namespace Lutron.CommandBuilder
{
    public class OutputCommandFadeParameter
    {
        private readonly TimeSpan _timeSpan;

        public OutputCommandFadeParameter(TimeSpan timeSpan)
        {
            _timeSpan = timeSpan;
        }

        public string Value => _timeSpan.ToString();
    }
}