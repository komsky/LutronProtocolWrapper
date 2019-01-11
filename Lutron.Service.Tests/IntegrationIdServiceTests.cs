using Lutron.Common.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Lutron.Service.Tests
{
    [TestFixture]
    public class IntegrationIdServiceTests
    {
        [TestFixture]
        public class GetIntegrationId
        {
            [Test]
            public void ShouldReturnIntegrationId()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "?INTEGRATIONID,1,5678EFEF<CR><LF>";
                connector.Query(commandString).Returns("~INTEGRATIONID,1,5678EFEF,2<CR><LF>");
                var service = new IntegrationIdService(connector);

                var actual = service.GetIntegrationId("5678EFEF");

                connector.Received(1).Query(commandString);
                Assert.AreEqual(2, actual);
            }
        }
        
        [TestFixture]
        public class GetInfoFromId
        {
            [Test]
            public void ShouldReturnIntegrationId()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "?INTEGRATIONID,3,2<CR><LF>";
                connector.Query(commandString).Returns("~INTEGRATIONID,3,2,INFO_FROM_ID<CR><LF>");
                var service = new IntegrationIdService(connector);

                var actual = service.GetInfoFromId(2);

                connector.Received(1).Query(commandString);
                Assert.AreEqual("INFO_FROM_ID", actual);
            }
        }
    }
}