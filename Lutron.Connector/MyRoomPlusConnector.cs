using System.Text;
using Lutron.Common.Interfaces;

namespace Lutron.Connector
{
    public class MyRoomPlusConnector: IMyRoomPlusConnector
    {
        private readonly IMyRoomPlusClient _client;
        private readonly int _responseBufferSize;

        public MyRoomPlusConnector(IMyRoomPlusClient client, IMyRoomPlusClientConfiguration configuration)
        {
            _client = client;
            _responseBufferSize = configuration.GetResponseBufferSize();
        }

        public string Query(string commandString)
        {
            var commandStringBytes = Encoding.ASCII.GetBytes(commandString);
            _client.Write(commandStringBytes,0, commandStringBytes.Length);
            var buffer = new byte[_responseBufferSize];
            var numberOfBytesRead = _client.Read(buffer, 0 , buffer.Length);
            var response = Encoding.ASCII.GetString(buffer, 0, numberOfBytesRead);
            return response;
        }

        public void Execute(string commandString)
        {
            var data = Encoding.ASCII.GetBytes(commandString);
            _client.Write(data,0, data.Length);
        }
    }
}