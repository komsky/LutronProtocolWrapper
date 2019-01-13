namespace Lutron.Connector
{
    public interface IMyRoomPlusClientConfiguration
    {
        string GetIpString();
        int GetPort();
        int GetResponseBufferSize();
    }
}