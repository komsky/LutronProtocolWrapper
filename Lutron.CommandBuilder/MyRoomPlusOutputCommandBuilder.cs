using Lutron.Common;
using Lutron.Common.Models;

namespace Lutron.CommandBuilder
{
    public class MyRoomPlusOutputCommandBuilder
    {
        private MyRoomPlusCommandOperation _operation;
        private MyRoomPlusOutputCommandAction _action;
        private int _integrationId;
        private Fade _fade;
        private OutputLevel _outputLevel;
        private Delay _delay;
        private readonly string _command = "OUTPUT";
        private Pulse _pulse;
        private TiltLevel _tiltLevel;

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

        public MyRoomPlusOutputCommandBuilder WithAction(MyRoomPlusOutputCommandAction action)
        {
            _action = action;
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

        public string BuildSetOutputLevelCommand()
        {
            return $"{(char) _operation}{_command},{_integrationId},{(int) _action},{_outputLevel},{_fade},{_delay}<CR><LF>";
        }

        public string BuildGetOutputLevelCommand()
        {
            return $"{(char) _operation}{_command},{_integrationId}<CR><LF>";
        }

        public string BuildStartRaisingOutputLevelCommand()
        {
            return $"{(char) _operation}{_command},{_integrationId},{(int) _action}<CR><LF>";
        }

        public string BuildStartLoweringOutputLevelCommand()
        {
            return $"{(char) _operation}{_command},{_integrationId},{(int) _action}<CR><LF>";
        }

        public string BuildStopRaisingOrLoweringOutputLevelCommand()
        {
            return $"{(char) _operation}{_command},{_integrationId},{(int) _action}<CR><LF>";
        }

        public string BuildGetFlashFrequencyCommand()
        {
            return $"{(char) _operation}{_command},{_integrationId},{(int) _action}<CR><LF>";
        }

        public string BuildSetFlashFrequencyCommand()
        {
            return $"{(char) _operation}{_command},{_integrationId},{(int) _action},{_fade},{_delay}<CR><LF>";
        }

        public string BuildSetContactClosureOutputPulseTimeCommand()
        {
            if (_pulse != null)
            {
                return $"{(char) _operation}{_command},{_integrationId},{(int) _action},{_pulse}<CR><LF>";
            }

            if (_delay != null)
            {
                return $"{(char) _operation}{_command},{_integrationId},{(int) _action},{_delay}<CR><LF>";
            }

            return $"{(char) _operation}{_command},{_integrationId},{(int) _action}<CR><LF>";
        }

        public string BuildSetTiltLevelCommand()
        {
            if (_tiltLevel is null)
            {
                throw new RequiredParameterNotProvided("tilt level");
            }
            
            if ( _fade is null && _delay != null)
            {
                throw new RequiredParameterNotProvided("fade");
            }
            
            if (_fade != null && _delay != null)
            {
                return
                    $"{(char) _operation}{_command},{_integrationId},{(int) _action},{_tiltLevel},{_fade},{_delay}<CR><LF>";
            }

            if (_fade != null)
            {
                return
                    $"{(char) _operation}{_command},{_integrationId},{(int) _action},{_tiltLevel},{_fade}<CR><LF>";
            }
            
            return $"{(char) _operation}{_command},{_integrationId},{(int) _action},{_tiltLevel}<CR><LF>";
        }
    }
}