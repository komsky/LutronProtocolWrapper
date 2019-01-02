using Lutron.Common.Models;
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
                var command = MyRoomPlusOutputCommandBuilder.Create()
                    .WithOperation(MyRoomPlusCommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(MyRoomPlusOutputCommandAction.OutputLevel)
                    .WithLevel(new Level(70))
                    .WithFade(new Fade(seconds: 4))
                    .WithDelay(new Delay(seconds: 2))
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
                var command = MyRoomPlusOutputCommandBuilder.Create()
                    .WithOperation(MyRoomPlusCommandOperation.Get)
                    .WithIntegrationId(2)
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
                var command = MyRoomPlusOutputCommandBuilder.Create()
                    .WithOperation(MyRoomPlusCommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(MyRoomPlusOutputCommandAction.StartRaisingOutputLevel)
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
                var command = MyRoomPlusOutputCommandBuilder.Create()
                    .WithOperation(MyRoomPlusCommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(MyRoomPlusOutputCommandAction.StartLoweringOutputLevel)
                    .BuildStartLoweringOutputLevelCommand();

                Assert.AreEqual("#OUTPUT,2,3<CR><LF>", command);
            }
        }

        [TestFixture]
        public class BuildStopRaisingOrLoweringOutputLevelCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MyRoomPlusOutputCommandBuilder.Create()
                    .WithOperation(MyRoomPlusCommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(MyRoomPlusOutputCommandAction.StopRaisingOrLoweringOutputLevel)
                    .BuildStopRaisingOrLoweringOutputLevelCommand();

                Assert.AreEqual("#OUTPUT,2,4<CR><LF>", command);
            }
        }

        [TestFixture]
        public class BuildGetFlashFrequencyCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MyRoomPlusOutputCommandBuilder.Create()
                    .WithOperation(MyRoomPlusCommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(MyRoomPlusOutputCommandAction.FlashFrequency)
                    .WithFade(new Fade(seconds: 2))
                    .WithDelay(new Delay(seconds: 45))
                    .BuildGetFlashFrequencyCommand();

                Assert.AreEqual("?OUTPUT,2,5,2,45<CR><LF>", command);
            }
        }
    }
}