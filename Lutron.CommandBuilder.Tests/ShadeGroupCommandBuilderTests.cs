using Lutron.Common.Enums;
using Lutron.Common.Exceptions;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.CommandBuilder.Tests
{
    [TestFixture]
    public class ShadeGroupCommandBuilderTests
    {
        [TestFixture]
        public class BuildSetShadeGroupLevelCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = ShadeGroupCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(ShadeGroupCommandActionNumber.ShadeGroupLevel)
                    .WithLevel(new ShadeGroupLevel(70))
                    .WithFade(new Fade(seconds: 4))
                    .WithDelay(new Delay(seconds: 2))
                    .BuildSetShadeGroupLevelCommand();

                Assert.AreEqual("#SHADEGRP,2,1,70,4,2<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoFadeAndNoDelay
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = ShadeGroupCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(ShadeGroupCommandActionNumber.ShadeGroupLevel)
                        .WithLevel(new ShadeGroupLevel(70))
                        .BuildSetShadeGroupLevelCommand();

                    Assert.AreEqual("#SHADEGRP,2,1,70<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenFadeAndNoDelay
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = ShadeGroupCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(ShadeGroupCommandActionNumber.ShadeGroupLevel)
                        .WithLevel(new ShadeGroupLevel(70))
                        .WithFade(new Fade(seconds: 4))
                        .BuildSetShadeGroupLevelCommand();

                    Assert.AreEqual("#SHADEGRP,2,1,70,4<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenNoFadeButDelay
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.ShadeGroupLevel)
                            .WithLevel(new ShadeGroupLevel(70))
                            .WithDelay(new Delay(seconds: 2))
                            .BuildSetShadeGroupLevelCommand());

                    Assert.AreEqual("The parameter, fade, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoShadeGroupLevel
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.ShadeGroupLevel)
                            .WithFade(new Fade(seconds: 4))
                            .WithDelay(new Delay(seconds: 2))
                            .BuildSetShadeGroupLevelCommand());

                    Assert.AreEqual("The parameter, shade group level, is not provided",
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.ShadeGroupLevel)
                            .WithLevel(new ShadeGroupLevel(70))
                            .WithFade(new Fade(seconds: 4))
                            .WithDelay(new Delay(seconds: 2))
                            .BuildSetShadeGroupLevelCommand());

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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.ShadeGroupLevel)
                            .WithLevel(new ShadeGroupLevel(70))
                            .WithFade(new Fade(seconds: 4))
                            .WithDelay(new Delay(seconds: 2))
                            .BuildSetShadeGroupLevelCommand());

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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(ShadeGroupCommandActionNumber.ShadeGroupLevel)
                            .WithLevel(new ShadeGroupLevel(70))
                            .WithFade(new Fade(seconds: 4))
                            .WithDelay(new Delay(seconds: 2))
                            .BuildSetShadeGroupLevelCommand());

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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithLevel(new ShadeGroupLevel(70))
                            .WithFade(new Fade(seconds: 4))
                            .WithDelay(new Delay(seconds: 2))
                            .BuildSetShadeGroupLevelCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectShadeGroupCommandActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.LiftAndTiltLevel)
                            .WithLevel(new ShadeGroupLevel(70))
                            .WithFade(new Fade(seconds: 4))
                            .WithDelay(new Delay(seconds: 2))
                            .BuildSetShadeGroupLevelCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 1 and not 15",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetShadeGroupLevelCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = ShadeGroupCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(ShadeGroupCommandActionNumber.ShadeGroupLevel)
                    .BuildGetShadeGroupLevelCommand();

                Assert.AreEqual("?SHADEGRP,2,1<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.ShadeGroupLevel)
                            .BuildGetShadeGroupLevelCommand());

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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.ShadeGroupLevel)
                            .BuildGetShadeGroupLevelCommand());

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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(ShadeGroupCommandActionNumber.ShadeGroupLevel)
                            .BuildGetShadeGroupLevelCommand());

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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetShadeGroupLevelCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectShadeGroupCommandActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.LiftAndTiltLevel)
                            .BuildGetShadeGroupLevelCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 1 and not 15",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildStartRaisingShadeGroupLevelCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = ShadeGroupCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(ShadeGroupCommandActionNumber.StartRaisingShadeGroupLevel)
                    .BuildStartRaisingShadeGroupLevelCommand();

                Assert.AreEqual("#SHADEGRP,2,2<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.StartRaisingShadeGroupLevel)
                            .BuildStartRaisingShadeGroupLevelCommand());

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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.StartRaisingShadeGroupLevel)
                            .BuildStartRaisingShadeGroupLevelCommand());

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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(ShadeGroupCommandActionNumber.StartRaisingShadeGroupLevel)
                            .BuildStartRaisingShadeGroupLevelCommand());

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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildStartRaisingShadeGroupLevelCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectShadeGroupCommandActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.LiftAndTiltLevel)
                            .BuildStartRaisingShadeGroupLevelCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 2 and not 15",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildStartLoweringShadeGroupLevelCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = ShadeGroupCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(ShadeGroupCommandActionNumber.StartLoweringShadeGroupLevel)
                    .BuildStartLoweringShadeGroupLevelCommand();

                Assert.AreEqual("#SHADEGRP,2,3<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.StartLoweringShadeGroupLevel)
                            .BuildStartLoweringShadeGroupLevelCommand());

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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.StartLoweringShadeGroupLevel)
                            .BuildStartLoweringShadeGroupLevelCommand());

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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(ShadeGroupCommandActionNumber.StartLoweringShadeGroupLevel)
                            .BuildStartLoweringShadeGroupLevelCommand());

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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildStartLoweringShadeGroupLevelCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectShadeGroupCommandActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.LiftAndTiltLevel)
                            .BuildStartLoweringShadeGroupLevelCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 3 and not 15",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildStopRaisingOrLoweringShadeGroupLevelCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = ShadeGroupCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(ShadeGroupCommandActionNumber.StopRaisingOrLoweringShadeGroupLevel)
                    .BuildStopRaisingOrLoweringShadeGroupLevelCommand();

                Assert.AreEqual("#SHADEGRP,2,4<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.StopRaisingOrLoweringShadeGroupLevel)
                            .BuildStopRaisingOrLoweringShadeGroupLevelCommand());

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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.StopRaisingOrLoweringShadeGroupLevel)
                            .BuildStopRaisingOrLoweringShadeGroupLevelCommand());

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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(ShadeGroupCommandActionNumber.StopRaisingOrLoweringShadeGroupLevel)
                            .BuildStopRaisingOrLoweringShadeGroupLevelCommand());

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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildStopRaisingOrLoweringShadeGroupLevelCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectShadeGroupCommandActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.LiftAndTiltLevel)
                            .BuildStopRaisingOrLoweringShadeGroupLevelCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 4 and not 15",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetCurrentPresetCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = ShadeGroupCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(ShadeGroupCommandActionNumber.CurrentPreset)
                    .BuildGetCurrentPresetCommand();

                Assert.AreEqual("?SHADEGRP,2,6<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.CurrentPreset)
                            .BuildGetCurrentPresetCommand());

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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.CurrentPreset)
                            .BuildGetCurrentPresetCommand());

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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(ShadeGroupCommandActionNumber.CurrentPreset)
                            .BuildGetCurrentPresetCommand());

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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetCurrentPresetCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectShadeGroupCommandActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.LiftAndTiltLevel)
                            .BuildGetCurrentPresetCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 6 and not 15",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetCurrentPresetCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = ShadeGroupCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(ShadeGroupCommandActionNumber.CurrentPreset)
                    .WithPresetNumber(new PresetNumber( 2))
                    .BuildSetCurrentPresetCommand();

                Assert.AreEqual("#SHADEGRP,2,6,2<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoPresetNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.CurrentPreset)
                            .BuildSetCurrentPresetCommand());

                    Assert.AreEqual("The parameter, preset number, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.CurrentPreset)
                            .BuildSetCurrentPresetCommand());

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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.CurrentPreset)
                            .BuildSetCurrentPresetCommand());

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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(ShadeGroupCommandActionNumber.CurrentPreset)
                            .BuildSetCurrentPresetCommand());

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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetCurrentPresetCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectShadeGroupCommandActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.LiftAndTiltLevel)
                            .BuildSetCurrentPresetCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 6 and not 15",
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
                    var command = ShadeGroupCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(ShadeGroupCommandActionNumber.TiltLevel)
                        .WithTiltLevel(new TiltLevel(45))
                        .BuildSetTiltLevelCommand();

                    Assert.AreEqual("#SHADEGRP,2,14,45<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenNoTiltLevel
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(() =>
                        ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.TiltLevel)
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
                    var command = ShadeGroupCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(ShadeGroupCommandActionNumber.TiltLevel)
                        .WithTiltLevel(new TiltLevel(10))
                        .WithFade(new Fade(seconds: 13))
                        .WithDelay(new Delay(seconds: 21))
                        .BuildSetTiltLevelCommand();

                    Assert.AreEqual("#SHADEGRP,2,14,10,13,21<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenTiltLevelAndFade
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = ShadeGroupCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(ShadeGroupCommandActionNumber.TiltLevel)
                        .WithTiltLevel(new TiltLevel(10))
                        .WithFade(new Fade(seconds: 13))
                        .BuildSetTiltLevelCommand();

                    Assert.AreEqual("#SHADEGRP,2,14,10,13<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenTiltLevelAndDelayButNoFade
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(() =>
                        ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.TiltLevel)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.TiltLevel)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.TiltLevel)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(ShadeGroupCommandActionNumber.TiltLevel)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetTiltLevelCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectShadeGroupCommandActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.LiftAndTiltLevel)
                            .BuildSetTiltLevelCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 14 and not 15",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoFadeAndNoDelay
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = ShadeGroupCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(ShadeGroupCommandActionNumber.TiltLevel)
                        .WithTiltLevel(new TiltLevel(45))
                        .BuildSetTiltLevelCommand();

                    Assert.AreEqual("#SHADEGRP,2,14,45<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenFadeAndNoDelay
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = ShadeGroupCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(ShadeGroupCommandActionNumber.TiltLevel)
                        .WithTiltLevel(new TiltLevel(45))
                        .WithFade(new Fade(seconds: 4))
                        .BuildSetTiltLevelCommand();

                    Assert.AreEqual("#SHADEGRP,2,14,45,4<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenNoFadeButDelay
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.TiltLevel)
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
                    var command = ShadeGroupCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(ShadeGroupCommandActionNumber.LiftAndTiltLevel)
                        .WithLiftLevel(new LiftLevel(30))
                        .WithTiltLevel(new TiltLevel(45))
                        .BuildSetLiftAndTiltLevelCommand();

                    Assert.AreEqual("#SHADEGRP,2,15,30,45<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenNoLiftLevel
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(() =>
                        ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.LiftAndTiltLevel)
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
                        ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.LiftAndTiltLevel)
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
                    var command = ShadeGroupCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(ShadeGroupCommandActionNumber.LiftAndTiltLevel)
                        .WithLiftLevel(new LiftLevel(30))
                        .WithTiltLevel(new TiltLevel(10))
                        .WithFade(new Fade(seconds: 13))
                        .WithDelay(new Delay(seconds: 21))
                        .BuildSetLiftAndTiltLevelCommand();

                    Assert.AreEqual("#SHADEGRP,2,15,30,10,13,21<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenLiftLevelTiltLevelAndFade
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = ShadeGroupCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(ShadeGroupCommandActionNumber.LiftAndTiltLevel)
                        .WithLiftLevel(new LiftLevel(30))
                        .WithTiltLevel(new TiltLevel(10))
                        .WithFade(new Fade(seconds: 13))
                        .BuildSetLiftAndTiltLevelCommand();

                    Assert.AreEqual("#SHADEGRP,2,15,30,10,13<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenLiftLevelTiltLevelAndDelayButNoFade
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(() =>
                        ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.LiftAndTiltLevel)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.LiftAndTiltLevel)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.LiftAndTiltLevel)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(ShadeGroupCommandActionNumber.LiftAndTiltLevel)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetLiftAndTiltLevelCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectShadeGroupCommandActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.StartLoweringShadeGroupLevel)
                            .BuildSetLiftAndTiltLevelCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 15 and not 3",
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
                var command = ShadeGroupCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(ShadeGroupCommandActionNumber.StartRaisingTilt)
                    .BuildStartRaisingTiltCommand();

                Assert.AreEqual("#SHADEGRP,2,16<CR><LF>", command);
            }
       
            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.StartRaisingTilt)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.StartRaisingTilt)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(ShadeGroupCommandActionNumber.StartRaisingTilt)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildStartRaisingTiltCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectShadeGroupCommandActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.LiftAndTiltLevel)
                            .BuildStartRaisingTiltCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 16 and not 15",
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
                var command = ShadeGroupCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(ShadeGroupCommandActionNumber.StartLoweringTilt)
                    .BuildStartLoweringTiltCommand();

                Assert.AreEqual("#SHADEGRP,2,17<CR><LF>", command);
            }
       
            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.StartLoweringTilt)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.StartLoweringTilt)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(ShadeGroupCommandActionNumber.StartLoweringTilt)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildStartLoweringTiltCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectShadeGroupCommandActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.LiftAndTiltLevel)
                            .BuildStartLoweringTiltCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 17 and not 15",
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
                var command = ShadeGroupCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(ShadeGroupCommandActionNumber.StopRaisingOrLoweringTilt)
                    .BuildStopRaisingOrLoweringTiltCommand();

                Assert.AreEqual("#SHADEGRP,2,18<CR><LF>", command);
            }
       
            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.StopRaisingOrLoweringTilt)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.StopRaisingOrLoweringTilt)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(ShadeGroupCommandActionNumber.StopRaisingOrLoweringTilt)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildStopRaisingOrLoweringTiltCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectShadeGroupCommandActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.LiftAndTiltLevel)
                            .BuildStopRaisingOrLoweringTiltCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 18 and not 15",
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
                var command = ShadeGroupCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(ShadeGroupCommandActionNumber.StartRaisingLift)
                    .BuildStartRaisingLiftCommand();

                Assert.AreEqual("#SHADEGRP,2,19<CR><LF>", command);
            }
       
            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.StartRaisingLift)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.StartRaisingLift)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(ShadeGroupCommandActionNumber.StartRaisingLift)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildStartRaisingLiftCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectShadeGroupCommandActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.LiftAndTiltLevel)
                            .BuildStartRaisingLiftCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 19 and not 15",
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
                var command = ShadeGroupCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(ShadeGroupCommandActionNumber.StartLoweringLift)
                    .BuildStartLoweringLiftCommand();

                Assert.AreEqual("#SHADEGRP,2,20<CR><LF>", command);
            }
       
            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.StartLoweringLift)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.StartLoweringLift)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(ShadeGroupCommandActionNumber.StartLoweringLift)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildStartLoweringLiftCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectShadeGroupCommandActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.LiftAndTiltLevel)
                            .BuildStartLoweringLiftCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 20 and not 15",
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
                var command = ShadeGroupCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(ShadeGroupCommandActionNumber.StopRaisingOrLoweringLift)
                    .BuildStopRaisingOrLoweringLiftCommand();

                Assert.AreEqual("#SHADEGRP,2,21<CR><LF>", command);
            }
       
            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.StopRaisingOrLoweringLift)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.StopRaisingOrLoweringLift)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(ShadeGroupCommandActionNumber.StopRaisingOrLoweringLift)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildStopRaisingOrLoweringLiftCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectShadeGroupCommandActionNumber
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.LiftAndTiltLevel)
                            .BuildStopRaisingOrLoweringLiftCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 21 and not 15",
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
                    var command = ShadeGroupCommandBuilder.Create()
                        .WithOperation(CommandOperation.Get)
                        .WithIntegrationId(2)
                        .WithAction(ShadeGroupCommandActionNumber.HorizontalSheerShadeRegion)
                        .WithHorizontalSheerShadeRegion(HorizontalSheerShadeRegion.Lift)
                        .BuildGetHorizontalSheerShadeRegionCommand();

                    Assert.AreEqual("?SHADEGRP,2,28,0<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenTiltRegion
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = ShadeGroupCommandBuilder.Create()
                        .WithOperation(CommandOperation.Get)
                        .WithIntegrationId(2)
                        .WithAction(ShadeGroupCommandActionNumber.HorizontalSheerShadeRegion)
                        .WithHorizontalSheerShadeRegion(HorizontalSheerShadeRegion.Tilt)
                        .BuildGetHorizontalSheerShadeRegionCommand();

                    Assert.AreEqual("?SHADEGRP,2,28,1<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenNoLiftOrTiltRegion
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = ShadeGroupCommandBuilder.Create()
                        .WithOperation(CommandOperation.Get)
                        .WithIntegrationId(2)
                        .WithAction(ShadeGroupCommandActionNumber.HorizontalSheerShadeRegion)
                        .BuildGetHorizontalSheerShadeRegionCommand();

                    Assert.AreEqual("?SHADEGRP,2,28,0<CR><LF>", command);
                }
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.HorizontalSheerShadeRegion)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.HorizontalSheerShadeRegion)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(ShadeGroupCommandActionNumber.HorizontalSheerShadeRegion)
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
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetHorizontalSheerShadeRegionCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }


            [TestFixture]
            public class GivenIncorrectShadeGroupCommandActionNumber
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => ShadeGroupCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(ShadeGroupCommandActionNumber.LiftAndTiltLevel)
                            .BuildGetHorizontalSheerShadeRegionCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 28 and not 15",
                        exception.Message);
                }
            }
        }
    }
}