using System;

namespace Lutron.Common.Exceptions
{
    public class OutputLevelNotProvided : Exception
    {
        public OutputLevelNotProvided() : base(
            "The output level is not provided")
        {
        }
    }
}