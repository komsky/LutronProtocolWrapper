namespace Lutron.CommandBuilder
{
    public class MyRoomPlusOutputCommandBuilder
    {
        private MyRoomPlusCommandOperation _operation;
        private MyRoomPlusOutputCommandAction _action;
        private int _integrationId;
        private string _fade;
        private int _level;
        private string _delay;
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

        public MyRoomPlusOutputCommandBuilder WithFade(string fade)
        {
            _fade = fade;
            return this;
        }

        public MyRoomPlusOutputCommandBuilder WithLevel(int level)
        {
            _level = level;
            return this;
        }

        public MyRoomPlusOutputCommandBuilder WithDelay(string delay)
        {
            _delay = delay;
            return this;
        }

        public string BuildGetOutputLevelCommand()
        {
            return $"{(char)_operation}{_command},{_integrationId},{(int)_action},{_level},{_fade},{_delay}<CR><LF>";
        }
    }
}