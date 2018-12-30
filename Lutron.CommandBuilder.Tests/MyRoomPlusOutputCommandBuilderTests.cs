using NUnit.Framework;

namespace Lutron.CommandBuilder.Tests
{
    [TestFixture]
    public class MyRoomPlusOutputCommandBuilderTests
    {
        [TestFixture]
        public class BuildGetOutputLevelCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                const int integrationId = 2;
                const int level = 70;
                const string fade = "4";
                const string delay = "2";
                
                var command  =  MyRoomPlusOutputCommandBuilder.Create()
                    .WithOperation(MyRoomPlusCommandOperation.Set)
                    .WithIntegrationId(integrationId)
                    .WithAction(MyRoomPlusOutputCommandAction.Level)
                    .WithLevel(level)
                    .WithFade(fade)
                    .WithDelay(delay)
                    .BuildGetOutputLevelCommand();
                
                Assert.AreEqual("#OUTPUT,2,1,70,4,2<CR><LF>", command);
            }
        }
    }
}