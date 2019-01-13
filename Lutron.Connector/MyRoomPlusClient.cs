using System.Net;
using System.Net.Sockets;

namespace Lutron.Connector
{
    public class MyRoomPlusClient : IMyRoomPlusClient
    {
        private readonly string _ipString;
        private readonly int _port;
        private readonly int _responseBufferSize;

        public MyRoomPlusClient(IMyRoomPlusClientConfiguration configuration)
        {
            _ipString = configuration.GetIpString();
            _port = configuration.GetPort();
            _responseBufferSize = configuration.GetResponseBufferSize();

        }

        public void Write(byte[] buffer, int offset, int size)
        {
            using (var client = new TcpClient())
            {
                client.Connect(IPAddress.Parse(_ipString), _port);
                using (var stream = client.GetStream())
                {
                    stream.Write(buffer, offset, size);
                }
            }
        }

        public byte[] Read(byte[] query)
        {
            using (var client = new TcpClient())
            {
                client.Connect(new IPEndPoint(IPAddress.Parse(_ipString), _port));
                using (var stream = client.GetStream())
                {
                    stream.Write(query, 0, query.Length);

                    var buffer = new byte[_responseBufferSize];

                    stream.Read(buffer, 0, buffer.Length);
                    
                    return buffer;
                }
            }
        }
    }
}