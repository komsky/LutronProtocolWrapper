using Lutron.Common.Enums;
using Lutron.Common.Exceptions;
using Lutron.Common.Models;

namespace Lutron.CommandBuilder
{
    public class TimeClockCommandBuilder
    {
        private CommandOperation _operation;
        private TimeClockCommandActionNumber _actionNumber;
        private int _integrationId;
        private readonly string _command = "TIMECLOCK";
        private EventIndex _eventIndex;
        private TimeClockEnableState _enableState;

        public static TimeClockCommandBuilder Create()
        {
            return new TimeClockCommandBuilder();
        }

        public TimeClockCommandBuilder WithOperation(CommandOperation operation)
        {
            _operation = operation;
            return this;
        }

        public TimeClockCommandBuilder WithIntegrationId(int integrationId)
        {
            _integrationId = integrationId;
            return this;
        }

        public TimeClockCommandBuilder WithAction(TimeClockCommandActionNumber actionNumber)
        {
            _actionNumber = actionNumber;
            return this;
        }

        public string BuildGetSunriseTimeCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(TimeClockCommandActionNumber.SunriseTime);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildGetSunsetTimeCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(TimeClockCommandActionNumber.SunsetTime);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildGetDaysScheduleCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(TimeClockCommandActionNumber.DaysSchedule);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildSetExecuteIndexedEventCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(TimeClockCommandActionNumber.ExecuteIndexedEvent);

            CheckIfEventIndexParameterIsProvided();

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_eventIndex}<CR><LF>";
        }

        public string BuildSetIndexedEventEnableStateCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(TimeClockCommandActionNumber.IndexedEventEnableState);

            CheckIfEventIndexParameterIsProvided();

            CheckIfEnableStateParameterIsProvided();

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_eventIndex},{(int) _enableState}<CR><LF>";
        }

        private void CheckIfEnableStateParameterIsProvided()
        {
            if (_enableState == default(TimeClockEnableState))
            {
                throw new ParameterNotProvided("enable state");
            }
        }

        private void CheckIfEventIndexParameterIsProvided()
        {
            if (_eventIndex is null)
            {
                throw new ParameterNotProvided("event index");
            }
        }

        private void CheckIfCorrectOperationIsProvided(CommandOperation expectedOperation)
        {
            if (_operation != expectedOperation)
            {
                throw new IncorrectOperationProvided(_operation, expectedOperation);
            }
        }

        private void CheckIfOperationIsProvided()
        {
            if (_operation == default(CommandOperation))
            {
                throw new OperationNotProvided();
            }
        }

        private void CheckIfProvidedActionNumberIsCorrect(TimeClockCommandActionNumber expectedActionNumber)
        {
            if (_actionNumber != expectedActionNumber)
            {
                throw new IncorrectActionNumberProvided(_actionNumber,
                    expectedActionNumber);
            }
        }

        private void CheckIfActionNumberIsProvided()
        {
            if (_actionNumber == default(TimeClockCommandActionNumber))
            {
                throw new ActionNumberNotProvided();
            }
        }


        private void CheckIfIntegrationIdIsProvided()
        {
            if (_integrationId == default(int))
            {
                throw new IntegrationIdNotProvided();
            }
        }

        public TimeClockCommandBuilder WithEventIndex(EventIndex eventIndex)
        {
            _eventIndex = eventIndex;
            return this;
        }

        public TimeClockCommandBuilder WithEnableState(TimeClockEnableState enableState)
        {
            _enableState = enableState;
            return this;
        }
    }
}