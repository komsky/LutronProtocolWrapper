using System;

namespace Lutron.Common
{
    public class ActionNumberNotProvided : Exception
    {
        public ActionNumberNotProvided() : base(
            "The action number is not provided")
        {
        }
    }
}