using System;

namespace Lutron.Common
{
    public class IntegrationIdNotProvided : Exception
    {
        public IntegrationIdNotProvided() : base(
            "The integration id is not provided")
        {
        }
    }
}