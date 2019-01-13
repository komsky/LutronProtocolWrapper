using System.Net;
using System.Net.Sockets;

namespace Lutron.Connector
{
    public class MyRoomPlusClient : IMyRoomPlusClient
    {
        private readonly string _ipString;
        private readonly int _port;

        public MyRoomPlusClient(IMyRoomPlusClientConfiguration configuration)
        {
            _ipString = configuration.GetIpString();
            _port = configuration.GetPort();
        }

        public void Write(byte[] buffer, int offset, int size)
        {
            using (var client = new TcpClient(new IPEndPoint(IPAddress.Parse(_ipString), _port)))
            using (var stream = client.GetStream())
            {
                stream.Write(buffer, offset, size);
            }
        }

        public int Read(byte[] buffer, int offset, int size)
        {
            using (var client = new TcpClient(new IPEndPoint(IPAddress.Parse(_ipString), _port)))
            using (var stream = client.GetStream())
            {
                return stream.Read(buffer, offset, size);
            }
        }
    }
}