using Lutron.Common.Enums;
using Lutron.Common.Interfaces;
using Lutron.Common.Models;
using NSubstitute;
using NUnit.Framework;

namespace Lutron.Service.Tests
{
    [TestFixture]
    public class SystemVariableServiceTests
    {
        [TestFixture]
        public class GetSystemVariable
        {
            [Test]
            public void ShouldReturnSunriseTime()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "?SYSVAR,2,1<CR><LF>";
                connector.Query(commandString).Returns("~SYSVAR,2,1,3<CR><LF>");
                var service = new SystemVariableService(connector);

                var sunriseTime = service.GetSystemVariable(2);

                connector.Received(1).Query(commandString);
                Assert.AreEqual("3", sunriseTime);
            }
        }

        [TestFixture]
        public class SetSystemVariable
        {
            [Test]
            public void ShouldSetIndexedEventEnableState()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#SYSVAR,2,1,3<CR><LF>";
                var service = new SystemVariableService(connector);

                service.SetSystemVariable(2, new VariableState(3));

                connector.Received(1).Execute(commandString);
            }
        }
    }
}