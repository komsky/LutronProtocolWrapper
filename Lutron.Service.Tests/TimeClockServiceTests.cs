using Lutron.Common.Enums;
using Lutron.Common.Models;
using Lutron.Connector;
using NSubstitute;
using NUnit.Framework;

namespace Lutron.Service.Tests
{
    [TestFixture]
    public class TimeClockServiceTests
    {
        [TestFixture]
        public class GetSunriseTime
        {
            [Test]
            public void ShouldReturnSunriseTime()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "?TIMECLOCK,2,2<CR><LF>";
                connector.Query(commandString).Returns("~TIMECLOCK,2,2,04:00<CR><LF>");
                var service = new TimeClockService(connector);

                var sunriseTime = service.GetSunriseTime(2);

                connector.Received(1).Query(commandString);
                Assert.AreEqual("04:00", sunriseTime);
            }
        }

        [TestFixture]
        public class GetSunsetTime
        {
            [Test]
            public void ShouldReturnSunsetTime()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "?TIMECLOCK,2,3<CR><LF>";
                connector.Query(commandString).Returns("~TIMECLOCK,2,3,22:00<CR><LF>");
                var service = new TimeClockService(connector);

                var sunsetTime = service.GetSunsetTime(2);

                connector.Received(1).Query(commandString);
                Assert.AreEqual("22:00", sunsetTime);
            }
        }

        [TestFixture]
        public class GetDaysSchedule
        {
            [Test]
            public void ShouldReturnDaysSchedule()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "?TIMECLOCK,2,4<CR><LF>";
                connector.Query(commandString).Returns("~TIMECLOCK,2,4,SCHEDULE<CR><LF>");
                var service = new TimeClockService(connector);

                var daysSchedule = service.GetDaysSchedule(2);

                connector.Received(1).Query(commandString);
                Assert.AreEqual("SCHEDULE", daysSchedule);
            }
        }

        [TestFixture]
        public class ExecuteIndexedEvent
        {
            [Test]
            public void ShouldExecuteIndexedEvent()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#TIMECLOCK,2,5,3<CR><LF>";
                var service = new TimeClockService(connector);

                service.ExecuteIndexedEvent(2, new EventIndex(3));

                connector.Received(1).Execute(commandString);
            }
        }

        [TestFixture]
        public class SetIndexedEventEnableState
        {
            [Test]
            public void ShouldSetIndexedEventEnableState()
            {
                var connector = Substitute.For<IMyRoomPlusConnector>();
                var commandString = "#TIMECLOCK,2,6,3,1<CR><LF>";
                var service = new TimeClockService(connector);

                service.SetIndexedEventEnableState(2, new EventIndex(3), TimeClockEnableState.Enable);

                connector.Received(1).Execute(commandString);
            }
        }
    }
}