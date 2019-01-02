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
                    .WithAction(MyRoomPlusOutputCommandActionNumber.OutputLevel)
                    .WithLevel(new OutputLevel(70))
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
                    .WithAction(MyRoomPlusOutputCommandActionNumber.StartRaisingOutputLevel)
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
                    .WithAction(MyRoomPlusOutputCommandActionNumber.StartLoweringOutputLevel)
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
                    .WithAction(MyRoomPlusOutputCommandActionNumber.StopRaisingOrLoweringOutputLevel)
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
                    .WithAction(MyRoomPlusOutputCommandActionNumber.FlashFrequency)
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
                    .WithAction(MyRoomPlusOutputCommandActionNumber.FlashFrequency)
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
                        .WithAction(MyRoomPlusOutputCommandActionNumber.ContactClosureOutputPulseTime)
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
                        .WithAction(MyRoomPlusOutputCommandActionNumber.ContactClosureOutputPulseTime)
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
                        .WithAction(MyRoomPlusOutputCommandActionNumber.ContactClosureOutputPulseTime)
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
                        .WithAction(MyRoomPlusOutputCommandActionNumber.TiltLevel)
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
                            .WithAction(MyRoomPlusOutputCommandActionNumber.TiltLevel)
                            .BuildSetTiltLevelCommand());

                    Assert.AreEqual("The required parameter, tilt level, is not provided", exception.Message);
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
                        .WithAction(MyRoomPlusOutputCommandActionNumber.TiltLevel)
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
                        .WithAction(MyRoomPlusOutputCommandActionNumber.TiltLevel)
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
                            .WithAction(MyRoomPlusOutputCommandActionNumber.TiltLevel)
                            .WithTiltLevel(new TiltLevel(10))
                            .WithDelay(new Delay(seconds: 21))
                            .BuildSetTiltLevelCommand());

                    Assert.AreEqual("The required parameter, fade, is not provided", exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetLiftAndTiltLevelCommand
        {
            [TestFixture]
            public class GivenLiftAndTiltLevel
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = MyRoomPlusOutputCommandBuilder.Create()
                        .WithOperation(MyRoomPlusCommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(MyRoomPlusOutputCommandActionNumber.LiftAndTiltLevel)
                        .WithLiftLevel(new LiftLevel(30))
                        .WithTiltLevel(new TiltLevel(45))
                        .BuildSetLiftAndTiltLevelCommand();

                    Assert.AreEqual("#OUTPUT,2,10,30,45<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenNoLiftLevel
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<RequiredParameterNotProvided>(() =>
                        MyRoomPlusOutputCommandBuilder.Create()
                            .WithOperation(MyRoomPlusCommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(MyRoomPlusOutputCommandActionNumber.LiftAndTiltLevel)
                            .WithTiltLevel(new TiltLevel(45))
                            .BuildSetLiftAndTiltLevelCommand());

                    Assert.AreEqual("The required parameter, lift level, is not provided", exception.Message);
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
                            .WithAction(MyRoomPlusOutputCommandActionNumber.LiftAndTiltLevel)
                            .WithLiftLevel(new LiftLevel(30))
                            .BuildSetLiftAndTiltLevelCommand());

                    Assert.AreEqual("The required parameter, tilt level, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenLiftLevelTiltLevelFadeAndDelay
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = MyRoomPlusOutputCommandBuilder.Create()
                        .WithOperation(MyRoomPlusCommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(MyRoomPlusOutputCommandActionNumber.LiftAndTiltLevel)
                        .WithLiftLevel(new LiftLevel(30))
                        .WithTiltLevel(new TiltLevel(10))
                        .WithFade(new Fade(seconds: 13))
                        .WithDelay(new Delay(seconds: 21))
                        .BuildSetLiftAndTiltLevelCommand();

                    Assert.AreEqual("#OUTPUT,2,10,30,10,13,21<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenLiftLevelTiltLevelAndFade
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = MyRoomPlusOutputCommandBuilder.Create()
                        .WithOperation(MyRoomPlusCommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(MyRoomPlusOutputCommandActionNumber.LiftAndTiltLevel)
                        .WithLiftLevel(new LiftLevel(30))
                        .WithTiltLevel(new TiltLevel(10))
                        .WithFade(new Fade(seconds: 13))
                        .BuildSetLiftAndTiltLevelCommand();

                    Assert.AreEqual("#OUTPUT,2,10,30,10,13<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenLiftLevelTiltLevelAndDelayButNoFade
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<RequiredParameterNotProvided>(() =>
                        MyRoomPlusOutputCommandBuilder.Create()
                            .WithOperation(MyRoomPlusCommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(MyRoomPlusOutputCommandActionNumber.LiftAndTiltLevel)
                            .WithLiftLevel(new LiftLevel(30))
                            .WithTiltLevel(new TiltLevel(10))
                            .WithDelay(new Delay(seconds: 21))
                            .BuildSetLiftAndTiltLevelCommand());

                    Assert.AreEqual("The required parameter, fade, is not provided", exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildStartRaisingTiltCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MyRoomPlusOutputCommandBuilder.Create()
                    .WithOperation(MyRoomPlusCommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(MyRoomPlusOutputCommandActionNumber.StartRaisingTilt)
                    .BuildStartRaisingTiltCommand();

                Assert.AreEqual("#OUTPUT,2,11<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoIntegrationId
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var exception = Assert.Throws<IntegrationIdNotProvided>(()
                        => MyRoomPlusOutputCommandBuilder.Create()
                            .WithOperation(MyRoomPlusCommandOperation.Set)
                            .WithAction(MyRoomPlusOutputCommandActionNumber.StartRaisingTilt)
                            .BuildStartRaisingTiltCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => MyRoomPlusOutputCommandBuilder.Create()
                            .WithOperation(MyRoomPlusCommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildStartRaisingTiltCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => MyRoomPlusOutputCommandBuilder.Create()
                            .WithOperation(MyRoomPlusCommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(MyRoomPlusOutputCommandActionNumber.LiftAndTiltLevel)
                            .BuildStartRaisingTiltCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 11 and not 10",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildStartLoweringTiltCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MyRoomPlusOutputCommandBuilder.Create()
                    .WithOperation(MyRoomPlusCommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(MyRoomPlusOutputCommandActionNumber.StartLoweringTilt)
                    .BuildStartLoweringTiltCommand();

                Assert.AreEqual("#OUTPUT,2,12<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoIntegrationId
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var exception = Assert.Throws<IntegrationIdNotProvided>(()
                        => MyRoomPlusOutputCommandBuilder.Create()
                            .WithOperation(MyRoomPlusCommandOperation.Set)
                            .WithAction(MyRoomPlusOutputCommandActionNumber.StartLoweringTilt)
                            .BuildStartLoweringTiltCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => MyRoomPlusOutputCommandBuilder.Create()
                            .WithOperation(MyRoomPlusCommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildStartLoweringTiltCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => MyRoomPlusOutputCommandBuilder.Create()
                            .WithOperation(MyRoomPlusCommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(MyRoomPlusOutputCommandActionNumber.LiftAndTiltLevel)
                            .BuildStartLoweringTiltCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 12 and not 10",
                        exception.Message);
                }
            }
        }
    }
}