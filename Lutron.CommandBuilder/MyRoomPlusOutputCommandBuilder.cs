using Lutron.Common.Enums;
using Lutron.Common.Exceptions;
using Lutron.Common.Models;

namespace Lutron.CommandBuilder
{
    public class MyRoomPlusOutputCommandBuilder
    {
        private MyRoomPlusCommandOperation _operation;
        private MyRoomPlusOutputCommandActionNumber _actionNumber;
        private int _integrationId;
        private Fade _fade;
        private OutputLevel _outputLevel;
        private Delay _delay;
        private readonly string _command = "OUTPUT";
        private Pulse _pulse;
        private TiltLevel _tiltLevel;
        private LiftLevel _liftLevel;
        private MyRoomPlusHorizontalSheerShadeRegion _region;

        public static MyRoomPlusOutputCommandBuilder Create()
        {
            return new MyRoomPlusOutputCommandBuilder();
        }

        public MyRoomPlusOutputCommandBuilder WithOperation(MyRoomPlusCommandOperation operation)
        {
            _operation = operation;
            return this;
        }

        public MyRoomPlusOutputCommandBuilder WithIntegrationId(int integrationId)
        {
            _integrationId = integrationId;
            return this;
        }

        public MyRoomPlusOutputCommandBuilder WithAction(MyRoomPlusOutputCommandActionNumber actionNumber)
        {
            _actionNumber = actionNumber;
            return this;
        }

        public MyRoomPlusOutputCommandBuilder WithFade(Fade fade)
        {
            _fade = fade;
            return this;
        }

        public MyRoomPlusOutputCommandBuilder WithLevel(OutputLevel outputLevel)
        {
            _outputLevel = outputLevel;
            return this;
        }

        public MyRoomPlusOutputCommandBuilder WithDelay(Delay delay)
        {
            _delay = delay;
            return this;
        }

        public MyRoomPlusOutputCommandBuilder WithPulse(Pulse pulse)
        {
            _pulse = pulse;
            return this;
        }

        public MyRoomPlusOutputCommandBuilder WithTiltLevel(TiltLevel tiltLevel)
        {
            _tiltLevel = tiltLevel;
            return this;
        }

        public MyRoomPlusOutputCommandBuilder WithLiftLevel(LiftLevel liftLevel)
        {
            _liftLevel = liftLevel;
            return this;
        }

        public MyRoomPlusOutputCommandBuilder WithHorizontalSheerShadeRegion(
            MyRoomPlusHorizontalSheerShadeRegion region)
        {
            _region = region;
            return this;
        }

        public string BuildSetOutputLevelCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(MyRoomPlusCommandOperation.Set);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MyRoomPlusOutputCommandActionNumber.OutputLevel);

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
            
            CheckIfCorrectOperationIsProvided(MyRoomPlusCommandOperation.Get);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MyRoomPlusOutputCommandActionNumber.OutputLevel);

            return $"{(char) _operation}{_command},{_integrationId},{(int)_actionNumber}<CR><LF>";
        }

        public string BuildStartRaisingOutputLevelCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(MyRoomPlusCommandOperation.Set);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MyRoomPlusOutputCommandActionNumber.StartRaisingOutputLevel);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildStartLoweringOutputLevelCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(MyRoomPlusCommandOperation.Set);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MyRoomPlusOutputCommandActionNumber.StartLoweringOutputLevel);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildStopRaisingOrLoweringOutputLevelCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(MyRoomPlusCommandOperation.Set);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MyRoomPlusOutputCommandActionNumber.StopRaisingOrLoweringOutputLevel);
            
            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildGetFlashFrequencyCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(MyRoomPlusCommandOperation.Get);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MyRoomPlusOutputCommandActionNumber.FlashFrequency);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildSetFlashFrequencyCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(MyRoomPlusCommandOperation.Set);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MyRoomPlusOutputCommandActionNumber.FlashFrequency);
            
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
            
            CheckIfCorrectOperationIsProvided(MyRoomPlusCommandOperation.Set);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MyRoomPlusOutputCommandActionNumber.ContactClosureOutputPulseTime);

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
            
            CheckIfCorrectOperationIsProvided(MyRoomPlusCommandOperation.Set);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MyRoomPlusOutputCommandActionNumber.TiltLevel);

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

        public string BuildSetLiftAndTiltLevelCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(MyRoomPlusCommandOperation.Set);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MyRoomPlusOutputCommandActionNumber.LiftAndTiltLevel);

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
            
            CheckIfCorrectOperationIsProvided(MyRoomPlusCommandOperation.Set);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MyRoomPlusOutputCommandActionNumber.StartRaisingTilt);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildStartLoweringTiltCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(MyRoomPlusCommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MyRoomPlusOutputCommandActionNumber.StartLoweringTilt);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildStopRaisingOrLoweringTiltCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(MyRoomPlusCommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MyRoomPlusOutputCommandActionNumber.StopRaisingOrLoweringTilt);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildStartRaisingLiftCommand()
        {
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MyRoomPlusOutputCommandActionNumber.StartRaisingLift);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildStartLoweringLiftCommand()
        {
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MyRoomPlusOutputCommandActionNumber.StartLoweringLift);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildStopRaisingOrLoweringLiftCommand()
        {
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MyRoomPlusOutputCommandActionNumber.StopRaisingOrLoweringLift);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildGetHorizontalSheerShadeRegionCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(MyRoomPlusCommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MyRoomPlusOutputCommandActionNumber.HorizontalSheerShadeRegion);

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

        private void CheckIfCorrectOperationIsProvided(MyRoomPlusCommandOperation expectedOperation)
        {
            if (_operation != expectedOperation)
            {
                throw new IncorrectOperationProvided(_operation, expectedOperation);
            }
        }

        private void CheckIfOperationIsProvided()
        {
            if (_operation == default(MyRoomPlusCommandOperation))
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
                throw new OutputLevelNotProvided();
            }
        }

        private void CheckIfProvidedActionNumberIsCorrect(MyRoomPlusOutputCommandActionNumber expectedActionNumber)
        {
            if (_actionNumber != expectedActionNumber)
            {
                throw new IncorrectActionNumberProvided(_actionNumber,
                    expectedActionNumber);
            }
        }

        private void CheckIfActionNumberIsProvided()
        {
            if (_actionNumber == default(MyRoomPlusOutputCommandActionNumber))
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