using System;

namespace Lutron.Common
{
    public class IncorrectOperationProvided : Exception
    {
        public IncorrectOperationProvided(
            MyRoomPlusCommandOperation providedOperation,
            MyRoomPlusCommandOperation expectedOperation)
            : base(
                $"The operation provided is incorrect. Expected {(char)expectedOperation} and not {(char)providedOperation}")
        {
        }
    }
}