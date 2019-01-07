using Lutron.Common.Enums;
using Lutron.Common.Exceptions;
using Lutron.Common.Models;

namespace Lutron.CommandBuilder
{
    public class OutputCommandBuilder
    {
        private CommandOperation _operation;
        private OutputCommandActionNumber _actionNumber;
        private int _integrationId;
        private Fade _fade;
        private OutputLevel _outputLevel;
        private Delay _delay;
        private readonly string _command = "OUTPUT";
        private Pulse _pulse;
        private TiltLevel _tiltLevel;
        private LiftLevel _liftLevel;
        private HorizontalSheerShadeRegion _region;

        public static OutputCommandBuilder Create()
        {
            return new OutputCommandBuilder();
        }

        public OutputCommandBuilder WithOperation(CommandOperation operation)
        {
            _operation = operation;
            return this;
        }

        public OutputCommandBuilder WithIntegrationId(int integrationId)
        {
            _integrationId = integrationId;
            return this;
        }

        public OutputCommandBuilder WithAction(OutputCommandActionNumber actionNumber)
        {
            _actionNumber = actionNumber;
            return this;
        }

        public OutputCommandBuilder WithFade(Fade fade)
        {
            _fade = fade;
            return this;
        }

        public OutputCommandBuilder WithOutputLevel(OutputLevel outputLevel)
        {
            _outputLevel = outputLevel;
            return this;
        }

        public OutputCommandBuilder WithDelay(Delay delay)
        {
            _delay = delay;
            return this;
        }

        public OutputCommandBuilder WithPulse(Pulse pulse)
        {
            _pulse = pulse;
            return this;
        }

        public OutputCommandBuilder WithTiltLevel(TiltLevel tiltLevel)
        {
            _tiltLevel = tiltLevel;
            return this;
        }

        public OutputCommandBuilder WithLiftLevel(LiftLevel liftLevel)
        {
            _liftLevel = liftLevel;
            return this;
        }

        public OutputCommandBuilder WithHorizontalSheerShadeRegion(
            HorizontalSheerShadeRegion region)
        {
            _region = region;
            return this;
        }

        public string BuildSetOutputLevelCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(OutputCommandActionNumber.OutputLevel);

            CheckIfOutputLevelParameterIsProvided();

            CheckIfFadeParameterIsProvided();

            if (_fade is null && _delay is null)
            {
                return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_outputLevel}<CR><LF>";
            }

            if (_fade != null && _delay is null)
            {
                return
                    $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_outputLevel},{_fade}<CR><LF>";
            }

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_outputLevel},{_fade},{_delay}<CR><LF>";
        }

        public string BuildGetOutputLevelCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(OutputCommandActionNumber.OutputLevel);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildStartRaisingOutputLevelCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(OutputCommandActionNumber.StartRaisingOutputLevel);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildStartLoweringOutputLevelCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(OutputCommandActionNumber.StartLoweringOutputLevel);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildStopRaisingOrLoweringOutputLevelCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(OutputCommandActionNumber.StopRaisingOrLoweringOutputLevel);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildGetFlashFrequencyCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(OutputCommandActionNumber.FlashFrequency);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildSetFlashFrequencyCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(OutputCommandActionNumber.FlashFrequency);

            CheckIfFadeParameterIsProvided();

            if (_fade is null && _delay is null)
            {
                return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
            }

            if (_fade != null && _delay is null)
            {
                return
                    $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_fade}<CR><LF>";
            }

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_fade},{_delay}<CR><LF>";
        }

        public string BuildSetContactClosureOutputPulseTimeCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(OutputCommandActionNumber.ContactClosureOutputPulseTime);

            if (_pulse != null)
            {
                return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_pulse}<CR><LF>";
            }

            if (_delay != null)
            {
                return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_delay}<CR><LF>";
            }

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildSetTiltLevelCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(OutputCommandActionNumber.TiltLevel);

            CheckIfTiltLevelParameterIsProvided();

            CheckIfFadeParameterIsProvided();

            if (_fade != null && _delay != null)
            {
                return
                    $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_tiltLevel},{_fade},{_delay}<CR><LF>";
            }

            if (_fade != null)
            {
                return
                    $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_tiltLevel},{_fade}<CR><LF>";
            }

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_tiltLevel}<CR><LF>";
        }

        public string BuildSetLiftAndTiltLevelsCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(OutputCommandActionNumber.LiftAndTiltLevels);

            CheckIfLiftLevelParameterIsProvided();

            CheckIfTiltLevelParameterIsProvided();

            CheckIfFadeParameterIsProvided();

            if (_fade != null && _delay != null)
            {
                return
                    $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_liftLevel},{_tiltLevel},{_fade},{_delay}<CR><LF>";
            }

            if (_fade != null)
            {
                return
                    $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_liftLevel},{_tiltLevel},{_fade}<CR><LF>";
            }

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_liftLevel},{_tiltLevel}<CR><LF>";
        }

        public string BuildStartRaisingTiltCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(OutputCommandActionNumber.StartRaisingTilt);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildStartLoweringTiltCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(OutputCommandActionNumber.StartLoweringTilt);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildStopRaisingOrLoweringTiltCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(OutputCommandActionNumber.StopRaisingOrLoweringTilt);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildStartRaisingLiftCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(OutputCommandActionNumber.StartRaisingLift);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildStartLoweringLiftCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(OutputCommandActionNumber.StartLoweringLift);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildStopRaisingOrLoweringLiftCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(OutputCommandActionNumber.StopRaisingOrLoweringLift);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildGetHorizontalSheerShadeRegionCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(OutputCommandActionNumber.HorizontalSheerShadeRegion);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{(int) _region}<CR><LF>";
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

        private void CheckIfOutputLevelParameterIsProvided()
        {
            if (_outputLevel is null)
            {
                throw new ParameterNotProvided("output level");
            }
        }

        private void CheckIfProvidedActionNumberIsCorrect(OutputCommandActionNumber expectedActionNumber)
        {
            if (_actionNumber != expectedActionNumber)
            {
                throw new IncorrectActionNumberProvided(_actionNumber,
                    expectedActionNumber);
            }
        }

        private void CheckIfActionNumberIsProvided()
        {
            if (_actionNumber == default(OutputCommandActionNumber))
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
    }
}