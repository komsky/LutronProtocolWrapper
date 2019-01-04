using System;
using Lutron.Common.Enums;

namespace Lutron.Common.Exceptions
{
    public class IncorrectTimeClockCommandActionNumberProvided : Exception
    {
        public IncorrectTimeClockCommandActionNumberProvided(
            TimeClockCommandActionNumber providedActionNumber,
            TimeClockCommandActionNumber expectedActionNumber)
            : base(
                $"The action number provided is incorrect. Expected {(int) expectedActionNumber} and not {(int) providedActionNumber}")
        {
        }
    }
}