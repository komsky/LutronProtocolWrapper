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
        private Fade _fade;
        private ShadeGroupLevel _outputLevel;
        private Delay _delay;
        private readonly string _command = "TIMECLOCK";
        private TiltLevel _tiltLevel;
        private LiftLevel _liftLevel;
        private HorizontalSheerShadeRegion _region;
        private PresetNumber _presetNumber;
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

        public TimeClockCommandBuilder WithFade(Fade fade)
        {
            _fade = fade;
            return this;
        }

        public TimeClockCommandBuilder WithLevel(ShadeGroupLevel outputLevel)
        {
            _outputLevel = outputLevel;
            return this;
        }

        public TimeClockCommandBuilder WithDelay(Delay delay)
        {
            _delay = delay;
            return this;
        }

        public TimeClockCommandBuilder WithPresetNumber(PresetNumber presetNumber)
        {
            _presetNumber = presetNumber;
            return this;
        }


        public TimeClockCommandBuilder WithTiltLevel(TiltLevel tiltLevel)
        {
            _tiltLevel = tiltLevel;
            return this;
        }

        public TimeClockCommandBuilder WithLiftLevel(LiftLevel liftLevel)
        {
            _liftLevel = liftLevel;
            return this;
        }

        public TimeClockCommandBuilder WithHorizontalSheerShadeRegion(
            HorizontalSheerShadeRegion region)
        {
            _region = region;
            return this;
        }

        public string BuildGetSunriseTimeCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Get);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(TimeClockCommandActionNumber.SunriseTime);

            return $"{(char) _operation}{_command},{_integrationId},{(int)_actionNumber}<CR><LF>";
        }

        public string BuildGetSunsetTimeCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Get);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(TimeClockCommandActionNumber.SunsetTime);

            return $"{(char) _operation}{_command},{_integrationId},{(int)_actionNumber}<CR><LF>";
        }

        public string BuildGetDaysScheduleCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Get);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(TimeClockCommandActionNumber.DaysSchedule);

            return $"{(char) _operation}{_command},{_integrationId},{(int)_actionNumber}<CR><LF>";
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
                $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_eventIndex},{(int)_enableState}<CR><LF>";
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

        private void CheckIfPresetNumberIsProvided()
        {
            if (_presetNumber is null)
            {
                throw new PresetNumberNotProvided();
            }
        }

        private void CheckIfLiftLevelParameterIsProvided()
        {
            if (_liftLevel is null)
            {
                throw new ParameterNotProvided("lift level");
            }
        }

        private void CheckIfTiltLevelParameterIsProvided()
        {
            if (_tiltLevel is null)
            {
                throw new ParameterNotProvided("tilt level");
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

        private void CheckIfFadeParameterIsProvided()
        {
            if (_fade is null && _delay != null)
            {
                throw new ParameterNotProvided("fade");
            }
        }

        private void CheckIfShadeGroupLevelParameterIsProvided()
        {
            if (_outputLevel is null)
            {
                throw new ShadeGroupLevelNotProvided();
            }
        }

        private void CheckIfProvidedActionNumberIsCorrect(TimeClockCommandActionNumber expectedActionNumber)
        {
            if (_actionNumber != expectedActionNumber)
            {
                throw new IncorrectTimeClockCommandActionNumberProvided(_actionNumber,
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