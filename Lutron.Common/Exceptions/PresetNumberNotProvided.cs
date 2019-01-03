using System;

namespace Lutron.Common.Exceptions
{
    public class PresetNumberNotProvided : Exception
    {
        public PresetNumberNotProvided() : base(
            "The preset number is not provided")
        {
        }
    }
}