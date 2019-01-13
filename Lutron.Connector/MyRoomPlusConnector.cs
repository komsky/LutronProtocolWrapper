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
            throw new NotImplementedException();
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