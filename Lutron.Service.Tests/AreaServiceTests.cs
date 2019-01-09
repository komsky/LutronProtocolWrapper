using Lutron.Common.Interfaces;
using Lutron.Common.Models;
using NSubstitute;
using NUnit.Framework;

namespace Lutron.Service.Tests
{
    [TestFixture]
    public class AreaServiceTests
    {
        [TestFixture]
        public class GetOccupancyState
        {
            [Test]
            public void ShouldReturnOccupancyState()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "?AREA,2,8<CR><LF>";
                connector.Query(commandString).Returns("~AREA,2,8,3<CR><LF>");
                var service = new AreaService(connector);

                var sunriseTime = service.GetOccupancyState(2);

                connector.Received(1).Query(commandString);
                Assert.AreEqual("3", sunriseTime);
            }
        }
    }
}