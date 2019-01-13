using Lutron.Connector;

namespace MockClient
{
    public class MyRoomPlusClientConfiguration: IMyRoomPlusClientConfiguration
    {
        public string GetIpString()
        {
            return "127.0.0.1";
        }

        public int GetPort()
        {
            return 13175;
        }

        public int GetResponseBufferSize()
        {
            return 32;
        }
    }
}