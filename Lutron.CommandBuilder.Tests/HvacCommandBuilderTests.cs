using Lutron.Common.Enums;
using Lutron.Common.Exceptions;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.CommandBuilder.Tests
{
    [TestFixture]
    public class HvacCommandBuilderTests
    {
        [TestFixture]
        public class BuildGetCurrentTemperatureCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.CurrentTemparature)
                    .BuildGetCurrentTemperatureCommand();

                Assert.AreEqual("?HVAC,2,1<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.CurrentTemparature)
                            .BuildGetCurrentTemperatureCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.CurrentTemparature)
                            .BuildGetCurrentTemperatureCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(HvacCommandActionNumber.CurrentTemparature)
                            .BuildGetCurrentTemperatureCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetCurrentTemperatureCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.SetPoint)
                            .BuildGetCurrentTemperatureCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 1 and not 2",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetCurrentTemperatureCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.CurrentTemparature)
                    .WithTemperature(new Temperature(34))
                    .BuildSetCurrentTemperatureCommand();

                Assert.AreEqual("#HVAC,2,1,34<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoTemperatureParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.CurrentTemparature)
                            .BuildSetCurrentTemperatureCommand());

                    Assert.AreEqual("The parameter, temperature, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.CurrentTemparature)
                            .BuildSetCurrentTemperatureCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.CurrentTemparature)
                            .BuildSetCurrentTemperatureCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(HvacCommandActionNumber.CurrentTemparature)
                            .BuildSetCurrentTemperatureCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetCurrentTemperatureCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.SetPoint)
                            .BuildSetCurrentTemperatureCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 1 and not 2",
                        exception.Message);
                }
            }
        }
    }
}