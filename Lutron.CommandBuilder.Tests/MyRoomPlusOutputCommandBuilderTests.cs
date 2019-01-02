using Lutron.Common;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.CommandBuilder.Tests
{
    [TestFixture]
    public class MyRoomPlusOutputCommandBuilderTests
    {
        [TestFixture]
        public class BuildSetOutputLevelCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MyRoomPlusOutputCommandBuilder.Create()
                    .WithOperation(MyRoomPlusCommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(MyRoomPlusOutputCommandAction.OutputLevel)
                    .WithLevel(new Level(70))
                    .WithFade(new Fade(seconds: 4))
                    .WithDelay(new Delay(seconds: 2))
                    .BuildSetOutputLevelCommand();

                Assert.AreEqual("#OUTPUT,2,1,70,4,2<CR><LF>", command);
            }
        }

        [TestFixture]
        public class BuildGetOutputLevelCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MyRoomPlusOutputCommandBuilder.Create()
                    .WithOperation(MyRoomPlusCommandOperation.Get)
                    .WithIntegrationId(2)
                    .BuildGetOutputLevelCommand();

                Assert.AreEqual("?OUTPUT,2<CR><LF>", command);
            }
        }

        [TestFixture]
        public class BuildStartRaisingOutputLevelCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MyRoomPlusOutputCommandBuilder.Create()
                    .WithOperation(MyRoomPlusCommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(MyRoomPlusOutputCommandAction.StartRaisingOutputLevel)
                    .BuildStartRaisingOutputLevelCommand();

                Assert.AreEqual("#OUTPUT,2,2<CR><LF>", command);
            }
        }

        [TestFixture]
        public class BuildStartLoweringOutputLevelCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MyRoomPlusOutputCommandBuilder.Create()
                    .WithOperation(MyRoomPlusCommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(MyRoomPlusOutputCommandAction.StartLoweringOutputLevel)
                    .BuildStartLoweringOutputLevelCommand();

                Assert.AreEqual("#OUTPUT,2,3<CR><LF>", command);
            }
        }

        [TestFixture]
        public class BuildStopRaisingOrLoweringOutputLevelCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MyRoomPlusOutputCommandBuilder.Create()
                    .WithOperation(MyRoomPlusCommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(MyRoomPlusOutputCommandAction.StopRaisingOrLoweringOutputLevel)
                    .BuildStopRaisingOrLoweringOutputLevelCommand();

                Assert.AreEqual("#OUTPUT,2,4<CR><LF>", command);
            }
        }

        [TestFixture]
        public class BuildGetFlashFrequencyCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MyRoomPlusOutputCommandBuilder.Create()
                    .WithOperation(MyRoomPlusCommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(MyRoomPlusOutputCommandAction.FlashFrequency)
                    .BuildGetFlashFrequencyCommand();

                Assert.AreEqual("?OUTPUT,2,5<CR><LF>", command);
            }
        }

        [TestFixture]
        public class BuildSetFlashFrequencyCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MyRoomPlusOutputCommandBuilder.Create()
                    .WithOperation(MyRoomPlusCommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(MyRoomPlusOutputCommandAction.FlashFrequency)
                    .WithFade(new Fade(seconds: 2))
                    .WithDelay(new Delay(seconds: 45))
                    .BuildSetFlashFrequencyCommand();

                Assert.AreEqual("#OUTPUT,2,5,2,45<CR><LF>", command);
            }
        }

        [TestFixture]
        public class BuildSetContactClosureOutputPulseTimeCommand
        {
            [TestFixture]
            public class GivenPulse
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = MyRoomPlusOutputCommandBuilder.Create()
                        .WithOperation(MyRoomPlusCommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(MyRoomPlusOutputCommandAction.ContactClosureOutputPulseTime)
                        .WithPulse(new Pulse(seconds: 45))
                        .BuildSetContactClosureOutputPulseTimeCommand();

                    Assert.AreEqual("#OUTPUT,2,6,45<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenDelay
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = MyRoomPlusOutputCommandBuilder.Create()
                        .WithOperation(MyRoomPlusCommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(MyRoomPlusOutputCommandAction.ContactClosureOutputPulseTime)
                        .WithDelay(new Delay(seconds: 10))
                        .BuildSetContactClosureOutputPulseTimeCommand();

                    Assert.AreEqual("#OUTPUT,2,6,10<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenNoPulseOrDelay
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = MyRoomPlusOutputCommandBuilder.Create()
                        .WithOperation(MyRoomPlusCommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(MyRoomPlusOutputCommandAction.ContactClosureOutputPulseTime)
                        .BuildSetContactClosureOutputPulseTimeCommand();

                    Assert.AreEqual("#OUTPUT,2,6<CR><LF>", command);
                }
            }
        }

        [TestFixture]
        public class BuildSetTiltLevelCommand
        {
            [TestFixture]
            public class GivenTiltLevel
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = MyRoomPlusOutputCommandBuilder.Create()
                        .WithOperation(MyRoomPlusCommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(MyRoomPlusOutputCommandAction.TiltLevel)
                        .WithTiltLevel(new TiltLevel(45))
                        .BuildSetTiltLevelCommand();

                    Assert.AreEqual("#OUTPUT,2,9,45<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenNoTiltLevel
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<RequiredParameterNotProvided>(() =>
                        MyRoomPlusOutputCommandBuilder.Create()
                            .WithOperation(MyRoomPlusCommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(MyRoomPlusOutputCommandAction.TiltLevel)
                            .BuildSetTiltLevelCommand());

                    Assert.AreEqual("The required parameter, tilt level, was not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenTiltLevelFadeAndDelay
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = MyRoomPlusOutputCommandBuilder.Create()
                        .WithOperation(MyRoomPlusCommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(MyRoomPlusOutputCommandAction.TiltLevel)
                        .WithTiltLevel(new TiltLevel(10))
                        .WithFade(new Fade(seconds: 13))
                        .WithDelay(new Delay(seconds: 21))
                        .BuildSetTiltLevelCommand();

                    Assert.AreEqual("#OUTPUT,2,9,10,13,21<CR><LF>", command);
                }
            }
            
            [TestFixture]
            public class GivenTiltLevelAndFade
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = MyRoomPlusOutputCommandBuilder.Create()
                        .WithOperation(MyRoomPlusCommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(MyRoomPlusOutputCommandAction.TiltLevel)
                        .WithTiltLevel(new TiltLevel(10))
                        .WithFade(new Fade(seconds: 13))
                        .BuildSetTiltLevelCommand();

                    Assert.AreEqual("#OUTPUT,2,9,10,13<CR><LF>", command);
                }
            }   
            
            [TestFixture]
            public class GivenTiltLevelAndDelayButNoFade
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<RequiredParameterNotProvided>(() =>
                        MyRoomPlusOutputCommandBuilder.Create()
                            .WithOperation(MyRoomPlusCommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(MyRoomPlusOutputCommandAction.TiltLevel)
                            .WithTiltLevel(new TiltLevel(10))
                            .WithDelay(new Delay(seconds: 21))
                            .BuildSetTiltLevelCommand());

                    Assert.AreEqual("The required parameter, fade, was not provided", exception.Message);
                }
            }
        }
    }
}