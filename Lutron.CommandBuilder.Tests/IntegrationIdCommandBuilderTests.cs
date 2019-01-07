using Lutron.Common.Enums;
using Lutron.Common.Exceptions;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.CommandBuilder.Tests
{
    [TestFixture]
    public class IntegrationIdCommandBuilderTests
    {
        [TestFixture]
        public class BuildGetIntegrationIdForSerialNumberCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = IntegrationIdCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithAction(IntegrationIdCommandActionNumber.IntegrationIdForSerialNumber)
                    .WithSerialNumber(new SerialNumber("5678EFEF"))
                    .BuildGetIntegrationIdForSerialNumberCommand();

                Assert.AreEqual("?INTEGRATIONID,1,5678EFEF<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => IntegrationIdCommandBuilder.Create()
                            .WithAction(IntegrationIdCommandActionNumber.IntegrationIdForSerialNumber)
                            .BuildGetIntegrationIdForSerialNumberCommand());

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
                        => IntegrationIdCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(IntegrationIdCommandActionNumber.IntegrationIdForSerialNumber)
                            .BuildGetIntegrationIdForSerialNumberCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected ? and not #",
                        exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoSerialNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => IntegrationIdCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(IntegrationIdCommandActionNumber.IntegrationIdForSerialNumber)
                            .BuildGetIntegrationIdForSerialNumberCommand());

                    Assert.AreEqual("The parameter, serial number, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => IntegrationIdCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .BuildGetIntegrationIdForSerialNumberCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetInfoFromIdCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = IntegrationIdCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(IntegrationIdCommandActionNumber.InfoFromIntegrationId)
                    .BuildGetInfoFromIdCommand();

                Assert.AreEqual("?INTEGRATIONID,3,2<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => IntegrationIdCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(IntegrationIdCommandActionNumber.InfoFromIntegrationId)
                            .BuildGetInfoFromIdCommand());

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
                        => IntegrationIdCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(IntegrationIdCommandActionNumber.InfoFromIntegrationId)
                            .BuildGetInfoFromIdCommand());

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
                        => IntegrationIdCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(IntegrationIdCommandActionNumber.InfoFromIntegrationId)
                            .BuildGetInfoFromIdCommand());

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
                        => IntegrationIdCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetInfoFromIdCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }
        }
    }
}