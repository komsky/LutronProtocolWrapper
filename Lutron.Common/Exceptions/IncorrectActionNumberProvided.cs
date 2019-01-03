using System;
using Lutron.Common.Enums;

namespace Lutron.Common.Exceptions
{
    public class IncorrectActionNumberProvided : Exception
    {
        public IncorrectActionNumberProvided(
            OutputCommandActionNumber providedActionNumber,
            OutputCommandActionNumber expectedActionNumber)
            : base(
                $"The action number provided is incorrect. Expected {(int) expectedActionNumber} and not {(int) providedActionNumber}")
        {
        }
    }
}