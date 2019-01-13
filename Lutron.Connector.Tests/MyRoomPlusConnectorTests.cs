using System;
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
                var stream = Substitute.For<INetworkStream>();
                var client = Substitute.For<IMyRoomPlusClient>();
                client.GetStream().Returns(stream);
                var connector = new MyRoomPlusConnector(client);
                var commandString = "#AREA,2,1,70,4,2<CR><LF>";
                var data = Encoding.ASCII.GetBytes(commandString);
                
                connector.Execute(commandString);
                
                client.Received(1).GetStream();
                stream.Received(1).Write(Arg.Is<byte[]>(a => a[0] == data[0]), 0, data.Length);
                stream.Received(1).Close();
                client.Received(1).Close();
            }
        }       
        
        [TestFixture]
        public class Query
        {
            [Test]
            public void ShouldSendDataThroughTheTcpConnection()
            {
                var commandString = "?AREA,2,8<CR><LF>";
                var bytesWritten = Encoding.ASCII.GetBytes(commandString);
                var expected = "~AREA,2,8,3";
                var bytesRead = Encoding.ASCII.GetBytes(expected);
                var buffer = new byte[256];

                var stream = Substitute.For<INetworkStream>();
                stream.Read(Arg.Do(GetBytes()), 0, buffer.Length).Returns(bytesRead.Length);

                var client = Substitute.For<IMyRoomPlusClient>();
                client.GetStream().Returns(stream);

                var connector = new MyRoomPlusConnector(client);

                var response = connector.Query(commandString);

                Assert.AreEqual(expected, response);
                stream.Received(1).Read(Arg.Any<byte[]>(),0,buffer.Length);
                client.Received(1).GetStream();
                stream.Received(1).Write(Arg.Is<byte[]>(a => a[0] == bytesWritten[0]), 0, bytesWritten.Length);
                stream.Received(1).Close();
                client.Received(1).Close();

                Action<byte[]> GetBytes()
                {
                    return args =>
                    {
                        for (var i = 0; i < bytesRead.Length; i++)
                        {
                            args[i] = bytesRead[i];
                        }
                    };
                }
            }
        }
    }
}