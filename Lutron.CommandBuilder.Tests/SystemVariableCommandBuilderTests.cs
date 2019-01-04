using Lutron.Common.Enums;
using Lutron.Common.Exceptions;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.CommandBuilder.Tests
{
    [TestFixture]
    public class SystemVariableCommandBuilderTests
    {        
        [TestFixture]
        public class BuildGetSystemVariableStateCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = SystemVariableCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(SystemVariableCommandActionNumber.VariableState)
                    .BuildGetSystemVariableStateCommand();

                Assert.AreEqual("?SYSVAR,2,1<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => SystemVariableCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(SystemVariableCommandActionNumber.VariableState)
                            .BuildGetSystemVariableStateCommand());

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
                        => SystemVariableCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(SystemVariableCommandActionNumber.VariableState)
                            .BuildGetSystemVariableStateCommand());

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
                        => SystemVariableCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(SystemVariableCommandActionNumber.VariableState)
                            .BuildGetSystemVariableStateCommand());

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
                        => SystemVariableCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetSystemVariableStateCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetSystemVariableStateCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = SystemVariableCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(SystemVariableCommandActionNumber.VariableState)
                    .WithVariableState(new VariableState(4))
                    .BuildSetSystemVariableStateCommand();

                Assert.AreEqual("#SYSVAR,2,1,4<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoVariableStateParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => SystemVariableCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(SystemVariableCommandActionNumber.VariableState)
                            .BuildSetSystemVariableStateCommand());

                    Assert.AreEqual("The parameter, variable state, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => SystemVariableCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(SystemVariableCommandActionNumber.VariableState)
                            .BuildSetSystemVariableStateCommand());

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
                        => SystemVariableCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(SystemVariableCommandActionNumber.VariableState)
                            .BuildSetSystemVariableStateCommand());

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
                        => SystemVariableCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(SystemVariableCommandActionNumber.VariableState)
                            .BuildSetSystemVariableStateCommand());

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
                        => SystemVariableCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetSystemVariableStateCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }
        }
    }
}