using Lutron.Common.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Lutron.Service.Tests
{
    [TestFixture]
    public class EthernetServiceTests
    {
        [TestFixture]
        public class GetIpAddress
        {
            [Test]
            public void ShouldReturnIpAddress()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "?ETHERNET,0<CR><LF>";
                connector.Query(commandString).Returns("~ETHERNET,0,192.168.250.1<CR><LF>");
                var service = new EthernetService(connector);

                var actual = service.GetIpAddress();

                connector.Received(1).Query(commandString);
                Assert.AreEqual("192.168.250.1", actual);
            }
        }

        [TestFixture]
        public class SetIpAddress
        {
            [Test]
            public void ShouldSetIpAddress()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#ETHERNET,0,192.168.250.1<CR><LF>";
                var service = new EthernetService(connector);

                service.SetIpAddress("192.168.250.1");

                connector.Received(1).Execute(commandString);
            }
        }    
        
        [TestFixture]
        public class GetGatewayAddress
        {
            [Test]
            public void ShouldReturnGatewayAddress()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "?ETHERNET,1<CR><LF>";
                connector.Query(commandString).Returns("~ETHERNET,1,192.168.250.10<CR><LF>");
                var service = new EthernetService(connector);

                var actual = service.GetGatewayAddress();

                connector.Received(1).Query(commandString);
                Assert.AreEqual("192.168.250.10", actual);
            }
        }

        [TestFixture]
        public class SetGatewayAddress
        {
            [Test]
            public void ShouldSetGatewayAddress()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#ETHERNET,1,192.168.250.10<CR><LF>";
                var service = new EthernetService(connector);

                service.SetGatewayAddress("192.168.250.10");

                connector.Received(1).Execute(commandString);
            }
        }   
        
        [TestFixture]
        public class GetSubnetMask
        {
            [Test]
            public void ShouldReturnSubnetMask()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "?ETHERNET,2<CR><LF>";
                connector.Query(commandString).Returns("~ETHERNET,2,255.255.255.0<CR><LF>");
                var service = new EthernetService(connector);

                var actual = service.GetSubnetMask();

                connector.Received(1).Query(commandString);
                Assert.AreEqual("255.255.255.0", actual);
            }
        }

        [TestFixture]
        public class SetSubnetMask
        {
            [Test]
            public void ShouldSetSubnetMask()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#ETHERNET,2,255.255.255.0<CR><LF>";
                var service = new EthernetService(connector);

                service.SetSubnetMask("255.255.255.0");

                connector.Received(1).Execute(commandString);
            }
        }   
        
        [TestFixture]
        public class GetDhcp
        {
            [Test]
            public void ShouldReturnDhcp()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "?ETHERNET,4<CR><LF>";
                connector.Query(commandString).Returns("~ETHERNET,4,192.168.250.50<CR><LF>");
                var service = new EthernetService(connector);

                var actual = service.GetDhcp();

                connector.Received(1).Query(commandString);
                Assert.AreEqual("192.168.250.50", actual);
            }
        }
        
        [TestFixture]
        public class GetMulticastAddress
        {
            [Test]
            public void ShouldReturnMulticastAddress()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "?ETHERNET,5<CR><LF>";
                connector.Query(commandString).Returns("~ETHERNET,5,239.255.255.255<CR><LF>");
                var service = new EthernetService(connector);

                var actual = service.GetMulticastAddress();

                connector.Received(1).Query(commandString);
                Assert.AreEqual("239.255.255.255", actual);
            }
        }

        [TestFixture]
        public class SetMulticastAddress
        {
            [Test]
            public void ShouldSetMulticastAddress()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#ETHERNET,5,239.255.255.255<CR><LF>";
                var service = new EthernetService(connector);

                service.SetMulticastAddress("239.255.255.255");

                connector.Received(1).Execute(commandString);
            }
        }
    }
}