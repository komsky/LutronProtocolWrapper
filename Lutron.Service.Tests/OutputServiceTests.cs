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
                Assert.AreEqual(48, outputLevel);
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

                service.SetOutputLevel(2, 48);

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

                    service.SetOutputLevel(2, 48, new Fade(seconds: 20));

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

                    service.SetOutputLevel(2, 48, new Fade(), new Delay(seconds: 15));

                    connector.Received(1).Execute(commandString);
                }
            }
        }

        [TestFixture]
        public class StartRaisingOutputLevel
        {
            [Test]
            public void ShouldStartRaisingOutputLevel()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#OUTPUT,2,2<CR><LF>";
                var service = new OutputService(connector);

                service.StartRaisingOutputLevel(2);

                connector.Received(1).Execute(commandString);
            }
        }

        [TestFixture]
        public class StartLoweringOutputLevel
        {
            [Test]
            public void ShouldStartLoweringOutputLevel()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#OUTPUT,2,3<CR><LF>";
                var service = new OutputService(connector);

                service.StartLoweringOutputLevel(2);

                connector.Received(1).Execute(commandString);
            }
        }

        [TestFixture]
        public class StopRaisingOrLoweringOutputLevel
        {
            [Test]
            public void ShouldStartLoweringOutputLevel()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#OUTPUT,2,4<CR><LF>";
                var service = new OutputService(connector);

                service.StopRaisingOrLoweringOutputLevel(2);

                connector.Received(1).Execute(commandString);
            }
        }

        [TestFixture]
        public class SetFlashFrequency
        {
            [Test]
            public void ShouldSetFlashFrequency()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#OUTPUT,2,5<CR><LF>";
                var service = new OutputService(connector);

                service.SetFlashFrequency(2);

                connector.Received(1).Execute(commandString);
            }

            [TestFixture]
            public class GivenFadeAndDelay
            {
                [Test]
                public void ShouldSetFlashFrequency()
                {
                    var connector = Substitute.For<IMyRoomPlusConnector>();
                    var commandString = "#OUTPUT,2,5,20,10<CR><LF>";
                    var service = new OutputService(connector);

                    service.SetFlashFrequency(2, new Fade(seconds: 20), new Delay(seconds: 10));

                    connector.Received(1).Execute(commandString);
                }
            }
        }

        [TestFixture]
        public class GetFlashFrequency
        {
            [Test]
            public void ShouldGetFlashFrequency()
            {
                var commandString = "?OUTPUT,2,5<CR><LF>";
                var connector = Substitute.For<IMyRoomPlusConnector>();
                connector.Query(commandString).Returns("~OUTPUT,2,5,50<CR><LF>");
                var service = new OutputService(connector);

                var flashFrequency = service.GetFlashFrequency(2);

                connector.Received(1).Query(commandString);
                Assert.AreEqual(50, flashFrequency);
            }
        }

        [TestFixture]
        public class SetContactClosureOutputPulseTime
        {
            [TestFixture]
            public class GivenPulse
            {
                [Test]
                public void ShouldSetContactClosureOutputPulseTime()
                {
                    var connector = Substitute.For<IMyRoomPlusConnector>();
                    var commandString = "#OUTPUT,2,6,15<CR><LF>";
                    var service = new OutputService(connector);

                    service.SetContactClosureOutputPulseTime(2, new Pulse(seconds: 15));

                    connector.Received(1).Execute(commandString);
                }
            }

            [TestFixture]
            public class GivenDelay
            {
                [Test]
                public void ShouldSetContactClosureOutputPulseTime()
                {
                    var connector = Substitute.For<IMyRoomPlusConnector>();
                    var commandString = "#OUTPUT,2,6,30<CR><LF>";
                    var service = new OutputService(connector);

                    service.SetContactClosureOutputPulseTime(2, delay: new Delay(seconds: 30));

                    connector.Received(1).Execute(commandString);
                }
            }
        }

        [TestFixture]
        public class SetTiltLevel
        {
            [Test]
            public void ShouldSetTiltLevel()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#OUTPUT,2,9,45<CR><LF>";
                var service = new OutputService(connector);

                service.SetTiltLevel(2, new TiltLevel(45));

                connector.Received(1).Execute(commandString);
            }

            [TestFixture]
            public class GivenFadeAndDelay
            {
                [Test]
                public void ShouldSetTiltLevel()
                {
                    var connector = Substitute.For<IMyRoomPlusConnector>();
                    var commandString = "#OUTPUT,2,9,45,10,30<CR><LF>";
                    var service = new OutputService(connector);

                    service.SetTiltLevel(2, new TiltLevel(45), new Fade(seconds: 10), delay: new Delay(seconds: 30));

                    connector.Received(1).Execute(commandString);
                }
            }
        }

        [TestFixture]
        public class SetLiftAndTiltLevels
        {
            [Test]
            public void ShouldSetTiltLevel()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#OUTPUT,2,10,25,45<CR><LF>";
                var service = new OutputService(connector);

                service.SetLiftAndTiltLevels(2,new LiftLevel(25), new TiltLevel(45));

                connector.Received(1).Execute(commandString);
            }

            [TestFixture]
            public class GivenFadeAndDelay
            {
                [Test]
                public void ShouldSetTiltLevel()
                {
                    var connector = Substitute.For<IMyRoomPlusConnector>();
                    var commandString = "#OUTPUT,2,10,25,45,10,30<CR><LF>";
                    var service = new OutputService(connector);

                    service.SetLiftAndTiltLevels(2,new LiftLevel(25), new TiltLevel(45), new Fade(seconds: 10), delay: new Delay(seconds: 30));

                    connector.Received(1).Execute(commandString);
                }
            }
        }

        [TestFixture]
        public class StartRaisingTilt
        {
            [Test]
            public void ShouldStartRaisingOutputLevel()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#OUTPUT,2,11<CR><LF>";
                var service = new OutputService(connector);

                service.StartRaisingTilt(2);

                connector.Received(1).Execute(commandString);
            }
        }

        [TestFixture]
        public class StartLoweringTilt
        {
            [Test]
            public void ShouldStartLoweringOutputLevel()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#OUTPUT,2,12<CR><LF>";
                var service = new OutputService(connector);

                service.StartLoweringTilt(2);

                connector.Received(1).Execute(commandString);
            }
        }

        [TestFixture]
        public class StopRaisingOrLoweringTilt
        {
            [Test]
            public void ShouldStartLoweringOutputLevel()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#OUTPUT,2,13<CR><LF>";
                var service = new OutputService(connector);

                service.StopRaisingOrLoweringTilt(2);

                connector.Received(1).Execute(commandString);
            }
        }        

        [TestFixture]
        public class StartRaisingLift
        {
            [Test]
            public void ShouldStartRaisingOutputLevel()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#OUTPUT,2,14<CR><LF>";
                var service = new OutputService(connector);

                service.StartRaisingLift(2);

                connector.Received(1).Execute(commandString);
            }
        }

        [TestFixture]
        public class StartLoweringLift
        {
            [Test]
            public void ShouldStartLoweringOutputLevel()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#OUTPUT,2,15<CR><LF>";
                var service = new OutputService(connector);

                service.StartLoweringLift(2);

                connector.Received(1).Execute(commandString);
            }
        }

        [TestFixture]
        public class StopRaisingOrLoweringLift
        {
            [Test]
            public void ShouldStartLoweringOutputLevel()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#OUTPUT,2,16<CR><LF>";
                var service = new OutputService(connector);

                service.StopRaisingOrLoweringLift(2);

                connector.Received(1).Execute(commandString);
            }
        }        
    }
}