using NUnit.Framework;

namespace Lutron.CommandBuilder.Tests
{
    [TestFixture]
    public class MyRoomPlusOutputCommandBuilderTests
    {
        [TestFixture]
        public class BuildSetOutputLevelCommand
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
                    .WithAction(MyRoomPlusOutputCommandAction.OutputLevel)
                    .WithLevel(level)
                    .WithFade(fade)
                    .WithDelay(delay)
                    .BuildSetOutputLevelCommand();
                
                Assert.AreEqual("#OUTPUT,2,1,70,4,2<CR><LF>", command);
            }
        }  
        
        [TestFixture]
        public class BuildGetOutputLevelCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                const int integrationId = 2;
                
                var command  =  MyRoomPlusOutputCommandBuilder.Create()
                    .WithOperation(MyRoomPlusCommandOperation.Get)
                    .WithIntegrationId(integrationId)
                    .BuildGetOutputLevelCommand();
                
                Assert.AreEqual("?OUTPUT,2<CR><LF>", command);
            }
        }  
        
        [TestFixture]
        public class BuildStartRaisingOutputLevelCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                const int integrationId = 2;
                
                var command  =  MyRoomPlusOutputCommandBuilder.Create()
                    .WithOperation(MyRoomPlusCommandOperation.Set)
                    .WithIntegrationId(integrationId)
                    .WithAction(MyRoomPlusOutputCommandAction.StartRaisingLevel)
                    .BuildStartRaisingOutputLevelCommand();
                
                Assert.AreEqual("#OUTPUT,2,2<CR><LF>", command);
            }
        }     
        
        [TestFixture]
        public class BuildStartLoweringOutputLevelCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                const int integrationId = 2;
                
                var command  =  MyRoomPlusOutputCommandBuilder.Create()
                    .WithOperation(MyRoomPlusCommandOperation.Set)
                    .WithIntegrationId(integrationId)
                    .WithAction(MyRoomPlusOutputCommandAction.StartLoweringLevel)
                    .BuildStartLoweringOutputLevelCommand();
                
                Assert.AreEqual("#OUTPUT,2,3<CR><LF>", command);
            }
        }
    }
}