using System;

namespace Lutron.Common
{
    public class RequiredParameterNotProvided : Exception
    {
        public RequiredParameterNotProvided(string parameterName) : base(
            $"The required parameter, {parameterName}, was not provided")
        {
        }
    }
}