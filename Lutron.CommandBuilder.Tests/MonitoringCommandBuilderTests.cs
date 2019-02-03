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
                            .WithMonitoringType(MonitoringType.DiagnosticMonitoring)
                            .BuildGetDiagnosticMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.EventMonitoring)
                            .BuildGetDiagnosticMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 1 and not 2",
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

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
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
                            .WithMonitoringType(MonitoringType.ButtonMonitoring)
                            .BuildGetEventMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ButtonMonitoring)
                            .BuildGetEventMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 2 and not 3",
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

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ButtonMonitoring)
                            .BuildSetEventMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 2 and not 3",
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
                            .WithMonitoringType(MonitoringType.ButtonMonitoring)
                            .BuildGetButtonMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GiveIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.LEDMonitoring)
                            .BuildGetButtonMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 3 and not 4",
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

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.LEDMonitoring)
                            .BuildSetButtonMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 3 and not 4",
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
                    .WithMonitoringType(MonitoringType.LEDMonitoring)
                    .WithAction(MonitoringCommandActionNumber.Enable)
                    .BuildGetLEDMonitoringCommand();

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
                            .WithMonitoringType(MonitoringType.LEDMonitoring)
                            .BuildGetLEDMonitoringCommand());

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
                            .WithMonitoringType(MonitoringType.LEDMonitoring)
                            .BuildGetLEDMonitoringCommand());

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
                            .WithMonitoringType(MonitoringType.LEDMonitoring)
                            .BuildGetLEDMonitoringCommand());

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
                            .WithMonitoringType(MonitoringType.LEDMonitoring)
                            .BuildGetLEDMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ZoneMonitoring)
                            .BuildGetLEDMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 4 and not 5",
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
                    .WithMonitoringType(MonitoringType.LEDMonitoring)
                    .WithAction(MonitoringCommandActionNumber.Enable)
                    .BuildSetLEDMonitoringCommand();

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
                            .WithMonitoringType(MonitoringType.LEDMonitoring)
                            .BuildSetLEDMonitoringCommand());

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
                            .WithMonitoringType(MonitoringType.LEDMonitoring)
                            .BuildSetLEDMonitoringCommand());

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
                            .WithMonitoringType(MonitoringType.LEDMonitoring)
                            .BuildSetLEDMonitoringCommand());

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
                            .WithMonitoringType(MonitoringType.LEDMonitoring)
                            .BuildSetLEDMonitoringCommand());

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
                            .BuildSetLEDMonitoringCommand());

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
                            .BuildSetLEDMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ZoneMonitoring)
                            .BuildSetLEDMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 4 and not 5",
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

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.Occupancy)
                            .BuildGetZoneMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 5 and not 6",
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

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.Occupancy)
                            .BuildSetZoneMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 5 and not 6",
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
                            .WithMonitoringType(MonitoringType.Occupancy)
                            .BuildGetOccupancyCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.PhotoSensorMonitoring)
                            .BuildGetOccupancyCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 6 and not 7",
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

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.PhotoSensorMonitoring)
                            .BuildSetOccupancyCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 6 and not 7",
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

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.Scene)
                            .BuildGetPhotoSensorMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 7 and not 8",
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

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.Scene)
                            .BuildSetPhotoSensorMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 7 and not 8",
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

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.SystemVariable)
                            .BuildGetSceneCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 8 and not 9",
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

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.SystemVariable)
                            .BuildGetSceneCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 8 and not 9",
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

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.SystemVariable)
                            .WithAction(default(MonitoringCommandActionNumber))
                            .BuildGetSystemVariableCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 9 and not 10",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetSystemVariableCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.SystemVariable)
                    .WithAction(MonitoringCommandActionNumber.Enable)
                    .BuildSetSystemVariableCommand();

                Assert.AreEqual("?MONITORING,2,10,2<CR><LF>", command);
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
                            .BuildSetSystemVariableCommand());

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
                            .WithMonitoringType(MonitoringType.SystemVariable)
                            .BuildSetSystemVariableCommand());

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
                            .WithOperation(CommandOperation.Set)
                            .WithMonitoringType(MonitoringType.SystemVariable)
                            .BuildSetSystemVariableCommand());

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
                            .BuildSetSystemVariableCommand());

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
                            .BuildSetSystemVariableCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.SystemVariable)
                            .WithAction(default(MonitoringCommandActionNumber))
                            .BuildSetSystemVariableCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 9 and not 10",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetReplyStateCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.ReplyState)
                    .BuildGetReplyStateCommand();

                Assert.AreEqual("?MONITORING,2,11<CR><LF>", command);
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
                            .BuildGetReplyStateCommand());

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
                            .BuildGetReplyStateCommand());

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
                            .BuildGetReplyStateCommand());

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
                            .BuildGetReplyStateCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.PromptState)
                            .BuildGetReplyStateCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 10 and not 11",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetReplyStateCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.ReplyState)
                    .WithAction(MonitoringCommandActionNumber.Enable)
                    .BuildSetReplyStateCommand();

                Assert.AreEqual("#MONITORING,2,11,2<CR><LF>", command);
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
                            .BuildSetReplyStateCommand());

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
                            .BuildSetReplyStateCommand());

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
                            .WithMonitoringType(MonitoringType.ReplyState)
                            .BuildSetReplyStateCommand());

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
                            .BuildSetReplyStateCommand());

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
                            .BuildSetReplyStateCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.PromptState)
                            .BuildSetReplyStateCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 10 and not 11",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetPromptStateCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.PromptState)
                    .BuildGetPromptStateCommand();

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
                            .WithMonitoringType(MonitoringType.PromptState)
                            .BuildGetPromptStateCommand());

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
                            .WithMonitoringType(MonitoringType.PromptState)
                            .BuildGetPromptStateCommand());

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
                            .WithMonitoringType(MonitoringType.PromptState)
                            .BuildGetPromptStateCommand());

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
                            .BuildGetPromptStateCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.OccupancyGroupMonitoring)
                            .BuildGetPromptStateCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 12 and not 13",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetPromptStateCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.PromptState)
                    .WithAction(MonitoringCommandActionNumber.Enable)
                    .BuildSetPromptStateCommand();

                Assert.AreEqual("#MONITORING,2,12,2<CR><LF>", command);
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
                            .WithMonitoringType(MonitoringType.PromptState)
                            .BuildSetPromptStateCommand());

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
                            .WithMonitoringType(MonitoringType.PromptState)
                            .BuildSetPromptStateCommand());

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
                            .WithMonitoringType(MonitoringType.PromptState)
                            .BuildSetPromptStateCommand());

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
                            .BuildSetPromptStateCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.OccupancyGroupMonitoring)
                            .BuildSetPromptStateCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 12 and not 13",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetOccupancyGroupMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.OccupancyGroupMonitoring)
                    .BuildGetOccupancyGroupMonitoringCommand();

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
                            .BuildGetOccupancyGroupMonitoringCommand());

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
                            .BuildGetOccupancyGroupMonitoringCommand());

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
                            .BuildGetOccupancyGroupMonitoringCommand());

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
                            .WithMonitoringType(MonitoringType.OccupancyGroupMonitoring)
                            .BuildGetOccupancyGroupMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.DeviceLockStateMonitoring)
                            .BuildGetOccupancyGroupMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 12 and not 13",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetOccupancyGroupMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.OccupancyGroupMonitoring)
                    .WithAction(MonitoringCommandActionNumber.Enable)
                    .BuildSetOccupancyGroupMonitoringCommand();

                Assert.AreEqual("#MONITORING,2,13,2<CR><LF>", command);
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
                            .BuildSetOccupancyGroupMonitoringCommand());

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
                            .WithMonitoringType(MonitoringType.OccupancyGroupMonitoring)
                            .BuildSetOccupancyGroupMonitoringCommand());

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
                            .WithMonitoringType(MonitoringType.OccupancyGroupMonitoring)
                            .BuildSetOccupancyGroupMonitoringCommand());

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
                            .BuildSetOccupancyGroupMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.DeviceLockStateMonitoring)
                            .BuildSetOccupancyGroupMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 12 and not 13",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetDeviceLockStateMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.DeviceLockStateMonitoring)
                    .BuildGetDeviceLockStateMonitoringCommand();

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
                            .WithMonitoringType(MonitoringType.DeviceLockStateMonitoring)
                            .BuildGetDeviceLockStateMonitoringCommand());

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
                            .BuildGetDeviceLockStateMonitoringCommand());

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
                            .BuildGetDeviceLockStateMonitoringCommand());

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
                            .WithMonitoringType(MonitoringType.DeviceLockStateMonitoring)
                            .BuildGetDeviceLockStateMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.SequenceMonitoring)
                            .BuildGetDeviceLockStateMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 14 and not 16",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetDeviceLockStateMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.DeviceLockStateMonitoring)
                    .WithAction(MonitoringCommandActionNumber.Enable)
                    .BuildGetDeviceLockStateMonitoringCommand();

                Assert.AreEqual("#MONITORING,2,14,2<CR><LF>", command);
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
                            .BuildSetDeviceLockStateMonitoringCommand());

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
                            .WithMonitoringType(MonitoringType.DeviceLockStateMonitoring)
                            .BuildSetDeviceLockStateMonitoringCommand());

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
                            .WithMonitoringType(MonitoringType.DeviceLockStateMonitoring)
                            .BuildSetDeviceLockStateMonitoringCommand());

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
                            .BuildSetDeviceLockStateMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.SequenceMonitoring)
                            .BuildSetDeviceLockStateMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 14 and not 15",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetSequenceMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.SequenceMonitoring)
                    .BuildGetSequenceMonitoringCommand();

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
                            .WithMonitoringType(MonitoringType.SequenceMonitoring)
                            .BuildGetSequenceMonitoringCommand());

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
                            .BuildGetSequenceMonitoringCommand());

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
                            .BuildGetSequenceMonitoringCommand());

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
                            .BuildGetSequenceMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.HVACMonitoring)
                            .BuildGetSequenceMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 16 and not 17",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetSequenceMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.SequenceMonitoring)
                    .WithAction(MonitoringCommandActionNumber.Enable)
                    .BuildSetSequenceMonitoringCommand();

                Assert.AreEqual("#MONITORING,2,16,2<CR><LF>", command);
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
                            .BuildSetSequenceMonitoringCommand());

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
                            .BuildSetSequenceMonitoringCommand());

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
                            .BuildSetSequenceMonitoringCommand());

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
                            .BuildSetSequenceMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.HVACMonitoring)
                            .BuildSetSequenceMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 16 and not 17",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetHVACMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.HVACMonitoring)
                    .BuildGetHVACMonitoringCommand();

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
                            .WithMonitoringType(MonitoringType.HVACMonitoring)
                            .BuildGetHVACMonitoringCommand());

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
                            .WithMonitoringType(MonitoringType.HVACMonitoring)
                            .BuildGetHVACMonitoringCommand());

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
                            .WithMonitoringType(MonitoringType.HVACMonitoring)
                            .BuildGetHVACMonitoringCommand());

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
                            .BuildGetHVACMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.HVACMonitoring)
                            .WithAction(default(MonitoringCommandActionNumber))
                            .BuildGetHVACMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 17 and not 0",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetHVACMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.HVACMonitoring)
                    .WithAction(MonitoringCommandActionNumber.Enable)
                    .BuildSetHVACMonitoringCommand();

                Assert.AreEqual("#MONITORING,2,17,2<CR><LF>", command);
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
                            .WithMonitoringType(MonitoringType.HVACMonitoring)
                            .BuildSetHVACMonitoringCommand());

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
                            .WithMonitoringType(MonitoringType.HVACMonitoring)
                            .BuildSetHVACMonitoringCommand());

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
                            .WithMonitoringType(MonitoringType.HVACMonitoring)
                            .BuildSetHVACMonitoringCommand());

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
                            .WithMonitoringType(MonitoringType.HVACMonitoring)
                            .BuildSetHVACMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.HVACMonitoring)
                            .WithAction(default(MonitoringCommandActionNumber))
                            .BuildSetHVACMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 17 and not 0",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetModeMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.ModeMonitoring)
                    .BuildGetModeMonitoringCommand();

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
                            .WithMonitoringType(MonitoringType.ModeMonitoring)
                            .BuildGetModeMonitoringCommand());

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
                            .BuildGetModeMonitoringCommand());

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
                            .BuildGetModeMonitoringCommand());

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
                            .WithMonitoringType(MonitoringType.ModeMonitoring)
                            .BuildGetModeMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ShadeGroupMonitoring)
                            .BuildGetModeMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 16 and not 17",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetModeMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.ModeMonitoring)
                    .WithAction(MonitoringCommandActionNumber.Enable)
                    .BuildSetModeMonitoringCommand();

                Assert.AreEqual("#MONITORING,2,18,2<CR><LF>", command);
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
                            .BuildSetModeMonitoringCommand());

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
                            .BuildSetModeMonitoringCommand());

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
                            .BuildSetModeMonitoringCommand());

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
                            .BuildSetModeMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.ShadeGroupMonitoring)
                            .BuildSetModeMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 16 and not 17",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetShadeGroupMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.ShadeGroupMonitoring)
                    .BuildGetShadeGroupMonitoringCommand();

                Assert.AreEqual("?MONITORING,2,23<CR><LF>", command);
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
                            .BuildGetShadeGroupMonitoringCommand());

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
                            .BuildGetShadeGroupMonitoringCommand());

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
                            .BuildGetShadeGroupMonitoringCommand());

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
                            .BuildGetShadeGroupMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.PartitionWall)
                            .BuildGetShadeGroupMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 23 and not 24",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetShadeGroupMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.ShadeGroupMonitoring)
                    .WithAction(MonitoringCommandActionNumber.Enable)
                    .BuildSetShadeGroupMonitoringCommand();

                Assert.AreEqual("#MONITORING,2,23,2<CR><LF>", command);
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
                            .BuildSetShadeGroupMonitoringCommand());

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
                            .BuildSetShadeGroupMonitoringCommand());

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
                            .BuildSetShadeGroupMonitoringCommand());

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
                            .BuildSetShadeGroupMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.PartitionWall)
                            .BuildSetShadeGroupMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 23 and not 24",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetPartitionWallCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.PartitionWall)
                    .BuildGetPartitionWallCommand();

                Assert.AreEqual("?MONITORING,2,24<CR><LF>", command);
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
                            .BuildGetPartitionWallCommand());

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
                            .BuildGetPartitionWallCommand());

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
                            .BuildGetPartitionWallCommand());

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
                            .WithMonitoringType(MonitoringType.PartitionWall)
                            .BuildGetPartitionWallCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.TemperatureSensorMonitoring)
                            .BuildGetPartitionWallCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 24 and not 27",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetPartitionWallCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.PartitionWall)
                    .WithAction(MonitoringCommandActionNumber.Enable)
                    .BuildSetPartitionWallCommand();

                Assert.AreEqual("#MONITORING,2,24,2<CR><LF>", command);
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
                            .BuildSetPartitionWallCommand());

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
                            .BuildSetPartitionWallCommand());

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
                            .BuildSetPartitionWallCommand());

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
                            .BuildSetPartitionWallCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.TemperatureSensorMonitoring)
                            .BuildSetPartitionWallCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 24 and not 27",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetTemperatureSensorMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.TemperatureSensorMonitoring)
                    .BuildGetTemperatureSensorMonitoringCommand();

                Assert.AreEqual("?MONITORING,2,27<CR><LF>", command);
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
                            .BuildGetTemperatureSensorMonitoringCommand());

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
                            .BuildGetTemperatureSensorMonitoringCommand());

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
                            .BuildGetTemperatureSensorMonitoringCommand());

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
                            .BuildGetTemperatureSensorMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.StateOfAllMonitoring)
                            .BuildGetTemperatureSensorMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 27 and not 255",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetTemperatureSensorMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.TemperatureSensorMonitoring)
                    .WithAction(MonitoringCommandActionNumber.Enable)
                    .BuildSetTemperatureSensorMonitoringCommand();

                Assert.AreEqual("#MONITORING,2,27,2<CR><LF>", command);
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
                            .BuildSetTemperatureSensorMonitoringCommand());

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
                            .BuildSetTemperatureSensorMonitoringCommand());

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
                            .BuildSetTemperatureSensorMonitoringCommand());

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
                            .BuildSetTemperatureSensorMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.StateOfAllMonitoring)
                            .BuildSetTemperatureSensorMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 27 and not 255",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetStateOfAllMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.StateOfAllMonitoring)
                    .BuildGetStateOfAllMonitoringCommand();

                Assert.AreEqual("?MONITORING,2,255<CR><LF>", command);
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
                            .WithMonitoringType(MonitoringType.StateOfAllMonitoring)
                            .BuildGetStateOfAllMonitoringCommand());

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
                            .WithMonitoringType(MonitoringType.StateOfAllMonitoring)
                            .BuildGetStateOfAllMonitoringCommand());

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
                            .WithMonitoringType(MonitoringType.StateOfAllMonitoring)
                            .BuildGetStateOfAllMonitoringCommand());

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
                            .BuildGetStateOfAllMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.DiagnosticMonitoring)
                            .BuildGetStateOfAllMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 255 and not 1",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetStateOfAllMonitoringCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = MonitoringCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithMonitoringType(MonitoringType.StateOfAllMonitoring)
                    .WithAction(MonitoringCommandActionNumber.Enable)
                    .BuildSetStateOfAllMonitoringCommand();

                Assert.AreEqual("#MONITORING,2,255,2<CR><LF>", command);
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
                            .WithMonitoringType(MonitoringType.StateOfAllMonitoring)
                            .BuildSetStateOfAllMonitoringCommand());

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
                            .WithMonitoringType(MonitoringType.StateOfAllMonitoring)
                            .BuildSetStateOfAllMonitoringCommand());

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
                            .WithMonitoringType(MonitoringType.StateOfAllMonitoring)
                            .BuildSetStateOfAllMonitoringCommand());

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
                            .BuildSetStateOfAllMonitoringCommand());

                    Assert.AreEqual("The monitoring type is not provided", exception.Message);
                }
            }

            [TestFixture]
            public class GivenIncorrectMonitoringType
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectMonitoringTypeProvided>(()
                        => MonitoringCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithMonitoringType(MonitoringType.StateOfAllMonitoring)
                            .BuildSetStateOfAllMonitoringCommand());

                    Assert.AreEqual("The monitoring type provided is incorrect. Expected 255 and not 1",
                        exception.Message);
                }
            }
        }
    }
}