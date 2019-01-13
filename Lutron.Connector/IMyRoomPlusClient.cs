namespace Lutron.Connector
{
    public interface IMyRoomPlusClient
    {
        INetworkStream GetStream();
        void Close();
    }
}