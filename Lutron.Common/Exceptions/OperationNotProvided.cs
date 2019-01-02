using System;

namespace Lutron.Common.Exceptions
{
    public class OperationNotProvided : Exception
    {
        public OperationNotProvided() : base(
            "The operation is not provided")
        {
        }
    }
}