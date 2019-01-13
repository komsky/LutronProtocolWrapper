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
            var client = new TcpClient();
            client.Connect(IPAddress.Parse(_ipString), _port);
            var stream = client.GetStream();
            stream.Write(buffer,offset,size);
            stream.Close();
            client.Close();
        }

        public int Read(byte[] buffer, int offset, int size)
        {
            var client = new TcpClient();
            client.Connect(IPAddress.Parse(_ipString), _port);
            var stream = client.GetStream();
            var numberOfBytesRead = stream.Read(buffer,offset,size);
            stream.Close();
            client.Close();
            return numberOfBytesRead;
        }
    }
}