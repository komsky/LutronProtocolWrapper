using Lutron.Common.Enums;
using Lutron.Common.Exceptions;
using Lutron.Common.Models;

namespace Lutron.CommandBuilder
{
    public class ShadeGroupCommandBuilder
    {
        private CommandOperation _operation;
        private ShadeGroupCommandActionNumber _actionNumber;
        private int _integrationId;
        private Fade _fade;
        private ShadeGroupLevel _outputLevel;
        private Delay _delay;
        private readonly string _command = "SHADEGRP";
        private TiltLevel _tiltLevel;
        private LiftLevel _liftLevel;
        private HorizontalSheerShadeRegion _region;
        private PresetNumber _presetNumber;

        public static ShadeGroupCommandBuilder Create()
        {
            return new ShadeGroupCommandBuilder();
        }

        public ShadeGroupCommandBuilder WithOperation(CommandOperation operation)
        {
            _operation = operation;
            return this;
        }

        public ShadeGroupCommandBuilder WithIntegrationId(int integrationId)
        {
            _integrationId = integrationId;
            return this;
        }

        public ShadeGroupCommandBuilder WithAction(ShadeGroupCommandActionNumber actionNumber)
        {
            _actionNumber = actionNumber;
            return this;
        }

        public ShadeGroupCommandBuilder WithFade(Fade fade)
        {
            _fade = fade;
            return this;
        }

        public ShadeGroupCommandBuilder WithLevel(ShadeGroupLevel outputLevel)
        {
            _outputLevel = outputLevel;
            return this;
        }

        public ShadeGroupCommandBuilder WithDelay(Delay delay)
        {
            _delay = delay;
            return this;
        }

        public ShadeGroupCommandBuilder WithPresetNumber(PresetNumber presetNumber)
        {
            _presetNumber = presetNumber;
            return this;
        }


        public ShadeGroupCommandBuilder WithTiltLevel(TiltLevel tiltLevel)
        {
            _tiltLevel = tiltLevel;
            return this;
        }

        public ShadeGroupCommandBuilder WithLiftLevel(LiftLevel liftLevel)
        {
            _liftLevel = liftLevel;
            return this;
        }

        public ShadeGroupCommandBuilder WithHorizontalSheerShadeRegion(
            HorizontalSheerShadeRegion region)
        {
            _region = region;
            return this;
        }

        public string BuildSetShadeGroupLevelCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Set);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(ShadeGroupCommandActionNumber.ShadeGroupLevel);

            CheckIfShadeGroupLevelParameterIsProvided();

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

        public string BuildGetShadeGroupLevelCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Get);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(ShadeGroupCommandActionNumber.ShadeGroupLevel);

            return $"{(char) _operation}{_command},{_integrationId},{(int)_actionNumber}<CR><LF>";
        }

        public string BuildStartRaisingShadeGroupLevelCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Set);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(ShadeGroupCommandActionNumber.StartRaisingShadeGroupLevel);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildStartLoweringShadeGroupLevelCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Set);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(ShadeGroupCommandActionNumber.StartLoweringShadeGroupLevel);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildStopRaisingOrLoweringShadeGroupLevelCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Set);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(ShadeGroupCommandActionNumber.StopRaisingOrLoweringShadeGroupLevel);
            
            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildGetCurrentPresetCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Get);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(ShadeGroupCommandActionNumber.CurrentPreset);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildSetCurrentPresetCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Set);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(ShadeGroupCommandActionNumber.CurrentPreset);

            CheckIfPresetNumberIsProvided();

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_presetNumber}<CR><LF>";
        }

        public string BuildSetTiltLevelCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Set);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(ShadeGroupCommandActionNumber.TiltLevel);

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
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Set);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(ShadeGroupCommandActionNumber.LiftAndTiltLevel);

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

            CheckIfProvidedActionNumberIsCorrect(ShadeGroupCommandActionNumber.StartRaisingTilt);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildStartLoweringTiltCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(ShadeGroupCommandActionNumber.StartLoweringTilt);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildStopRaisingOrLoweringTiltCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(ShadeGroupCommandActionNumber.StopRaisingOrLoweringTilt);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildStartRaisingLiftCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(ShadeGroupCommandActionNumber.StartRaisingLift);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildStartLoweringLiftCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(ShadeGroupCommandActionNumber.StartLoweringLift);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildStopRaisingOrLoweringLiftCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(ShadeGroupCommandActionNumber.StopRaisingOrLoweringLift);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildGetHorizontalSheerShadeRegionCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(ShadeGroupCommandActionNumber.HorizontalSheerShadeRegion);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{(int) _region}<CR><LF>";
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

        private void CheckIfProvidedActionNumberIsCorrect(ShadeGroupCommandActionNumber expectedActionNumber)
        {
            if (_actionNumber != expectedActionNumber)
            {
                throw new IncorrectShadeGroupCommandActionNumberProvided(_actionNumber,
                    expectedActionNumber);
            }
        }

        private void CheckIfActionNumberIsProvided()
        {
            if (_actionNumber == default(ShadeGroupCommandActionNumber))
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