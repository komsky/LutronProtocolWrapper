using Lutron.Common.Interfaces;
using Lutron.Common.Models;
using NSubstitute;
using NUnit.Framework;

namespace Lutron.Service.Tests
{
    [TestFixture]
    public class OutputServiceTests
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
                var service = new OutputService(connector);
                
                var outputLevel = service.GetOutputLevel(2);

                connector.Received(1).Query(commandString);
                Assert.AreEqual(48,outputLevel);
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
                var service = new OutputService(connector);
                
                service.SetOutputLevel(2,48);

                connector.Received(1).Execute(commandString);
            }
            
            [TestFixture]
            public class GivenFadeTime
            {
                [Test]
                public void ShouldSetOutputLevel()
                {
                    var connector = Substitute.For<IMyRoomPlusConnector>();
                    var commandString = "#OUTPUT,2,1,48,20<CR><LF>";
                    var service = new OutputService(connector);
                
                    service.SetOutputLevel(2,48, new Fade(seconds:20));

                    connector.Received(1).Execute(commandString);
                }
            }
            
            [TestFixture]
            public class GivenDelayTime
            {
                [Test]
                public void ShouldSetOutputLevel()
                {
                    var connector = Substitute.For<IMyRoomPlusConnector>();
                    var commandString = "#OUTPUT,2,1,48,0,15<CR><LF>";
                    var service = new OutputService(connector);
                
                    service.SetOutputLevel(2,48, new Fade(), new Delay(seconds:15));

                    connector.Received(1).Execute(commandString);
                }
            }
        }

        [TestFixture]
        public class StartRaisingOutputLevel
        {
            [Test]
            public void ShouldSetOutputLevel()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#OUTPUT,2,2<CR><LF>";
                var service = new OutputService(connector);
                
                service.StartRaisingOutputLevel(2);

                connector.Received(1).Execute(commandString);
            }
        }

    }
}