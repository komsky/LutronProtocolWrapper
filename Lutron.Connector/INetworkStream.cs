namespace Lutron.Connector
{
    public interface INetworkStream
    {
        void Write(byte[] buffer, int offset, int size);
        void Close();
        int Read(byte[] buffer, int offset, int size);
    }
}