using System;
using Lutron.Common.Enums;

namespace Lutron.Common.Exceptions
{
    public class IncorrectShadeGroupCommandActionNumberProvided : Exception
    {
        public IncorrectShadeGroupCommandActionNumberProvided(
            ShadeGroupCommandActionNumber providedActionNumber,
            ShadeGroupCommandActionNumber expectedActionNumber)
            : base(
                $"The action number provided is incorrect. Expected {(int) expectedActionNumber} and not {(int) providedActionNumber}")
        {
        }
    }
}