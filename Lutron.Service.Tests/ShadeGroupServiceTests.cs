using Lutron.Common.Enums;
using Lutron.Common.Models;
using Lutron.Connector;
using NSubstitute;
using NUnit.Framework;

namespace Lutron.Service.Tests
{
    [TestFixture]
    public class ShadeGroupServiceTests
    {
        [TestFixture]
        public class GetShadeGroupLevel
        {
            [Test]
            public void ShouldReturnShadeGroupLevel()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "?SHADEGRP,2,1<CR><LF>";
                connector.Query(commandString).Returns("~SHADEGRP,2,1,48<CR><LF>");
                var service = new ShadeGroupService(connector);

                var level = service.GetShadeGroupLevel(2);

                connector.Received(1).Query(commandString);
                Assert.AreEqual(48, level);
            }
        }

        [TestFixture]
        public class SetShadeGroupLevel
        {
            [Test]
            public void ShouldSetShadeGroupLevel()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#SHADEGRP,2,1,48<CR><LF>";
                var service = new ShadeGroupService(connector);

                service.SetShadeGroupLevel(2, 48);

                connector.Received(1).Execute(commandString);
            }

            [TestFixture]
            public class GivenFadeTime
            {
                [Test]
                public void ShouldSetShadeGroupLevel()
                {
                    var connector = Substitute.For<IMyRoomPlusConnector>();
                    var commandString = "#SHADEGRP,2,1,48,20<CR><LF>";
                    var service = new ShadeGroupService(connector);

                    service.SetShadeGroupLevel(2, 48, new Fade(seconds: 20));

                    connector.Received(1).Execute(commandString);
                }
            }

