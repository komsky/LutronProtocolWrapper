using Lutron.Connector;
using NSubstitute;
using NUnit.Framework;

namespace Lutron.Service.Tests
{
    [TestFixture]
    public class ResetServiceTests
    {
        [TestFixture]
        public class Reset
        {
            [Test]
            public void ShouldResetDevice()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#RESET,0<CR><LF>";
                var service = new ResetService(connector);

                service.Reset();

                connector.Received(1).Execute(commandString);
            }
        }
    }
}