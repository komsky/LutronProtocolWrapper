using System.Net;

namespace Lutron.Connector
{
    public interface IMyRoomPlusClient
    {
        void Write(byte[] buffer, int offset, int size);
        byte[] Read(byte[] query);
    }
}