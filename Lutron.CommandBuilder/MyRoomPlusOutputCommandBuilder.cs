namespace Lutron.CommandBuilder
{
    public class MyRoomPlusOutputCommandBuilder
    {
        private MyRoomPlusCommandOperation _operation;
        private int _integrationId;
        private MyRoomPlusOutputCommandAction _action;
        private OutputCommandLevelParameter _level;
        private OutputCommandFadeParameter _fade;
        private OutputCommandDelayParameter _delay;

        private MyRoomPlusOutputCommandBuilder()
        {
           
        }
        
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

        public MyRoomPlusOutputCommandBuilder WithLevel(OutputCommandLevelParameter level)
        {
            _level = level;
            return this;
        }

        public MyRoomPlusOutputCommandBuilder WithFade(OutputCommandFadeParameter fade)
        {
            _fade = fade;
            return this;
        }

        public MyRoomPlusOutputCommandBuilder WithDelay(OutputCommandDelayParameter delay)
        {
            _delay = delay;
            return this;
        }

        public MyRoomPlusOutputCommand BuildCommand()
        {
            return new MyRoomPlusOutputCommand()
            {
                Operation = _operation,
                IntegrationId = _integrationId,
                CommandAction = _action,
                Level = _level,
                Fade = _fade,
                Delay = _delay
            };
        }
    }
}