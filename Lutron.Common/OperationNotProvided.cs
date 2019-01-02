using System;

namespace Lutron.Common
{
    public class OperationNotProvided : Exception
    {
        public OperationNotProvided() : base(
            "The operation is not provided")
        {
        }
    }
}