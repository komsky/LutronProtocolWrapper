using System;

namespace Lutron.Common.Exceptions
{
    public class IncorrectActionNumberProvided : Exception
    {
        public IncorrectActionNumberProvided(
            MyRoomPlusOutputCommandActionNumber providedActionNumber,
            MyRoomPlusOutputCommandActionNumber expectedActionNumber)
            : base(
                $"The action number provided is incorrect. Expected {(int) expectedActionNumber} and not {(int) providedActionNumber}")
        {
        }
    }
}