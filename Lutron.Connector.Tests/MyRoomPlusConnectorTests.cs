using NSubstitute;
using NUnit.Framework;
using Lutron.Connector;

namespace Lutron.Connector.Tests
{
    [TestFixture]
    public class MyRoomPlusConnectorTests
    {
        [TestFixture]
        public class Execute
        {
            [Test]
            public void ShouldSendDataThroughTheTcpConnection()
            {
                var stream = Substitute.For<INetworkStream>();
                var client = Substitute.For<IMyRoomPlusClient>();
                client.GetStream().Returns(stream);
                var connector = new MyRoomPlusConnector(client);
                var commandString = "#AREA,2,1,70,4,2<CR><LF>";
                var data = System.Text.Encoding.ASCII.GetBytes(commandString);
                
                connector.Execute(commandString);
                
                client.Received(1).GetStream();
                stream.Received(1).Write(Arg.Is<byte[]>(a => a[0] == data[0]), 0, data.Length);
                stream.Received(1).Close();
                client.Received(1).Close();
            }
        }
    }
}