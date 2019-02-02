using Lutron.Common.Enums;
using Lutron.Common.Exceptions;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.CommandBuilder.Tests
{
    [TestFixture]
    public class MonitoringCommandBuilderTests
    {
        [TestFixture]
        public class BuildGetDiagnosticMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.DiagnosticMonitoring)
                    .BuildGetDiagnosticMonitoringCommand();

                Assert.AreEqual("?MONITORING,2,1<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.DiagnosticMonitoring)
                            .BuildGetDiagnosticMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.DiagnosticMonitoring)
                            .BuildGetDiagnosticMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithMonitoringType(MonitoringType.DiagnosticMonitoring)
                            .BuildGetDiagnosticMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetDiagnosticMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.EventMonitoring)
                            .BuildGetDiagnosticMonitoringCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 1 and not 2",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetDiagnosticMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.DiagnosticMonitoring)
                    .WithAction(MonitoringCommandActionNumber.Enable)
                    .BuildSetDiagnosticMonitoringCommand();

                Assert.AreEqual("#MONITORING,2,1,2<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.DiagnosticMonitoring)
                            .BuildSetDiagnosticMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.DiagnosticMonitoring)
                            .BuildSetDiagnosticMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithMonitoringType(MonitoringType.DiagnosticMonitoring)
                            .BuildSetDiagnosticMonitoringCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(MonitoringCommandActionNumber.Enable)
                            .BuildSetDiagnosticMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.DiagnosticMonitoring)
                            .BuildSetDiagnosticMonitoringCommand());

                    Assert.AreEqual("The action number is not provided", exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetEventMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.EventMonitoring)
                    .BuildGetEventMonitoringCommand();

                Assert.AreEqual("?MONITORING,2,2<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.EventMonitoring)
                            .BuildGetEventMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.EventMonitoring)
                            .BuildGetEventMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithMonitoringType(MonitoringType.EventMonitoring)
                            .BuildGetEventMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetEventMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ButtonMonitoring)
                            .BuildGetEventMonitoringCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 2 and not 3",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetEventMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.EventMonitoring)
                    .WithAction(MonitoringCommandActionNumber.Enable)
                    .BuildSetEventMonitoringCommand();

                Assert.AreEqual("#MONITORING,2,2,2<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.EventMonitoring)
                            .BuildSetEventMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.EventMonitoring)
                            .BuildSetEventMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithMonitoringType(MonitoringType.EventMonitoring)
                            .BuildSetEventMonitoringCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<MonitoringTypeNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(MonitoringCommandActionNumber.Enable)
                            .BuildSetEventMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }
            
            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetEventMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ButtonMonitoring)
                            .BuildSetEventMonitoringCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 2 and not 3",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetButtonMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.ButtonMonitoring)
                    .WithAction(MonitoringCommandActionNumber.Enable)
                    .BuildGetButtonMonitoringCommand();

                Assert.AreEqual("?MONITORING,2,3<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ButtonMonitoring)
                            .BuildGetButtonMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ButtonMonitoring)
                            .BuildGetButtonMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithMonitoringType(MonitoringType.ButtonMonitoring)
                            .BuildGetButtonMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetButtonMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.LedMonitoring)
                            .BuildGetButtonMonitoringCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 3 and not 4",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetButtonMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.ButtonMonitoring)
                    .WithAction(MonitoringCommandActionNumber.Enable)
                    .BuildSetButtonMonitoringCommand();

                Assert.AreEqual("#MONITORING,2,3,2<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperatingModeParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ButtonMonitoring)
                            .BuildSetButtonMonitoringCommand());

                    Assert.AreEqual("The parameter, operating mode, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ButtonMonitoring)
                            .BuildSetButtonMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ButtonMonitoring)
                            .BuildSetButtonMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithMonitoringType(MonitoringType.ButtonMonitoring)
                            .BuildSetButtonMonitoringCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<MonitoringTypeNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(MonitoringCommandActionNumber.Enable)
                            .BuildSetButtonMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetButtonMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.LedMonitoring)
                            .BuildSetButtonMonitoringCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 3 and not 4",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetLedMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.LedMonitoring)
                    .WithAction(MonitoringCommandActionNumber.Enable)
                    .BuildGetLedMonitoringCommand();

                Assert.AreEqual("?MONITORING,2,4<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.LedMonitoring)
                            .BuildGetLedMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.LedMonitoring)
                            .BuildGetLedMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithMonitoringType(MonitoringType.LedMonitoring)
                            .BuildGetLedMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetLedMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ZoneMonitoring)
                            .BuildGetLedMonitoringCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 4 and not 5",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetLedMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.LedMonitoring)
                    .WithAction(MonitoringCommandActionNumber.Enable)
                    .BuildSetLedMonitoringCommand();

                Assert.AreEqual("#MONITORING,2,4,2<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoFanModeParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.LedMonitoring)
                            .BuildSetLedMonitoringCommand());

                    Assert.AreEqual("The parameter, fan mode, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.LedMonitoring)
                            .BuildSetLedMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.LedMonitoring)
                            .BuildSetLedMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithMonitoringType(MonitoringType.LedMonitoring)
                            .BuildSetLedMonitoringCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<MonitoringTypeNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(MonitoringCommandActionNumber.Enable)
                            .BuildSetLedMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetLedMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ZoneMonitoring)
                            .BuildSetLedMonitoringCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 4 and not 5",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetZoneMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.ZoneMonitoring)
                    .BuildGetZoneMonitoringCommand();

                Assert.AreEqual("?MONITORING,2,5<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ZoneMonitoring)
                            .BuildGetZoneMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ZoneMonitoring)
                            .BuildGetZoneMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithMonitoringType(MonitoringType.ZoneMonitoring)
                            .BuildGetZoneMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetZoneMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.Occupancy)
                            .BuildGetZoneMonitoringCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 5 and not 6",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetZoneMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.ZoneMonitoring)
                    .WithAction(MonitoringCommandActionNumber.Enable)
                    .BuildSetZoneMonitoringCommand();

                Assert.AreEqual("#MONITORING,2,5,2<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoEcoModeParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ZoneMonitoring)
                            .BuildSetZoneMonitoringCommand());

                    Assert.AreEqual("The parameter, eco mode, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ZoneMonitoring)
                            .BuildSetZoneMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ZoneMonitoring)
                            .BuildSetZoneMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithMonitoringType(MonitoringType.ZoneMonitoring)
                            .BuildSetZoneMonitoringCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<MonitoringTypeNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(MonitoringCommandActionNumber.Enable)
                            .BuildSetZoneMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetZoneMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.Occupancy)
                            .BuildSetZoneMonitoringCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 5 and not 6",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetOccupancyCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.Occupancy)
                    .BuildGetOccupancyCommand();

                Assert.AreEqual("?MONITORING,2,6<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.Occupancy)
                            .BuildGetOccupancyCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.Occupancy)
                            .BuildGetOccupancyCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithMonitoringType(MonitoringType.Occupancy)
                            .BuildGetOccupancyCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetOccupancyCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.PhotoSensorMonitoring)
                            .BuildGetOccupancyCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 6 and not 7",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetOccupancyCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.Occupancy)
                    .WithAction(MonitoringCommandActionNumber.Enable)
                    .BuildGetOccupancyCommand();

                Assert.AreEqual("?MONITORING,2,6,2<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.Occupancy)
                            .BuildGetOccupancyCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.Occupancy)
                            .BuildGetOccupancyCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithMonitoringType(MonitoringType.Occupancy)
                            .BuildSetOccupancyCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<MonitoringTypeNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(MonitoringCommandActionNumber.Enable)
                            .BuildSetOccupancyCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildGetOccupancyCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.PhotoSensorMonitoring)
                            .BuildSetOccupancyCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 6 and not 7",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetPhotoSensorMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.PhotoSensorMonitoring)
                    .BuildGetPhotoSensorMonitoringCommand();

                Assert.AreEqual("?MONITORING,2,7,0<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.PhotoSensorMonitoring)
                            .BuildGetPhotoSensorMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.PhotoSensorMonitoring)
                            .BuildGetPhotoSensorMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithMonitoringType(MonitoringType.PhotoSensorMonitoring)
                            .BuildGetPhotoSensorMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetPhotoSensorMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.Scene)
                            .BuildGetPhotoSensorMonitoringCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 7 and not 8",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetPhotoSensorMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.PhotoSensorMonitoring)
                    .WithAction(MonitoringCommandActionNumber.Enable)
                    .BuildSetPhotoSensorMonitoringCommand();

                Assert.AreEqual("#MONITORING,2,7,1<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.PhotoSensorMonitoring)
                            .BuildSetPhotoSensorMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.PhotoSensorMonitoring)
                            .BuildSetPhotoSensorMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithMonitoringType(MonitoringType.PhotoSensorMonitoring)
                            .BuildSetPhotoSensorMonitoringCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<MonitoringTypeNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(MonitoringCommandActionNumber.Enable)
                            .BuildSetPhotoSensorMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetPhotoSensorMonitoringCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.Scene)
                            .BuildSetPhotoSensorMonitoringCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 7 and not 8",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetSceneCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.Scene)
                    .BuildGetSceneCommand();

                Assert.AreEqual("?MONITORING,2,8<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.Scene)
                            .BuildGetSceneCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.Scene)
                            .BuildGetSceneCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithMonitoringType(MonitoringType.Scene)
                            .BuildGetSceneCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetSceneCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.SystemVariable)
                            .BuildGetSceneCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 8 and not 9",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetSceneCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.Scene)
                    .WithAction(MonitoringCommandActionNumber.Enable)
                    .BuildSetSceneCommand();

                Assert.AreEqual("?MONITORING,2,8,2<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.Scene)
                            .BuildGetSceneCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.Scene)
                            .BuildGetSceneCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithMonitoringType(MonitoringType.Scene)
                            .BuildGetSceneCommand());

                    Assert.AreEqual("The integration id is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<MonitoringTypeNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(MonitoringCommandActionNumber.Enable)
                            .BuildSetSceneCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoActionNumber
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ActionNumberNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetSceneCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.SystemVariable)
                            .BuildGetSceneCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 8 and not 9",
                        exception.Message);
                }
            }
        }
 
        [TestFixture]
        public class BuildGetSystemVariableCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.SystemVariable)
                    .BuildGetSystemVariableCommand();

                Assert.AreEqual("?MONITORING,2,9<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.SystemVariable)
                            .BuildGetSystemVariableCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.SystemVariable)
                            .BuildGetSystemVariableCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithMonitoringType(MonitoringType.SystemVariable)
                            .BuildGetSystemVariableCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetSystemVariableCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.SystemVariable)
                            .WithAction(default(MonitoringCommandActionNumber))
                            .BuildGetSystemVariableCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 9 and not 10",
                        exception.Message);
                }
            }
        } 
        
        [TestFixture]
        public class BuildGetScheduleDayAssignmentCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.ReplyState)
                    .BuildGetScheduleDayAssignmentCommand();

                Assert.AreEqual("?MONITORING,2,10<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ReplyState)
                            .BuildGetScheduleDayAssignmentCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ReplyState)
                            .BuildGetScheduleDayAssignmentCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithMonitoringType(MonitoringType.ReplyState)
                            .BuildGetScheduleDayAssignmentCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetScheduleDayAssignmentCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.PromptState)
                            .BuildGetScheduleDayAssignmentCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 10 and not 11",
                        exception.Message);
                }
            }
        } 
        
        [TestFixture]
        
        [TestFixture]
        public class BuildGetHeatAndCoolSetPointsWithoutEcoOffsetCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.OccupancyGroupMonitoring)
                    .BuildGetHeatAndCoolSetPointsWithoutEcoOffsetCommand();

                Assert.AreEqual("?MONITORING,2,12<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.OccupancyGroupMonitoring)
                            .BuildGetHeatAndCoolSetPointsWithoutEcoOffsetCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.OccupancyGroupMonitoring)
                            .BuildGetHeatAndCoolSetPointsWithoutEcoOffsetCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithMonitoringType(MonitoringType.OccupancyGroupMonitoring)
                            .BuildGetHeatAndCoolSetPointsWithoutEcoOffsetCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetHeatAndCoolSetPointsWithoutEcoOffsetCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.DeviceLockStateMonitoring)
                            .BuildGetHeatAndCoolSetPointsWithoutEcoOffsetCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 12 and not 13",
                        exception.Message);
                }
            }
        }
        
        [TestFixture]
        public class BuildGetEmergencyHeatAvailableCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.DeviceLockStateMonitoring)
                    .BuildGetEmergencyHeatAvailableCommand();

                Assert.AreEqual("?MONITORING,2,13<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.DeviceLockStateMonitoring)
                            .BuildGetEmergencyHeatAvailableCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.DeviceLockStateMonitoring)
                            .BuildGetEmergencyHeatAvailableCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithMonitoringType(MonitoringType.DeviceLockStateMonitoring)
                            .BuildGetEmergencyHeatAvailableCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetEmergencyHeatAvailableCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.SequenceMonitoring)
                            .BuildGetEmergencyHeatAvailableCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 13 and not 14",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetCallStatusCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.SequenceMonitoring)
                    .BuildGetCallStatusCommand();

                Assert.AreEqual("?MONITORING,2,14<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.SequenceMonitoring)
                            .BuildGetCallStatusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.SequenceMonitoring)
                            .BuildGetCallStatusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithMonitoringType(MonitoringType.SequenceMonitoring)
                            .BuildGetCallStatusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetCallStatusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.HvacMonitoring)
                            .BuildGetCallStatusCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 14 and not 15",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetCallStatusCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.SequenceMonitoring)
                    .WithCallStatus(MonitoringCallStatus.NoneLastWasCool)
                    .BuildSetCallStatusCommand();

                Assert.AreEqual("#MONITORING,2,14,5<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.SequenceMonitoring)
                            .BuildSetCallStatusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.SequenceMonitoring)
                            .BuildSetCallStatusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithMonitoringType(MonitoringType.SequenceMonitoring)
                            .BuildSetCallStatusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetCallStatusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.HvacMonitoring)
                            .BuildSetCallStatusCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 14 and not 15",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetCurrentTemperatureCelsiusCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.HvacMonitoring)
                    .BuildGetCurrentTemperatureCelsiusCommand();

                Assert.AreEqual("?MONITORING,2,15<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.HvacMonitoring)
                            .BuildGetCurrentTemperatureCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.HvacMonitoring)
                            .BuildGetCurrentTemperatureCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithMonitoringType(MonitoringType.HvacMonitoring)
                            .BuildGetCurrentTemperatureCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetCurrentTemperatureCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ModeMonitoring)
                            .BuildGetCurrentTemperatureCelsiusCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 15 and not 16",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetCurrentTemperatureCelsiusCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.HvacMonitoring)
                    .WithTemperature(new TemperatureCelsius(34))
                    .BuildSetCurrentTemperatureCelsiusCommand();

                Assert.AreEqual("#MONITORING,2,15,34<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoTemperatureParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.HvacMonitoring)
                            .BuildSetCurrentTemperatureCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.HvacMonitoring)
                            .BuildSetCurrentTemperatureCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.HvacMonitoring)
                            .BuildSetCurrentTemperatureCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithMonitoringType(MonitoringType.HvacMonitoring)
                            .BuildSetCurrentTemperatureCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetCurrentTemperatureCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ModeMonitoring)
                            .BuildSetCurrentTemperatureCelsiusCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 15 and not 16",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetHeatAndCoolSetPointsCelsiusCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.ModeMonitoring)
                    .BuildGetHeatAndCoolSetPointsCelsiusCommand();

                Assert.AreEqual("?MONITORING,2,16<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ModeMonitoring)
                            .BuildGetHeatAndCoolSetPointsCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ModeMonitoring)
                            .BuildGetHeatAndCoolSetPointsCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithMonitoringType(MonitoringType.ModeMonitoring)
                            .BuildGetHeatAndCoolSetPointsCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetHeatAndCoolSetPointsCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ShadeGroupMonitoring)
                            .BuildGetHeatAndCoolSetPointsCelsiusCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 16 and not 17",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetHeatAndCoolSetPointsCelsiusCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.ModeMonitoring)
                    .WithSetPointHeat(new HeatSetPointCelsius(34))
                    .WithSetPointCool(new CoolSetPointCelsius(34))
                    .BuildSetHeatAndCoolSetPointsCelsiusCommand();

                Assert.AreEqual("#MONITORING,2,16,34,34<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoSetPointHeatParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ModeMonitoring)
                            .WithSetPointCool(new CoolSetPointFahrenheit(55))
                            .BuildSetHeatAndCoolSetPointsCelsiusCommand());

                    Assert.AreEqual("The parameter, set point heat, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoSetPointCoolParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ModeMonitoring)
                            .WithSetPointHeat(new HeatSetPointCelsius(98))
                            .BuildSetHeatAndCoolSetPointsCelsiusCommand());

                    Assert.AreEqual("The parameter, set point cool, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ModeMonitoring)
                            .BuildSetHeatAndCoolSetPointsCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ModeMonitoring)
                            .BuildSetHeatAndCoolSetPointsCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithMonitoringType(MonitoringType.ModeMonitoring)
                            .BuildSetHeatAndCoolSetPointsCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetHeatAndCoolSetPointsCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ShadeGroupMonitoring)
                            .BuildSetHeatAndCoolSetPointsCelsiusCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 16 and not 17",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetHeatAndCoolSetPointsWithoutEcoOffsetCelsiusCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.ShadeGroupMonitoring)
                    .BuildGetHeatAndCoolSetPointsWithoutEcoOffsetCelsiusCommand();

                Assert.AreEqual("?MONITORING,2,17<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ShadeGroupMonitoring)
                            .BuildGetHeatAndCoolSetPointsWithoutEcoOffsetCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ShadeGroupMonitoring)
                            .BuildGetHeatAndCoolSetPointsWithoutEcoOffsetCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithMonitoringType(MonitoringType.ShadeGroupMonitoring)
                            .BuildGetHeatAndCoolSetPointsWithoutEcoOffsetCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetHeatAndCoolSetPointsWithoutEcoOffsetCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.PartitionWall)
                            .BuildGetHeatAndCoolSetPointsWithoutEcoOffsetCelsiusCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 17 and not 18",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetHeatAndCoolSetPointsWithoutEcoOffsetCelsiusCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.ShadeGroupMonitoring)
                    .WithSetPointHeat(new HeatSetPointCelsius(34))
                    .WithSetPointCool(new CoolSetPointCelsius(34))
                    .BuildSetHeatAndCoolSetPointsWithoutEcoOffsetCelsiusCommand();

                Assert.AreEqual("#MONITORING,2,17,34,34<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoSetPointHeatParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ShadeGroupMonitoring)
                            .WithSetPointCool(new CoolSetPointFahrenheit(55))
                            .BuildSetHeatAndCoolSetPointsWithoutEcoOffsetCelsiusCommand());

                    Assert.AreEqual("The parameter, set point heat, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoSetPointCoolParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ShadeGroupMonitoring)
                            .WithSetPointHeat(new HeatSetPointCelsius(98))
                            .BuildSetHeatAndCoolSetPointsWithoutEcoOffsetCelsiusCommand());

                    Assert.AreEqual("The parameter, set point cool, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ShadeGroupMonitoring)
                            .BuildSetHeatAndCoolSetPointsWithoutEcoOffsetCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ShadeGroupMonitoring)
                            .BuildSetHeatAndCoolSetPointsWithoutEcoOffsetCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithMonitoringType(MonitoringType.ShadeGroupMonitoring)
                            .BuildSetHeatAndCoolSetPointsWithoutEcoOffsetCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetHeatAndCoolSetPointsWithoutEcoOffsetCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.PartitionWall)
                            .BuildSetHeatAndCoolSetPointsWithoutEcoOffsetCelsiusCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 17 and not 18",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetSingleSetPointAndDriftsFahrenheitCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.PartitionWall)
                    .BuildGetSingleSetPointAndDriftsFahrenheitCommand();

                Assert.AreEqual("?MONITORING,2,18<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.PartitionWall)
                            .BuildGetSingleSetPointAndDriftsFahrenheitCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.PartitionWall)
                            .BuildGetSingleSetPointAndDriftsFahrenheitCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithMonitoringType(MonitoringType.PartitionWall)
                            .BuildGetSingleSetPointAndDriftsFahrenheitCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetSingleSetPointAndDriftsFahrenheitCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.TemperatureSensorMonitoring)
                            .BuildGetSingleSetPointAndDriftsFahrenheitCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 18 and not 19",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetSingleSetPointAndDriftsFahrenheitCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.PartitionWall)
                    .WithSingleSetPoint(new SingleSetPointFahrenheit(34))
                    .WithNegativeDrift(new NegativeDriftFahrenheit(5))
                    .WithPositiveDrift(new PositiveDriftFahrenheit(5))
                    .BuildSetSingleSetPointAndDriftsFahrenheitCommand();

                Assert.AreEqual("#MONITORING,2,18,34,5,5<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoSingleSetPointParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.PartitionWall)
                            .WithNegativeDrift(new NegativeDriftFahrenheit(5))
                            .WithPositiveDrift(new PositiveDriftFahrenheit(5))
                            .BuildSetSingleSetPointAndDriftsFahrenheitCommand());

                    Assert.AreEqual("The parameter, single set point, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoNegativeDriftParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.PartitionWall)
                            .WithSingleSetPoint(new SingleSetPointFahrenheit(34))
                            .WithPositiveDrift(new PositiveDriftFahrenheit(5))
                            .BuildSetSingleSetPointAndDriftsFahrenheitCommand());

                    Assert.AreEqual("The parameter, negative drift, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoPositiveDriftParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.PartitionWall)
                            .WithSingleSetPoint(new SingleSetPointFahrenheit(34))
                            .WithNegativeDrift(new NegativeDriftFahrenheit(5))
                            .BuildSetSingleSetPointAndDriftsFahrenheitCommand());

                    Assert.AreEqual("The parameter, positive drift, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.PartitionWall)
                            .BuildSetSingleSetPointAndDriftsFahrenheitCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.PartitionWall)
                            .BuildSetSingleSetPointAndDriftsFahrenheitCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithMonitoringType(MonitoringType.PartitionWall)
                            .BuildSetSingleSetPointAndDriftsFahrenheitCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetSingleSetPointAndDriftsFahrenheitCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.TemperatureSensorMonitoring)
                            .BuildSetSingleSetPointAndDriftsFahrenheitCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 18 and not 19",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetSingleSetPointAndDriftsCelsiusCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.TemperatureSensorMonitoring)
                    .BuildGetSingleSetPointAndDriftsCelsiusCommand();

                Assert.AreEqual("?MONITORING,2,19<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.TemperatureSensorMonitoring)
                            .BuildGetSingleSetPointAndDriftsCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.TemperatureSensorMonitoring)
                            .BuildGetSingleSetPointAndDriftsCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithMonitoringType(MonitoringType.TemperatureSensorMonitoring)
                            .BuildGetSingleSetPointAndDriftsCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetSingleSetPointAndDriftsCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.DiagnosticMonitoring)
                            .BuildGetSingleSetPointAndDriftsCelsiusCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 19 and not 1",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetSingleSetPointAndDriftsCelsiusCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.TemperatureSensorMonitoring)
                    .WithSingleSetPoint(new SingleSetPointCelsius(34))
                    .WithNegativeDrift(new NegativeDriftCelsius(5))
                    .WithPositiveDrift(new PositiveDriftCelsius(5))
                    .BuildSetSingleSetPointAndDriftsCelsiusCommand();

                Assert.AreEqual("#MONITORING,2,19,34,5,5<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoSingleSetPointParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.TemperatureSensorMonitoring)
                            .WithNegativeDrift(new NegativeDriftCelsius(5))
                            .WithPositiveDrift(new PositiveDriftCelsius(5))
                            .BuildSetSingleSetPointAndDriftsCelsiusCommand());

                    Assert.AreEqual("The parameter, single set point, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoNegativeDriftParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.TemperatureSensorMonitoring)
                            .WithSingleSetPoint(new SingleSetPointCelsius(34))
                            .WithPositiveDrift(new PositiveDriftCelsius(5))
                            .BuildSetSingleSetPointAndDriftsCelsiusCommand());

                    Assert.AreEqual("The parameter, negative drift, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoPositiveDriftParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.TemperatureSensorMonitoring)
                            .WithSingleSetPoint(new SingleSetPointCelsius(34))
                            .WithNegativeDrift(new NegativeDriftCelsius(5))
                            .BuildSetSingleSetPointAndDriftsCelsiusCommand());

                    Assert.AreEqual("The parameter, positive drift, is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.TemperatureSensorMonitoring)
                            .BuildSetSingleSetPointAndDriftsCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.TemperatureSensorMonitoring)
                            .BuildSetSingleSetPointAndDriftsCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithMonitoringType(MonitoringType.TemperatureSensorMonitoring)
                            .BuildSetSingleSetPointAndDriftsCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetSingleSetPointAndDriftsCelsiusCommand());

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
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.DiagnosticMonitoring)
                            .BuildSetSingleSetPointAndDriftsCelsiusCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 19 and not 1",
                        exception.Message);
                }
            }
        }

    }
}