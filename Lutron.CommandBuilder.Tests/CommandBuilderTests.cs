using System;
using NUnit.Framework;

namespace Lutron.CommandBuilder.Tests
{
    [TestFixture]
    public class CommandBuilderTests
    {
        [TestFixture]
        public class CreateGetOutputLevelCommandString
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                const int integrationId = 2;
                var command  =  MyRoomPlusOutputCommandBuilder.Create()
                    .WithOperation(MyRoomPlusCommandOperation.Set)
                    .WithIntegrationId(integrationId)
                    .WithAction(MyRoomPlusOutputCommandAction.Level)
                    .WithLevel(new OutputCommandLevelParameter(70))
                    .WithFade(new OutputCommandFadeParameter(TimeSpan.FromSeconds(4.25)))
                    .WithDelay(new OutputCommandDelayParameter(TimeSpan.FromSeconds(2)))
                    .BuildCommand();

                var commandString = command.CreateGetOutputLevelCommandString();
                
                Assert.AreEqual("#OUTPUT,2,1,70,00:00:04.2500000,00:00:02<CR><LF>", commandString);
            }
        }
    }
}