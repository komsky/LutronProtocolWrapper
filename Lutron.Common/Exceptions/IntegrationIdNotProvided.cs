using System;

namespace Lutron.Common.Exceptions
{
    public class IntegrationIdNotProvided : Exception
    {
        public IntegrationIdNotProvided() : base(
            "The integration id is not provided")
        {
        }
    }
}