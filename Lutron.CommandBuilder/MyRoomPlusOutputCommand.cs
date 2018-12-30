namespace Lutron.CommandBuilder
{
    public class MyRoomPlusOutputCommand
    {
        private const string Command = "OUTPUT";
        public string CreateGetOutputLevelCommandString()
        {
            return $"{(char)Operation}{Command},{IntegrationId},{(int)CommandAction},{Level.Value},{Fade.Value},{Delay.Value}<CR><LF>";
        }

        public MyRoomPlusOutputCommandAction CommandAction { get; set; }
        public MyRoomPlusCommandOperation Operation { get; set; }
        public int IntegrationId { get; set; }
        public OutputCommandLevelParameter Level { get; set; }
        public OutputCommandFadeParameter Fade { get; set; }
        public OutputCommandDelayParameter Delay { get; set; }
    }
}