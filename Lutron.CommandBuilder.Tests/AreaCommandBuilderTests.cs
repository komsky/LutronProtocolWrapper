using Lutron.Common.Enums;
using Lutron.Common.Exceptions;
using NUnit.Framework;

namespace Lutron.CommandBuilder.Tests
{
    [TestFixture]
    public class AreaCommandBuilderTests
    {
        [TestFixture]
        public class BuildGetOccupancyStateCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = AreaCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(AreaCommandActionNumber.OccupancyState)
                    .BuildGetOccupancyStateCommand();

                Assert.AreEqual("?AREA,2,8<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => AreaCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(AreaCommandActionNumber.OccupancyState)
                            .BuildGetOccupancyStateCommand());

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
                        => AreaCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(AreaCommandActionNumber.OccupancyState)
                            .BuildGetOccupancyStateCommand());

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
                        => AreaCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(AreaCommandActionNumber.OccupancyState)
                            .BuildGetOccupancyStateCommand());

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
                        => AreaCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetOccupancyStateCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }
        }
    }
}