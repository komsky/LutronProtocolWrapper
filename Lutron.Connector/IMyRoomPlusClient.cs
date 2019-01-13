using System.Net;

namespace Lutron.Connector
{
    public interface IMyRoomPlusClient
    {
        void Write(byte[] buffer, int offset, int size);
        int Read(byte[] buffer, int offset, int size);
    }
}