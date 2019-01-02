using System;

namespace Lutron.Common
{
    public class HorizontalSheerShadeRegionNotProvided : Exception
    {
        public HorizontalSheerShadeRegionNotProvided() : base(
            "The action number is not provided")
        {
        }
    }
}