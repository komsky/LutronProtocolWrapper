using System;
using System.Text;
using Lutron.Common.Interfaces;

namespace Lutron.Connector
{
    public class MyRoomPlusConnector: IMyRoomPlusConnector
    {
        private readonly IMyRoomPlusClient _client;

        public MyRoomPlusConnector(IMyRoomPlusClient client)
        {
            _client = client;
        }

        public string Query(string commandString)
        {
            var stream = _client.GetStream();
            var data = Encoding.ASCII.GetBytes(commandString);
            stream.Write(data,0, data.Length);
            var buffer = new byte[256];
            var numberOfBytesRead = stream.Read(buffer, 0 , buffer.Length);
            var response = Encoding.ASCII.GetString(buffer, 0, numberOfBytesRead);
            stream.Close();
            _client.Close();
            return response;
        }

        public void Execute(string commandString)
        {
            var stream = _client.GetStream();
            var data = Encoding.ASCII.GetBytes(commandString);
            stream.Write(data,0, data.Length);
            stream.Close();
            _client.Close();
        }
    }
}