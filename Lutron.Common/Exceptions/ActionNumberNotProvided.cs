using System;

namespace Lutron.Common.Exceptions
{
    public class ActionNumberNotProvided : Exception
    {
        public ActionNumberNotProvided() : base(
            "The action number is not provided")
        {
        }
    }
}