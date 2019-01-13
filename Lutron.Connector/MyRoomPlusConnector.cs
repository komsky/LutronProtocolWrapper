using System.Text;

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
            var response = _client.Read(Encoding.ASCII.GetBytes(commandString));
            return Encoding.ASCII.GetString(response, 0, response.Length);
        }

        public void Execute(string commandString)
        {
            var data = Encoding.ASCII.GetBytes(commandString);
            _client.Write(data,0, data.Length);
        }
    }
}