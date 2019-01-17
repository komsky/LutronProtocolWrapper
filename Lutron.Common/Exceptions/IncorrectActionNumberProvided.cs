using System;
using Lutron.Common.Enums;

namespace Lutron.Common.Exceptions
{
    public class IncorrectActionNumberProvided : Exception
    {
        public IncorrectActionNumberProvided(
            OutputCommandActionNumber providedActionNumber,
            OutputCommandActionNumber expectedActionNumber)
            : base(
                $"The action number provided is incorrect. Expected {(int) expectedActionNumber} and not {(int) providedActionNumber}")
        {
        }

        public IncorrectActionNumberProvided(
            EthernetCommandConfigurationNumber providedActionNumber,
            EthernetCommandConfigurationNumber expectedActionNumber)
            : base(
                $"The action number provided is incorrect. Expected {(int) expectedActionNumber} and not {(int) providedActionNumber}")
        {
        }

        public IncorrectActionNumberProvided(
            ShadeGroupCommandActionNumber providedActionNumber,
            ShadeGroupCommandActionNumber expectedActionNumber)
            : base(
                $"The action number provided is incorrect. Expected {(int) expectedActionNumber} and not {(int) providedActionNumber}")
        {
        }

        public IncorrectActionNumberProvided(
            TimeClockCommandActionNumber providedActionNumber,
            TimeClockCommandActionNumber expectedActionNumber)
            : base(
                $"The action number provided is incorrect. Expected {(int) expectedActionNumber} and not {(int) providedActionNumber}")
        {
        }
        public IncorrectActionNumberProvided(
            DeviceCommandActionNumber providedActionNumber,
            DeviceCommandActionNumber expectedActionNumber)
            : base(
                $"The action number provided is incorrect. Expected {(int) expectedActionNumber} and not {(int) providedActionNumber}")
        {
        }
    }
}