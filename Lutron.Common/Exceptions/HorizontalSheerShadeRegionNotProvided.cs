using System;

namespace Lutron.Common.Exceptions
{
    public class HorizontalSheerShadeRegionNotProvided : Exception
    {
        public HorizontalSheerShadeRegionNotProvided() : base(
            "The action number is not provided")
        {
        }
    }
}