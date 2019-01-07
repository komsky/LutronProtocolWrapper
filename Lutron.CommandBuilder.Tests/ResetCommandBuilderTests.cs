using Lutron.Common.Enums;
using Lutron.Common.Exceptions;
using NUnit.Framework;

namespace Lutron.CommandBuilder.Tests
{
    [TestFixture]
    public class ResetCommandBuilderTests
    {
        [TestFixture]
        public class BuildSetResetCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = ResetCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithAction(ResetCommandActionNumber.Reset)
                    .BuildSetResetCommand();

                Assert.AreEqual("#RESET,0<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => ResetCommandBuilder.Create()
                            .WithAction(ResetCommandActionNumber.Reset)
                            .BuildSetResetCommand());

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
                        => ResetCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(ResetCommandActionNumber.Reset)
                            .BuildSetResetCommand());

                    Assert.AreEqual("The operation provided is incorrect. Expected # and not ?",
                        exception.Message);
                }
            }
        }
    }
}