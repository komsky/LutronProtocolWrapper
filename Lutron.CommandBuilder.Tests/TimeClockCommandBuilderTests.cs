using Lutron.Common.Enums;
using Lutron.Common.Exceptions;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.CommandBuilder.Tests
{
    [TestFixture]
    public class TimeClockCommandBuilderTests
    {
        [TestFixture]
        public class BuildGetSunriseTimeCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = TimeClockCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(TimeClockCommandActionNumber.SunriseTime)
                    .BuildGetSunriseTimeCommand();

                Assert.AreEqual("?TIMECLOCK,2,2<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => TimeClockCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(TimeClockCommandActionNumber.SunriseTime)
                            .BuildGetSunriseTimeCommand());

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
                        => TimeClockCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(TimeClockCommandActionNumber.SunriseTime)
                            .BuildGetSunriseTimeCommand());

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
                        => TimeClockCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(TimeClockCommandActionNumber.SunriseTime)
                            .BuildGetSunriseTimeCommand());

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
                        => TimeClockCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetSunriseTimeCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectTimeClockCommandActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => TimeClockCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(TimeClockCommandActionNumber.IndexedEventEnableState)
                            .BuildGetSunriseTimeCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 2 and not 6",
                        exception.Message);
                }
            }
        }
        
        [TestFixture]
        public class BuildGetSunsetTimeCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = TimeClockCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(TimeClockCommandActionNumber.SunsetTime)
                    .BuildGetSunsetTimeCommand();

                Assert.AreEqual("?TIMECLOCK,2,3<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => TimeClockCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(TimeClockCommandActionNumber.SunsetTime)
                            .BuildGetSunsetTimeCommand());

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
                        => TimeClockCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(TimeClockCommandActionNumber.SunsetTime)
                            .BuildGetSunsetTimeCommand());

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
                        => TimeClockCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(TimeClockCommandActionNumber.SunsetTime)
                            .BuildGetSunsetTimeCommand());

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
                        => TimeClockCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetSunsetTimeCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectTimeClockCommandActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => TimeClockCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(TimeClockCommandActionNumber.IndexedEventEnableState)
                            .BuildGetSunsetTimeCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 3 and not 6",
                        exception.Message);
                }
            }
        }
        
        [TestFixture]
        public class BuildGetDaysScheduleCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = TimeClockCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(TimeClockCommandActionNumber.DaysSchedule)
                    .BuildGetDaysScheduleCommand();

                Assert.AreEqual("?TIMECLOCK,2,4<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => TimeClockCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(TimeClockCommandActionNumber.DaysSchedule)
                            .BuildGetDaysScheduleCommand());

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
                        => TimeClockCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(TimeClockCommandActionNumber.DaysSchedule)
                            .BuildGetDaysScheduleCommand());

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
                        => TimeClockCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(TimeClockCommandActionNumber.DaysSchedule)
                            .BuildGetDaysScheduleCommand());

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
                        => TimeClockCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetDaysScheduleCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectTimeClockCommandActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => TimeClockCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(TimeClockCommandActionNumber.IndexedEventEnableState)
                            .BuildGetDaysScheduleCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 4 and not 6",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetExecuteIndexedEventCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = TimeClockCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(TimeClockCommandActionNumber.ExecuteIndexedEvent)
                    .WithEventIndex(new EventIndex(3))
                    .BuildSetExecuteIndexedEventCommand();

                Assert.AreEqual("#TIMECLOCK,2,5,3<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoEventIndex
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => TimeClockCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(TimeClockCommandActionNumber.ExecuteIndexedEvent)
                            .BuildSetExecuteIndexedEventCommand());

                    Assert.AreEqual("The parameter, event index, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => TimeClockCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(TimeClockCommandActionNumber.ExecuteIndexedEvent)
                            .BuildSetExecuteIndexedEventCommand());

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
                        => TimeClockCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(TimeClockCommandActionNumber.ExecuteIndexedEvent)
                            .BuildSetExecuteIndexedEventCommand());

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
                        => TimeClockCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(TimeClockCommandActionNumber.ExecuteIndexedEvent)
                            .BuildSetExecuteIndexedEventCommand());

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
                        => TimeClockCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetExecuteIndexedEventCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectTimeClockCommandActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => TimeClockCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(TimeClockCommandActionNumber.IndexedEventEnableState)
                            .BuildSetExecuteIndexedEventCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 5 and not 6",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetIndexedEventEnableStateCommand
        {
            [TestFixture]
            public class GivenEnableStateIsEnable
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = TimeClockCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(TimeClockCommandActionNumber.IndexedEventEnableState)
                        .WithEventIndex(new EventIndex(3))
                        .WithEnableState(TimeClockEnableState.Enable)
                        .BuildSetIndexedEventEnableStateCommand();

                    Assert.AreEqual("#TIMECLOCK,2,6,3,1<CR><LF>", command);
                }                
            }

            [TestFixture]
            public class GivenEnableStateIsDisable
            {
                [Test]
                public void ShouldReturnCommandString()
                {
                    var command = TimeClockCommandBuilder.Create()
                        .WithOperation(CommandOperation.Set)
                        .WithIntegrationId(2)
                        .WithAction(TimeClockCommandActionNumber.IndexedEventEnableState)
                        .WithEventIndex(new EventIndex(3))
                        .WithEnableState(TimeClockEnableState.Disable)
                        .BuildSetIndexedEventEnableStateCommand();

                    Assert.AreEqual("#TIMECLOCK,2,6,3,2<CR><LF>", command);
                }                
            }

            [TestFixture]
            public class GivenNoEventIndex
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => TimeClockCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(TimeClockCommandActionNumber.IndexedEventEnableState)
                            .BuildSetIndexedEventEnableStateCommand());

                    Assert.AreEqual("The parameter, event index, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoEnableStateParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => TimeClockCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(TimeClockCommandActionNumber.IndexedEventEnableState)
                            .WithEventIndex(new EventIndex(3))
                            .BuildSetIndexedEventEnableStateCommand());

                    Assert.AreEqual("The parameter, enable state, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => TimeClockCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(TimeClockCommandActionNumber.IndexedEventEnableState)
                            .BuildSetIndexedEventEnableStateCommand());

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
                        => TimeClockCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(TimeClockCommandActionNumber.IndexedEventEnableState)
                            .BuildSetIndexedEventEnableStateCommand());

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
                        => TimeClockCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(TimeClockCommandActionNumber.IndexedEventEnableState)
                            .BuildSetIndexedEventEnableStateCommand());

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
                        => TimeClockCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetIndexedEventEnableStateCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectTimeClockCommandActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectActionNumberProvided>(()
                        => TimeClockCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(TimeClockCommandActionNumber.ExecuteIndexedEvent)
                            .BuildSetIndexedEventEnableStateCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 6 and not 5",
                        exception.Message);
                }
            }
        }

    }
}