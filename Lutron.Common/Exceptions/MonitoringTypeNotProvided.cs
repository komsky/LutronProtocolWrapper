using System;

namespace Lutron.Common.Exceptions
{
    public class MonitoringTypeNotProvided : Exception
    {
        public MonitoringTypeNotProvided() : base(
            "The monitoring type is not provided")
        {
        }
    }
}