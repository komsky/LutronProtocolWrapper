using System.Text;
using NSubstitute;
using NUnit.Framework;

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
                var client = Substitute.For<IMyRoomPlusClient>();
                var connector = new MyRoomPlusConnector(client);
                var commandString = "#AREA,2,1,70,4,2<CR><LF>";
                var data = Encoding.ASCII.GetBytes(commandString);
                
                connector.Execute(commandString);
                
                client.Received(1).Write(Arg.Is<byte[]>(a => a[0] == data[0]), 0, data.Length);
            }
        }       
        
        [TestFixture]
        public class Query
        {
            [Test]
            public void ShouldSendDataThroughTheTcpConnection()
            {
                var commandString = "?AREA,2,8<CR><LF>";
                var query = Encoding.ASCII.GetBytes(commandString);
                var expected = "~AREA,2,8,3";
                var expectedBytes = Encoding.ASCII.GetBytes(expected);

                var client = Substitute.For<IMyRoomPlusClient>();
                client.Read(Arg.Is<byte[]>(arg => arg[0] == query[0])).Returns(expectedBytes);

                var connector = new MyRoomPlusConnector(client);

                var response = connector.Query(commandString);

                Assert.AreEqual(expected, response);
                client.Received(1).Read(Arg.Is<byte[]>(arg => arg[0] == query[0]));
            }
        }
    }
}