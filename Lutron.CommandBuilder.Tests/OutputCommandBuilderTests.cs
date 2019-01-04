using Lutron.Common.Enums;
using Lutron.Common.Exceptions;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.CommandBuilder.Tests
{
    [TestFixture]
    public class OutputCommandBuilderTests
    {
        [TestFixture]
        public class BuildSetOutputLevelCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = OutputCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(OutputCommandActionNumber.OutputLevel)
                    .WithLevel(new OutputLevel(70))
                    .WithFade(new Fade(seconds: 4))
                    .WithDelay(new Delay(seconds: 2))
                    .BuildSetOutputLevelCommand();

                Assert.AreEqual("#OUTPUT,2,1,70,4,2<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoFadeAndNoDelay
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = OutputCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(OutputCommandActionNumber.OutputLevel)
                        .WithLevel(new OutputLevel(70))
                        .BuildSetOutputLevelCommand();

                    Assert.AreEqual("#OUTPUT,2,1,70<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenFadeAndNoDelay
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = OutputCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(OutputCommandActionNumber.OutputLevel)
                        .WithLevel(new OutputLevel(70))
                        .WithFade(new Fade(seconds: 4))
                        .BuildSetOutputLevelCommand();

                    Assert.AreEqual("#OUTPUT,2,1,70,4<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenNoFadeButDelay
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.OutputLevel)
                            .WithLevel(new OutputLevel(70))
                            .WithDelay(new Delay(seconds: 2))
                            .BuildSetOutputLevelCommand());

                    Assert.AreEqual("The parameter, fade, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoOutputLevel
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.OutputLevel)
                            .WithFade(new Fade(seconds: 4))
                            .WithDelay(new Delay(seconds: 2))
                            .BuildSetOutputLevelCommand());

                    Assert.AreEqual("The parameter, output level, is not provided",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.OutputLevel)
                            .WithLevel(new OutputLevel(70))
                            .WithFade(new Fade(seconds: 4))
                            .WithDelay(new Delay(seconds: 2))
                            .BuildSetOutputLevelCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.OutputLevel)
                            .WithLevel(new OutputLevel(70))
                            .WithFade(new Fade(seconds: 4))
                            .WithDelay(new Delay(seconds: 2))
                            .BuildSetOutputLevelCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected # and not ?",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoIntegrationId
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IntegrationIdNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(OutputCommandActionNumber.OutputLevel)
                            .WithLevel(new OutputLevel(70))
                            .WithFade(new Fade(seconds: 4))
                            .WithDelay(new Delay(seconds: 2))
                            .BuildSetOutputLevelCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithLevel(new OutputLevel(70))
                            .WithFade(new Fade(seconds: 4))
                            .WithDelay(new Delay(seconds: 2))
                            .BuildSetOutputLevelCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.LiftAndTiltLevel)
                            .WithLevel(new OutputLevel(70))
                            .WithFade(new Fade(seconds: 4))
                            .WithDelay(new Delay(seconds: 2))
                            .BuildSetOutputLevelCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 1 and not 10",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetOutputLevelCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = OutputCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(OutputCommandActionNumber.OutputLevel)
                    .BuildGetOutputLevelCommand();

                Assert.AreEqual("?OUTPUT,2,1<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.OutputLevel)
                            .BuildGetOutputLevelCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.OutputLevel)
                            .BuildGetOutputLevelCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected ? and not #",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoIntegrationId
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IntegrationIdNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(OutputCommandActionNumber.OutputLevel)
                            .BuildGetOutputLevelCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetOutputLevelCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.LiftAndTiltLevel)
                            .BuildGetOutputLevelCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 1 and not 10",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildStartRaisingOutputLevelCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = OutputCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(OutputCommandActionNumber.StartRaisingOutputLevel)
                    .BuildStartRaisingOutputLevelCommand();

                Assert.AreEqual("#OUTPUT,2,2<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.StartRaisingOutputLevel)
                            .BuildStartRaisingOutputLevelCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.StartRaisingOutputLevel)
                            .BuildStartRaisingOutputLevelCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected # and not ?",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoIntegrationId
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IntegrationIdNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(OutputCommandActionNumber.StartRaisingOutputLevel)
                            .BuildStartRaisingOutputLevelCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildStartRaisingOutputLevelCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.LiftAndTiltLevel)
                            .BuildStartRaisingOutputLevelCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 2 and not 10",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildStartLoweringOutputLevelCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = OutputCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(OutputCommandActionNumber.StartLoweringOutputLevel)
                    .BuildStartLoweringOutputLevelCommand();

                Assert.AreEqual("#OUTPUT,2,3<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.StartLoweringOutputLevel)
                            .BuildStartLoweringOutputLevelCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.StartLoweringOutputLevel)
                            .BuildStartLoweringOutputLevelCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected # and not ?",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoIntegrationId
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IntegrationIdNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(OutputCommandActionNumber.StartLoweringOutputLevel)
                            .BuildStartLoweringOutputLevelCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildStartLoweringOutputLevelCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.LiftAndTiltLevel)
                            .BuildStartLoweringOutputLevelCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 3 and not 10",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildStopRaisingOrLoweringOutputLevelCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = OutputCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(OutputCommandActionNumber.StopRaisingOrLoweringOutputLevel)
                    .BuildStopRaisingOrLoweringOutputLevelCommand();

                Assert.AreEqual("#OUTPUT,2,4<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.StopRaisingOrLoweringOutputLevel)
                            .BuildStopRaisingOrLoweringOutputLevelCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.StopRaisingOrLoweringOutputLevel)
                            .BuildStopRaisingOrLoweringOutputLevelCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected # and not ?",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoIntegrationId
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IntegrationIdNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(OutputCommandActionNumber.StopRaisingOrLoweringOutputLevel)
                            .BuildStopRaisingOrLoweringOutputLevelCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildStopRaisingOrLoweringOutputLevelCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.LiftAndTiltLevel)
                            .BuildStopRaisingOrLoweringOutputLevelCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 4 and not 10",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetFlashFrequencyCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = OutputCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(OutputCommandActionNumber.FlashFrequency)
                    .BuildGetFlashFrequencyCommand();

                Assert.AreEqual("?OUTPUT,2,5<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.FlashFrequency)
                            .BuildGetFlashFrequencyCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.FlashFrequency)
                            .BuildGetFlashFrequencyCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected ? and not #",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoIntegrationId
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IntegrationIdNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(OutputCommandActionNumber.FlashFrequency)
                            .BuildGetFlashFrequencyCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetFlashFrequencyCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.LiftAndTiltLevel)
                            .BuildGetFlashFrequencyCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 5 and not 10",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetFlashFrequencyCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = OutputCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(OutputCommandActionNumber.FlashFrequency)
                    .WithFade(new Fade(seconds: 2))
                    .WithDelay(new Delay(seconds: 45))
                    .BuildSetFlashFrequencyCommand();

                Assert.AreEqual("#OUTPUT,2,5,2,45<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.FlashFrequency)
                            .BuildSetFlashFrequencyCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.FlashFrequency)
                            .BuildSetFlashFrequencyCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected # and not ?",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoIntegrationId
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IntegrationIdNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(OutputCommandActionNumber.FlashFrequency)
                            .BuildSetFlashFrequencyCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetFlashFrequencyCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.LiftAndTiltLevel)
                            .BuildSetFlashFrequencyCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 5 and not 10",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoFadeAndNoDelay
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = OutputCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(OutputCommandActionNumber.FlashFrequency)
                        .BuildSetFlashFrequencyCommand();

                    Assert.AreEqual("#OUTPUT,2,5<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenFadeAndNoDelay
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = OutputCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(OutputCommandActionNumber.FlashFrequency)
                        .WithFade(new Fade(seconds: 4))
                        .BuildSetFlashFrequencyCommand();

                    Assert.AreEqual("#OUTPUT,2,5,4<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenNoFadeButDelay
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.FlashFrequency)
                            .WithDelay(new Delay(seconds: 2))
                            .BuildSetFlashFrequencyCommand());

                    Assert.AreEqual("The parameter, fade, is not provided", exception.Message);
                }
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
                    var command = OutputCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(OutputCommandActionNumber.ContactClosureOutputPulseTime)
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
                    var command = OutputCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(OutputCommandActionNumber.ContactClosureOutputPulseTime)
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
                    var command = OutputCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(OutputCommandActionNumber.ContactClosureOutputPulseTime)
                        .BuildSetContactClosureOutputPulseTimeCommand();

                    Assert.AreEqual("#OUTPUT,2,6<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.ContactClosureOutputPulseTime)
                            .BuildSetContactClosureOutputPulseTimeCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.ContactClosureOutputPulseTime)
                            .BuildSetContactClosureOutputPulseTimeCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected # and not ?",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoIntegrationId
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IntegrationIdNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(OutputCommandActionNumber.ContactClosureOutputPulseTime)
                            .BuildSetContactClosureOutputPulseTimeCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetContactClosureOutputPulseTimeCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.LiftAndTiltLevel)
                            .BuildSetContactClosureOutputPulseTimeCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 6 and not 10",
                        exception.Message);
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
                    var command = OutputCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(OutputCommandActionNumber.TiltLevel)
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
                    var exception = Assert.Throws<ParameterNotProvided>(() =>
                        OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.TiltLevel)
                            .BuildSetTiltLevelCommand());

                    Assert.AreEqual("The parameter, tilt level, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenTiltLevelFadeAndDelay
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = OutputCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(OutputCommandActionNumber.TiltLevel)
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
                    var command = OutputCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(OutputCommandActionNumber.TiltLevel)
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
                    var exception = Assert.Throws<ParameterNotProvided>(() =>
                        OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.TiltLevel)
                            .WithTiltLevel(new TiltLevel(10))
                            .WithDelay(new Delay(seconds: 21))
                            .BuildSetTiltLevelCommand());

                    Assert.AreEqual("The parameter, fade, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.TiltLevel)
                            .BuildSetTiltLevelCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.TiltLevel)
                            .BuildSetTiltLevelCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected # and not ?",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoIntegrationId
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IntegrationIdNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(OutputCommandActionNumber.TiltLevel)
                            .BuildSetTiltLevelCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetTiltLevelCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.LiftAndTiltLevel)
                            .BuildSetTiltLevelCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 9 and not 10",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoFadeAndNoDelay
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = OutputCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(OutputCommandActionNumber.TiltLevel)
                        .WithTiltLevel(new TiltLevel(45))
                        .BuildSetTiltLevelCommand();

                    Assert.AreEqual("#OUTPUT,2,9,45<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenFadeAndNoDelay
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = OutputCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(OutputCommandActionNumber.TiltLevel)
                        .WithTiltLevel(new TiltLevel(45))
                        .WithFade(new Fade(seconds: 4))
                        .BuildSetTiltLevelCommand();

                    Assert.AreEqual("#OUTPUT,2,9,45,4<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenNoFadeButDelay
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.TiltLevel)
                            .WithTiltLevel(new TiltLevel(45))
                            .WithDelay(new Delay(seconds: 2))
                            .BuildSetTiltLevelCommand());

                    Assert.AreEqual("The parameter, fade, is not provided", exception.Message);
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
                    var command = OutputCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(OutputCommandActionNumber.LiftAndTiltLevel)
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
                    var exception = Assert.Throws<ParameterNotProvided>(() =>
                        OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.LiftAndTiltLevel)
                            .WithTiltLevel(new TiltLevel(45))
                            .BuildSetLiftAndTiltLevelCommand());

                    Assert.AreEqual("The parameter, lift level, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoTiltLevel
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(() =>
                        OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.LiftAndTiltLevel)
                            .WithLiftLevel(new LiftLevel(30))
                            .BuildSetLiftAndTiltLevelCommand());

                    Assert.AreEqual("The parameter, tilt level, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenLiftLevelTiltLevelFadeAndDelay
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = OutputCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(OutputCommandActionNumber.LiftAndTiltLevel)
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
                    var command = OutputCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(OutputCommandActionNumber.LiftAndTiltLevel)
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
                    var exception = Assert.Throws<ParameterNotProvided>(() =>
                        OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.LiftAndTiltLevel)
                            .WithLiftLevel(new LiftLevel(30))
                            .WithTiltLevel(new TiltLevel(10))
                            .WithDelay(new Delay(seconds: 21))
                            .BuildSetLiftAndTiltLevelCommand());

                    Assert.AreEqual("The parameter, fade, is not provided", exception.Message);
                }
            }
       
            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.LiftAndTiltLevel)
                            .BuildSetLiftAndTiltLevelCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.LiftAndTiltLevel)
                            .BuildSetLiftAndTiltLevelCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected # and not ?",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoIntegrationId
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IntegrationIdNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(OutputCommandActionNumber.LiftAndTiltLevel)
                            .BuildSetLiftAndTiltLevelCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetLiftAndTiltLevelCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.StartLoweringOutputLevel)
                            .BuildSetLiftAndTiltLevelCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 10 and not 3",
                        exception.Message);
                }
            }
 }

        [TestFixture]
        public class BuildStartRaisingTiltCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = OutputCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(OutputCommandActionNumber.StartRaisingTilt)
                    .BuildStartRaisingTiltCommand();

                Assert.AreEqual("#OUTPUT,2,11<CR><LF>", command);
            }
       
            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.StartRaisingTilt)
                            .BuildStartRaisingTiltCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.StartRaisingTilt)
                            .BuildStartRaisingTiltCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected # and not ?",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoIntegrationId
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IntegrationIdNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(OutputCommandActionNumber.StartRaisingTilt)
                            .BuildStartRaisingTiltCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildStartRaisingTiltCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.LiftAndTiltLevel)
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
                var command = OutputCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(OutputCommandActionNumber.StartLoweringTilt)
                    .BuildStartLoweringTiltCommand();

                Assert.AreEqual("#OUTPUT,2,12<CR><LF>", command);
            }
       
            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.StartLoweringTilt)
                            .BuildStartLoweringTiltCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.StartLoweringTilt)
                            .BuildStartLoweringTiltCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected # and not ?",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoIntegrationId
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IntegrationIdNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(OutputCommandActionNumber.StartLoweringTilt)
                            .BuildStartLoweringTiltCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildStartLoweringTiltCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.LiftAndTiltLevel)
                            .BuildStartLoweringTiltCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 12 and not 10",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildStopRaisingOrLoweringTiltCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = OutputCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(OutputCommandActionNumber.StopRaisingOrLoweringTilt)
                    .BuildStopRaisingOrLoweringTiltCommand();

                Assert.AreEqual("#OUTPUT,2,13<CR><LF>", command);
            }
       
            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.StopRaisingOrLoweringTilt)
                            .BuildStopRaisingOrLoweringTiltCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.StopRaisingOrLoweringTilt)
                            .BuildStopRaisingOrLoweringTiltCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected # and not ?",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoIntegrationId
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IntegrationIdNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(OutputCommandActionNumber.StopRaisingOrLoweringTilt)
                            .BuildStopRaisingOrLoweringTiltCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildStopRaisingOrLoweringTiltCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.LiftAndTiltLevel)
                            .BuildStopRaisingOrLoweringTiltCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 13 and not 10",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildStartRaisingLiftCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = OutputCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(OutputCommandActionNumber.StartRaisingLift)
                    .BuildStartRaisingLiftCommand();

                Assert.AreEqual("#OUTPUT,2,14<CR><LF>", command);
            }
       
            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.StartRaisingLift)
                            .BuildStartRaisingLiftCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.StartRaisingLift)
                            .BuildStartRaisingLiftCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected # and not ?",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoIntegrationId
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IntegrationIdNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(OutputCommandActionNumber.StartRaisingLift)
                            .BuildStartRaisingLiftCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildStartRaisingLiftCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.LiftAndTiltLevel)
                            .BuildStartRaisingLiftCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 14 and not 10",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildStartLoweringLiftCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = OutputCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(OutputCommandActionNumber.StartLoweringLift)
                    .BuildStartLoweringLiftCommand();

                Assert.AreEqual("#OUTPUT,2,15<CR><LF>", command);
            }
       
            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.StartLoweringLift)
                            .BuildStartLoweringLiftCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.StartLoweringLift)
                            .BuildStartLoweringLiftCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected # and not ?",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoIntegrationId
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IntegrationIdNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(OutputCommandActionNumber.StartLoweringLift)
                            .BuildStartLoweringLiftCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildStartLoweringLiftCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.LiftAndTiltLevel)
                            .BuildStartLoweringLiftCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 15 and not 10",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildStopRaisingOrLoweringLiftCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = OutputCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(OutputCommandActionNumber.StopRaisingOrLoweringLift)
                    .BuildStopRaisingOrLoweringLiftCommand();

                Assert.AreEqual("#OUTPUT,2,16<CR><LF>", command);
            }
       
            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.StopRaisingOrLoweringLift)
                            .BuildStopRaisingOrLoweringLiftCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.StopRaisingOrLoweringLift)
                            .BuildStopRaisingOrLoweringLiftCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected # and not ?",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoIntegrationId
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var exception = Assert.Throws<IntegrationIdNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(OutputCommandActionNumber.StopRaisingOrLoweringLift)
                            .BuildStopRaisingOrLoweringLiftCommand());

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
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildStopRaisingOrLoweringLiftCommand());

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
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.LiftAndTiltLevel)
                            .BuildStopRaisingOrLoweringLiftCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 16 and not 10",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetHorizontalSheerShadeRegionCommand
        {
            [TestFixture]
            public class GivenLiftRegion
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = OutputCommandBuilder.Create()
                        .WithOperation(CommandOperation.Get)
                        .WithIntegrationId(2)
                        .WithAction(OutputCommandActionNumber.HorizontalSheerShadeRegion)
                        .WithHorizontalSheerShadeRegion(HorizontalSheerShadeRegion.Lift)
                        .BuildGetHorizontalSheerShadeRegionCommand();

                    Assert.AreEqual("?OUTPUT,2,28,0<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenTiltRegion
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = OutputCommandBuilder.Create()
                        .WithOperation(CommandOperation.Get)
                        .WithIntegrationId(2)
                        .WithAction(OutputCommandActionNumber.HorizontalSheerShadeRegion)
                        .WithHorizontalSheerShadeRegion(HorizontalSheerShadeRegion.Tilt)
                        .BuildGetHorizontalSheerShadeRegionCommand();

                    Assert.AreEqual("?OUTPUT,2,28,1<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenNoLiftOrTiltRegion
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = OutputCommandBuilder.Create()
                        .WithOperation(CommandOperation.Get)
                        .WithIntegrationId(2)
                        .WithAction(OutputCommandActionNumber.HorizontalSheerShadeRegion)
                        .BuildGetHorizontalSheerShadeRegionCommand();

                    Assert.AreEqual("?OUTPUT,2,28,0<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.HorizontalSheerShadeRegion)
                            .BuildGetHorizontalSheerShadeRegionCommand());

                    Assert.AreEqual("The operation is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectOperationProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.HorizontalSheerShadeRegion)
                            .BuildGetHorizontalSheerShadeRegionCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected ? and not #",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoIntegrationId
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var exception = Assert.Throws<IntegrationIdNotProvided>(()
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(OutputCommandActionNumber.HorizontalSheerShadeRegion)
                            .BuildGetHorizontalSheerShadeRegionCommand());

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
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetHorizontalSheerShadeRegionCommand());

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
                        => OutputCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(OutputCommandActionNumber.LiftAndTiltLevel)
                            .BuildGetHorizontalSheerShadeRegionCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 28 and not 10",
                        exception.Message);
                }
            }
        }
    }
}