            [TestFixture]
            public class GivenDelayTime
            {
                [Test]
                public void ShouldSetShadeGroupLevel()
                {
                    var connector = Substitute.For<IMyRoomPlusConnector>();
                    var commandString = "#SHADEGRP,2,1,48,0,15<CR><LF>";
                    var service = new ShadeGroupService(connector);

                    service.SetShadeGroupLevel(2, 48, new Fade(), new Delay(seconds: 15));

                    connector.Received(1).Execute(commandString);
                }
            }
        }

        [TestFixture]
        public class StartRaisingShadeGroupLevel
        {
            [Test]
            public void ShouldStartRaisingShadeGroupLevel()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#SHADEGRP,2,2<CR><LF>";
                var service = new ShadeGroupService(connector);

                service.StartRaisingShadeGroupLevel(2);

                connector.Received(1).Execute(commandString);
            }
        }

        [TestFixture]
        public class StartLoweringShadeGroupLevel
        {
            [Test]
            public void ShouldStartLoweringShadeGroupLevel()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#SHADEGRP,2,3<CR><LF>";
                var service = new ShadeGroupService(connector);

                service.StartLoweringShadeGroupLevel(2);

                connector.Received(1).Execute(commandString);
            }
        }

        [TestFixture]
        public class StopRaisingOrLoweringShadeGroupLevel
        {
            [Test]
            public void ShouldStartLoweringShadeGroupLevel()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#SHADEGRP,2,4<CR><LF>";
                var service = new ShadeGroupService(connector);

                service.StopRaisingOrLoweringShadeGroupLevel(2);

                connector.Received(1).Execute(commandString);
            }
        }

        [TestFixture]
        public class SetCurrentPreset
        {
            [Test]
            public void ShouldSetCurrentPreset()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#SHADEGRP,2,6,22<CR><LF>";
                var service = new ShadeGroupService(connector);

                service.SetCurrentPreset(2 , new PresetNumber(22));

                connector.Received(1).Execute(commandString);
            }
        }

        [TestFixture]
        public class GetCurrentPreset
        {
            [Test]
            public void ShouldGetCurrentPreset()
            {
                var commandString = "?SHADEGRP,2,6<CR><LF>";
                var connector = Substitute.For<IMyRoomPlusConnector>();
                connector.Query(commandString).Returns("~SHADEGRP,2,6,22<CR><LF>");
                var service = new ShadeGroupService(connector);

                var flashFrequency = service.GetCurrentPreset(2);

                connector.Received(1).Query(commandString);
                Assert.AreEqual(22, flashFrequency);
            }
        }

        [TestFixture]
        public class SetTiltLevel
        {
            [Test]
            public void ShouldSetTiltLevel()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#SHADEGRP,2,14,45<CR><LF>";
                var service = new ShadeGroupService(connector);

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
                    var commandString = "#SHADEGRP,2,14,45,10,30<CR><LF>";
                    var service = new ShadeGroupService(connector);

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
                var commandString = "#SHADEGRP,2,15,25,45<CR><LF>";
                var service = new ShadeGroupService(connector);

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
                    var commandString = "#SHADEGRP,2,15,25,45,10,30<CR><LF>";
                    var service = new ShadeGroupService(connector);

                    service.SetLiftAndTiltLevels(2,new LiftLevel(25), new TiltLevel(45), new Fade(seconds: 10), delay: new Delay(seconds: 30));

                    connector.Received(1).Execute(commandString);
                }
            }
        }

        [TestFixture]
        public class StartRaisingTilt
        {
            [Test]
            public void ShouldStartRaisingTilt()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#SHADEGRP,2,16<CR><LF>";
                var service = new ShadeGroupService(connector);

                service.StartRaisingTilt(2);

                connector.Received(1).Execute(commandString);
            }
        }

        [TestFixture]
        public class StartLoweringTilt
        {
            [Test]
            public void ShouldStartLoweringTilt()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#SHADEGRP,2,17<CR><LF>";
                var service = new ShadeGroupService(connector);

                service.StartLoweringTilt(2);

                connector.Received(1).Execute(commandString);
            }
        }

        [TestFixture]
        public class StopRaisingOrLoweringTilt
        {
            [Test]
            public void ShouldStopRaisingOrLoweringTilt()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#SHADEGRP,2,18<CR><LF>";
                var service = new ShadeGroupService(connector);

                service.StopRaisingOrLoweringTilt(2);

                connector.Received(1).Execute(commandString);
            }
        }        

        [TestFixture]
        public class StartRaisingLift
        {
            [Test]
            public void ShouldStartRaisingLift()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#SHADEGRP,2,19<CR><LF>";
                var service = new ShadeGroupService(connector);

                service.StartRaisingLift(2);

                connector.Received(1).Execute(commandString);
            }
        }

        [TestFixture]
        public class StartLoweringLift
        {
            [Test]
            public void ShouldStartLoweringLift()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#SHADEGRP,2,20<CR><LF>";
                var service = new ShadeGroupService(connector);

                service.StartLoweringLift(2);

                connector.Received(1).Execute(commandString);
            }
        }

        [TestFixture]
        public class StopRaisingOrLoweringLift
        {
            [Test]
            public void ShouldStopRaisingOrLoweringLift()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#SHADEGRP,2,21<CR><LF>";
                var service = new ShadeGroupService(connector);

                service.StopRaisingOrLoweringLift(2);

                connector.Received(1).Execute(commandString);
            }
        }  
        
        [TestFixture]
        public class GetHorizontalSheerShadeRegion
        {
            [TestFixture]
            public class GivenLiftRegion
            {
                [Test]
                public void ShouldGetHorizontalSheerShadeRegion()
                {
                    var commandString = "?SHADEGRP,2,28,0<CR><LF>";
                    var connector = Substitute.For<IMyRoomPlusConnector>();
                    connector.Query(commandString).Returns("~SHADEGRP,2,28,50<CR><LF>");
                    var service = new ShadeGroupService(connector);

                    var result = service.GetHorizontalSheerShadeRegion(2, HorizontalSheerShadeRegion.Lift);

                    connector.Received(1).Query(commandString);
                    Assert.AreEqual(50, result);
                }                
            }
            
            [TestFixture]
            public class GivenTiltRegion
            {
                [Test]
                public void ShouldGetHorizontalSheerShadeRegion()
                {
                    var commandString = "?SHADEGRP,2,28,1<CR><LF>";
                    var connector = Substitute.For<IMyRoomPlusConnector>();
                    connector.Query(commandString).Returns("~SHADEGRP,2,28,35<CR><LF>");
                    var service = new ShadeGroupService(connector);

                    var result = service.GetHorizontalSheerShadeRegion(2, HorizontalSheerShadeRegion.Tilt);

                    connector.Received(1).Query(commandString);
                    Assert.AreEqual(35, result);
                }                
            }
        }
    }
}