using System;
using Lutron.Common.Enums;

namespace Lutron.Common.Exceptions
{
    public class IncorrectScheduleStatusProvided : Exception
    {
        public IncorrectScheduleStatusProvided(
            HvacScheduleStatus providedScheduleStatus,
            params HvacScheduleStatus[] expectedScheduleStatuses)
            : base(
                $"The schedule status provided is incorrect. Expected {(int) expectedScheduleStatuses[0]} or {(int) expectedScheduleStatuses[1]}, not {(int) providedScheduleStatus}")
        {
        }
    }
}