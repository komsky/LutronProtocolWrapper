using System;

namespace Lutron.Common.Exceptions
{
    public class ShadeGroupLevelNotProvided : Exception
    {
        public ShadeGroupLevelNotProvided() : base(
            "The output level is not provided")
        {
        }
    }
}