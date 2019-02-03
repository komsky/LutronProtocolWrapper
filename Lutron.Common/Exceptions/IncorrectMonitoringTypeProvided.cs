using System;
using Lutron.Common.Enums;

namespace Lutron.Common.Exceptions
{
    public class IncorrectMonitoringTypeProvided : Exception
    {
        public IncorrectMonitoringTypeProvided(
            MonitoringType providedMonitoringType,
            MonitoringType expectedMonitoringType)
            : base(
                $"The monitoring type provided is incorrect. Expected {(int) expectedMonitoringType} and not {(int) providedMonitoringType}")
        {
        }
    }
}