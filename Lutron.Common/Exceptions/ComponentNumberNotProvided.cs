using System;

namespace Lutron.Common.Exceptions
{
    public class ComponentNumberNotProvided : Exception
    {
        public ComponentNumberNotProvided() : base(
            $"The component number is not provided")
        {
        }
    }
}