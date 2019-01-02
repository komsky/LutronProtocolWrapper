using System;

namespace Lutron.Common.Exceptions
{
    public class ParameterNotProvided : Exception
    {
        public ParameterNotProvided(string parameterName) : base(
            $"The parameter, {parameterName}, is not provided")
        {
        }
    }
}