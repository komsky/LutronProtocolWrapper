using Lutron.Common.Models;

namespace Lutron.CommandBuilder
{
    public class MyRoomPlusOutputCommandBuilder
    {
        private MyRoomPlusCommandOperation _operation;
        private MyRoomPlusOutputCommandAction _action;
        private int _integrationId;
        private Fade _fade;
        private Level _level;
        private Delay _delay;
        private readonly string _command = "OUTPUT";
        
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

        public MyRoomPlusOutputCommandBuilder WithLevel(Level level)
        {
            _level = level;
            return this;
        }

        public MyRoomPlusOutputCommandBuilder WithDelay(Delay delay)
        {
            _delay = delay;
            return this;
        }

        public string BuildSetOutputLevelCommand()
        {
            return $"{(char)_operation}{_command},{_integrationId},{(int)_action},{_level},{_fade},{_delay}<CR><LF>";
        }

        public string BuildGetOutputLevelCommand()
        {
            return $"{(char)_operation}{_command},{_integrationId}<CR><LF>";
        }

        public string BuildStartRaisingOutputLevelCommand()
        {
            return $"{(char)_operation}{_command},{_integrationId},{(int)_action}<CR><LF>";
        }

        public string BuildStartLoweringOutputLevelCommand()
        {
            return $"{(char)_operation}{_command},{_integrationId},{(int)_action}<CR><LF>";
        }

        public string BuildStopRaisingOrLoweringOutputLevelCommand()
        {
            return $"{(char)_operation}{_command},{_integrationId},{(int)_action}<CR><LF>";
        }

        public string BuildGetFlashFrequencyCommand()
        {
            return $"{(char)_operation}{_command},{_integrationId},{(int)_action},{_fade},{_delay}<CR><LF>";
        }
    }
}