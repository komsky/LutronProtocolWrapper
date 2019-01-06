using Lutron.Common.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Lutron.Service.Tests
{
    [TestFixture]
    public class MyRoomPlusServiceTests
    {
        [TestFixture]
        public class GetOutputLevel
        {
            [Test]
            public void ShouldReturnOutputLevel()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "?OUTPUT,2,1<CR><LF>";
                connector.Query(commandString).Returns("~OUTPUT,2,1,48<CR><LF>");
                var service = new MyRoomPlusService(connector);
                
                var outputLevel = service.GetOutputLevel(2);

                connector.Received(1).Query(commandString);
                Assert.AreEqual(48,outputLevel.Level);
            }
        }

        [TestFixture]
        public class SetOutputLevel
        {
            [Test]
            public void ShouldSetOutputLevel()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#OUTPUT,2,1,48<CR><LF>";
                var service = new MyRoomPlusService(connector);
                
                service.SetOutputLevel(2,48);

                connector.Received(1).Execute(commandString);
            }
        }

    }
}