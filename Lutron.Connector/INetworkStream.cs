namespace Lutron.Connector
{
    public interface INetworkStream
    {
        void Write(byte[] data, int startIndex, int size);
        void Close();
    }
}