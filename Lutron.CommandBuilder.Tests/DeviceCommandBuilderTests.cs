using Lutron.Common.Enums;
using Lutron.Common.Exceptions;
using NUnit.Framework;

namespace Lutron.CommandBuilder.Tests
{
    [TestFixture]
    public class DeviceCommandBuilderTests
    {
        [TestFixture]
        public class BuildPressCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = DeviceCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithComponent(301)
                    .WithAction(DeviceCommandActionNumber.Press)
                    .BuildPressCommand();

                Assert.AreEqual("#DEVICE,2,301,3<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => DeviceCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithComponent(301)
                            .WithAction(DeviceCommandActionNumber.Press)
                            .BuildPressCommand());

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
                        => DeviceCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithComponent(301)
                            .WithAction(DeviceCommandActionNumber.Press)
                            .BuildPressCommand());

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
                        => DeviceCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithComponent(301)
                            .WithAction(DeviceCommandActionNumber.Press)
                            .BuildPressCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoComponentNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ComponentNumberNotProvided>(()
                        => DeviceCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(DeviceCommandActionNumber.Press)
                            .BuildPressCommand());

                    Assert.AreEqual("The component number is not provided",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => DeviceCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithComponent(301)
                            .BuildPressCommand());

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
                        => DeviceCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithComponent(301)
                            .WithAction(DeviceCommandActionNumber.Release)
                            .BuildPressCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 3 and not 4",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildReleaseCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = DeviceCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithComponent(301)
                    .WithAction(DeviceCommandActionNumber.Release)
                    .BuildReleaseCommand();

                Assert.AreEqual("#DEVICE,2,301,4<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => DeviceCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithComponent(301)
                            .WithAction(DeviceCommandActionNumber.Release)
                            .BuildReleaseCommand());

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
                        => DeviceCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithComponent(301)
                            .WithAction(DeviceCommandActionNumber.Release)
                            .BuildReleaseCommand());

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
                        => DeviceCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithComponent(301)
                            .WithAction(DeviceCommandActionNumber.Release)
                            .BuildReleaseCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoComponentNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ComponentNumberNotProvided>(()
                        => DeviceCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(DeviceCommandActionNumber.Release)
                            .BuildReleaseCommand());

                    Assert.AreEqual("The component number is not provided",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => DeviceCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithComponent(301)
                            .BuildReleaseCommand());

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
                        => DeviceCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithComponent(301)
                            .WithAction(DeviceCommandActionNumber.DoubleTap)
                            .BuildReleaseCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 4 and not 6",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildDoubleTapCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = DeviceCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithComponent(301)
                    .WithAction(DeviceCommandActionNumber.DoubleTap)
                    .BuildDoubleTapCommand();

                Assert.AreEqual("#DEVICE,2,301,6<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => DeviceCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithComponent(301)
                            .WithAction(DeviceCommandActionNumber.DoubleTap)
                            .BuildDoubleTapCommand());

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
                        => DeviceCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithComponent(301)
                            .WithAction(DeviceCommandActionNumber.DoubleTap)
                            .BuildDoubleTapCommand());

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
                        => DeviceCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithComponent(301)
                            .WithAction(DeviceCommandActionNumber.DoubleTap)
                            .BuildDoubleTapCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoComponentNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ComponentNumberNotProvided>(()
                        => DeviceCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(DeviceCommandActionNumber.DoubleTap)
                            .BuildDoubleTapCommand());

                    Assert.AreEqual("The component number is not provided",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => DeviceCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithComponent(301)
                            .BuildDoubleTapCommand());

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
                        => DeviceCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithComponent(301)
                            .WithAction(DeviceCommandActionNumber.Hold)
                            .BuildDoubleTapCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 6 and not 5",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildHoldCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = DeviceCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithComponent(301)
                    .WithAction(DeviceCommandActionNumber.Hold)
                    .BuildHoldCommand();

                Assert.AreEqual("#DEVICE,2,301,5<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => DeviceCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithComponent(301)
                            .WithAction(DeviceCommandActionNumber.Hold)
                            .BuildHoldCommand());

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
                        => DeviceCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithComponent(301)
                            .WithAction(DeviceCommandActionNumber.Hold)
                            .BuildHoldCommand());

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
                        => DeviceCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithComponent(301)
                            .WithAction(DeviceCommandActionNumber.Hold)
                            .BuildHoldCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoComponentNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ComponentNumberNotProvided>(()
                        => DeviceCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(DeviceCommandActionNumber.Hold)
                            .BuildHoldCommand());

                    Assert.AreEqual("The component number is not provided",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => DeviceCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithComponent(301)
                            .BuildHoldCommand());

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
                        => DeviceCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithComponent(301)
                            .WithAction(DeviceCommandActionNumber.HoldRelease)
                            .BuildHoldCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 5 and not 32",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildHoldReleaseCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = DeviceCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithComponent(301)
                    .WithAction(DeviceCommandActionNumber.HoldRelease)
                    .BuildHoldReleaseCommand();

                Assert.AreEqual("#DEVICE,2,301,32<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => DeviceCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithComponent(301)
                            .WithAction(DeviceCommandActionNumber.HoldRelease)
                            .BuildHoldReleaseCommand());

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
                        => DeviceCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithComponent(301)
                            .WithAction(DeviceCommandActionNumber.HoldRelease)
                            .BuildHoldReleaseCommand());

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
                        => DeviceCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithComponent(301)
                            .WithAction(DeviceCommandActionNumber.HoldRelease)
                            .BuildHoldReleaseCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoComponentNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ComponentNumberNotProvided>(()
                        => DeviceCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(DeviceCommandActionNumber.HoldRelease)
                            .BuildHoldReleaseCommand());

                    Assert.AreEqual("The component number is not provided",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => DeviceCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithComponent(301)
                            .BuildHoldReleaseCommand());

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
                        => DeviceCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithComponent(301)
                            .WithAction(DeviceCommandActionNumber.Press)
                            .BuildHoldReleaseCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 32 and not 3",
                        exception.Message);
                }
            }
        }
    }
}