using System;
using Lutron.Common.Enums;
using Lutron.Common.Exceptions;
using Lutron.Common.Models;
using NUnit.Framework;

namespace Lutron.CommandBuilder.Tests
{
    [TestFixture]
    public class HvacCommandBuilderTests
    {
        [TestFixture]
        public class BuildGetCurrentTemperatureCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.CurrentTemperatureFahrenheit)
                    .BuildGetCurrentTemperatureCommand();

                Assert.AreEqual("?HVAC,2,1<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.CurrentTemperatureFahrenheit)
                            .BuildGetCurrentTemperatureCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.CurrentTemperatureFahrenheit)
                            .BuildGetCurrentTemperatureCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(HvacCommandActionNumber.CurrentTemperatureFahrenheit)
                            .BuildGetCurrentTemperatureCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetCurrentTemperatureCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsFahrenheit)
                            .BuildGetCurrentTemperatureCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 1 and not 2",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetCurrentTemperatureCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.CurrentTemperatureFahrenheit)
                    .WithTemperature(new TemperatureFahrenheit(34))
                    .BuildSetCurrentTemperatureCommand();

                Assert.AreEqual("#HVAC,2,1,34<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoTemperatureParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.CurrentTemperatureFahrenheit)
                            .BuildSetCurrentTemperatureCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.CurrentTemperatureFahrenheit)
                            .BuildSetCurrentTemperatureCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.CurrentTemperatureFahrenheit)
                            .BuildSetCurrentTemperatureCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(HvacCommandActionNumber.CurrentTemperatureFahrenheit)
                            .BuildSetCurrentTemperatureCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetCurrentTemperatureCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsFahrenheit)
                            .BuildSetCurrentTemperatureCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 1 and not 2",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetHeatAndCoolSetPointsFahrenheitCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsFahrenheit)
                    .BuildGetHeatAndCoolSetPointsFahrenheitCommand();

                Assert.AreEqual("?HVAC,2,2<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsFahrenheit)
                            .BuildGetHeatAndCoolSetPointsFahrenheitCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsFahrenheit)
                            .BuildGetHeatAndCoolSetPointsFahrenheitCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsFahrenheit)
                            .BuildGetHeatAndCoolSetPointsFahrenheitCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetHeatAndCoolSetPointsFahrenheitCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.OperatingMode)
                            .BuildGetHeatAndCoolSetPointsFahrenheitCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 2 and not 3",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetHeatAndCoolSetPointsFahrenheitCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsFahrenheit)
                    .WithSetPointHeat(new HeatSetPointFahrenheit(34))
                    .WithSetPointCool(new CoolSetPointFahrenheit(34))
                    .BuildSetHeatAndCoolSetPointsFahrenheitCommand();

                Assert.AreEqual("#HVAC,2,2,34,34<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoSetPointHeatParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsFahrenheit)
                            .WithSetPointCool(new CoolSetPointFahrenheit(55))
                            .BuildSetHeatAndCoolSetPointsFahrenheitCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsFahrenheit)
                            .WithSetPointHeat(new HeatSetPointFahrenheit(98))
                            .BuildSetHeatAndCoolSetPointsFahrenheitCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsFahrenheit)
                            .BuildSetHeatAndCoolSetPointsFahrenheitCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsFahrenheit)
                            .BuildSetHeatAndCoolSetPointsFahrenheitCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsFahrenheit)
                            .BuildSetHeatAndCoolSetPointsFahrenheitCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetHeatAndCoolSetPointsFahrenheitCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.OperatingMode)
                            .BuildSetHeatAndCoolSetPointsFahrenheitCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 2 and not 3",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetOperatingModeCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.OperatingMode)
                    .BuildGetOperatingModeCommand();

                Assert.AreEqual("?HVAC,2,3<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.OperatingMode)
                            .BuildGetOperatingModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.OperatingMode)
                            .BuildGetOperatingModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(HvacCommandActionNumber.OperatingMode)
                            .BuildGetOperatingModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetOperatingModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.FanMode)
                            .BuildGetOperatingModeCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 3 and not 4",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetOperatingModeCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.OperatingMode)
                    .WithOperatingMode(HvacOperatingMode.Dry)
                    .BuildSetOperatingModeCommand();

                Assert.AreEqual("#HVAC,2,3,8<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperatingModeParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.OperatingMode)
                            .BuildSetOperatingModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.OperatingMode)
                            .BuildSetOperatingModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.OperatingMode)
                            .BuildSetOperatingModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(HvacCommandActionNumber.OperatingMode)
                            .BuildSetOperatingModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetOperatingModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.FanMode)
                            .BuildSetOperatingModeCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 3 and not 4",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetFanModeCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.FanMode)
                    .BuildGetFanModeCommand();

                Assert.AreEqual("?HVAC,2,4<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.FanMode)
                            .BuildGetFanModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.FanMode)
                            .BuildGetFanModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(HvacCommandActionNumber.FanMode)
                            .BuildGetFanModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetFanModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.EcoMode)
                            .BuildGetFanModeCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 4 and not 5",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetFanModeCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.FanMode)
                    .WithFanMode(HvacFanMode.Top)
                    .BuildSetFanModeCommand();

                Assert.AreEqual("#HVAC,2,4,8<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoFanModeParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.FanMode)
                            .BuildSetFanModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.FanMode)
                            .BuildSetFanModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.FanMode)
                            .BuildSetFanModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(HvacCommandActionNumber.FanMode)
                            .BuildSetFanModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetFanModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.EcoMode)
                            .BuildSetFanModeCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 4 and not 5",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetEcoModeCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.EcoMode)
                    .BuildGetEcoModeCommand();

                Assert.AreEqual("?HVAC,2,5<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.EcoMode)
                            .BuildGetEcoModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.EcoMode)
                            .BuildGetEcoModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(HvacCommandActionNumber.EcoMode)
                            .BuildGetEcoModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetEcoModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.EcoOffsetFahrenheit)
                            .BuildGetEcoModeCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 5 and not 6",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetEcoModeCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.EcoMode)
                    .WithEcoMode(HvacEcoMode.On)
                    .BuildSetEcoModeCommand();

                Assert.AreEqual("#HVAC,2,5,2<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoEcoModeParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.EcoMode)
                            .BuildSetEcoModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.EcoMode)
                            .BuildSetEcoModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.EcoMode)
                            .BuildSetEcoModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(HvacCommandActionNumber.EcoMode)
                            .BuildSetEcoModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetEcoModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.EcoOffsetFahrenheit)
                            .BuildSetEcoModeCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 5 and not 6",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetEcoOffsetCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.EcoOffsetFahrenheit)
                    .BuildGetEcoOffsetCommand();

                Assert.AreEqual("?HVAC,2,6<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.EcoOffsetFahrenheit)
                            .BuildGetEcoOffsetCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.EcoOffsetFahrenheit)
                            .BuildGetEcoOffsetCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(HvacCommandActionNumber.EcoOffsetFahrenheit)
                            .BuildGetEcoOffsetCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetEcoOffsetCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.ScheduleStatus)
                            .BuildGetEcoOffsetCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 6 and not 7",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetScheduleStatusCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.ScheduleStatus)
                    .WithScheduleStatus(HvacScheduleStatus.ScheduleUnavailable)
                    .BuildGetScheduleStatusCommand();

                Assert.AreEqual("?HVAC,2,7,0<CR><LF>", command);
            }

            [TestFixture]
            public class GivenFollowingScheduleScheduleStatusParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectScheduleStatusProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.ScheduleStatus)
                            .WithScheduleStatus(HvacScheduleStatus.FollowingSchedule)
                            .BuildGetScheduleStatusCommand());

                    Assert.AreEqual("The schedule status provided is incorrect. Expected 0 or 3, not 1"
                        , exception.Message);
                }
            }

            [TestFixture]
            public class GivenPermanentHoldScheduleStatusParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectScheduleStatusProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.ScheduleStatus)
                            .WithScheduleStatus(HvacScheduleStatus.PermanentHold)
                            .BuildGetScheduleStatusCommand());

                    Assert.AreEqual("The schedule status provided is incorrect. Expected 0 or 3, not 2"
                        , exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.ScheduleStatus)
                            .BuildGetScheduleStatusCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.ScheduleStatus)
                            .BuildGetScheduleStatusCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(HvacCommandActionNumber.ScheduleStatus)
                            .BuildGetScheduleStatusCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetScheduleStatusCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.TemperatureSensorConnectionStatus)
                            .BuildGetScheduleStatusCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 7 and not 8",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetScheduleStatusCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.ScheduleStatus)
                    .WithScheduleStatus(HvacScheduleStatus.FollowingSchedule)
                    .BuildSetScheduleStatusCommand();

                Assert.AreEqual("#HVAC,2,7,1<CR><LF>", command);
            }

            [TestFixture]
            public class GivenScheduleUnavailableScheduleStatusParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectScheduleStatusProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.ScheduleStatus)
                            .WithScheduleStatus(HvacScheduleStatus.ScheduleUnavailable)
                            .BuildSetScheduleStatusCommand());

                    Assert.AreEqual("The schedule status provided is incorrect. Expected 1 or 2, not 0"
                        , exception.Message);
                }
            }

            [TestFixture]
            public class GivenTemporaryHoldScheduleStatusParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<IncorrectScheduleStatusProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.ScheduleStatus)
                            .WithScheduleStatus(HvacScheduleStatus.TemporaryHold)
                            .BuildSetScheduleStatusCommand());

                    Assert.AreEqual("The schedule status provided is incorrect. Expected 1 or 2, not 3"
                        , exception.Message);
                }
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.ScheduleStatus)
                            .BuildSetScheduleStatusCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.ScheduleStatus)
                            .BuildSetScheduleStatusCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(HvacCommandActionNumber.ScheduleStatus)
                            .BuildSetScheduleStatusCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .BuildSetScheduleStatusCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.TemperatureSensorConnectionStatus)
                            .BuildSetScheduleStatusCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 7 and not 8",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetTemperatureSensorConnectionStatusCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.TemperatureSensorConnectionStatus)
                    .BuildGetTemperatureSensorConnectionStatusCommand();

                Assert.AreEqual("?HVAC,2,8<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.TemperatureSensorConnectionStatus)
                            .BuildGetTemperatureSensorConnectionStatusCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.TemperatureSensorConnectionStatus)
                            .BuildGetTemperatureSensorConnectionStatusCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(HvacCommandActionNumber.TemperatureSensorConnectionStatus)
                            .BuildGetTemperatureSensorConnectionStatusCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetTemperatureSensorConnectionStatusCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.ScheduleEvent)
                            .BuildGetTemperatureSensorConnectionStatusCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 8 and not 9",
                        exception.Message);
                }
            }
        }
 
        [TestFixture]
        public class BuildGetScheduleEventCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.ScheduleEvent)
                    .BuildGetScheduleEventCommand();

                Assert.AreEqual("?HVAC,2,9<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.ScheduleEvent)
                            .BuildGetScheduleEventCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.ScheduleEvent)
                            .BuildGetScheduleEventCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(HvacCommandActionNumber.ScheduleEvent)
                            .BuildGetScheduleEventCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetScheduleEventCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.ScheduleDayAssignment)
                            .BuildGetScheduleEventCommand());

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
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.ScheduleDayAssignment)
                    .BuildGetScheduleDayAssignmentCommand();

                Assert.AreEqual("?HVAC,2,10<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.ScheduleDayAssignment)
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.ScheduleDayAssignment)
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(HvacCommandActionNumber.ScheduleDayAssignment)
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
                        => HvacCommandBuilder.Create()
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.SystemMode)
                            .BuildGetScheduleDayAssignmentCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 10 and not 11",
                        exception.Message);
                }
            }
        } 
        
        [TestFixture]
        public class BuildGetSystemModeCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.SystemMode)
                    .BuildGetSystemModeCommand();

                Assert.AreEqual("?HVAC,2,11<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.SystemMode)
                            .BuildGetSystemModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.SystemMode)
                            .BuildGetSystemModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(HvacCommandActionNumber.SystemMode)
                            .BuildGetSystemModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .BuildGetSystemModeCommand());

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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsWithoutEcoOffsetFahrenheit)
                            .BuildGetSystemModeCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 11 and not 12",
                        exception.Message);
                }
            }
        }      
        
        [TestFixture]
        public class BuildGetHeatAndCoolSetPointsWithoutEcoOffsetCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsWithoutEcoOffsetFahrenheit)
                    .BuildGetHeatAndCoolSetPointsWithoutEcoOffsetCommand();

                Assert.AreEqual("?HVAC,2,12<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsWithoutEcoOffsetFahrenheit)
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsWithoutEcoOffsetFahrenheit)
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsWithoutEcoOffsetFahrenheit)
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
                        => HvacCommandBuilder.Create()
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.EmergencyHeatAvailable)
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
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.EmergencyHeatAvailable)
                    .BuildGetEmergencyHeatAvailableCommand();

                Assert.AreEqual("?HVAC,2,13<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.EmergencyHeatAvailable)
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.EmergencyHeatAvailable)
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(HvacCommandActionNumber.EmergencyHeatAvailable)
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
                        => HvacCommandBuilder.Create()
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.CallStatus)
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
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.CallStatus)
                    .BuildGetCallStatusCommand();

                Assert.AreEqual("?HVAC,2,14<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.CallStatus)
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.CallStatus)
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(HvacCommandActionNumber.CallStatus)
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
                        => HvacCommandBuilder.Create()
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.CurrentTemperatureCelsius)
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
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.CallStatus)
                    .WithCallStatus(HvacCallStatus.NoneLastWasCool)
                    .BuildSetCallStatusCommand();

                Assert.AreEqual("#HVAC,2,14,5<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.CallStatus)
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.CallStatus)
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(HvacCommandActionNumber.CallStatus)
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
                        => HvacCommandBuilder.Create()
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.CurrentTemperatureCelsius)
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
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.CurrentTemperatureCelsius)
                    .BuildGetCurrentTemperatureCelsiusCommand();

                Assert.AreEqual("?HVAC,2,15<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.CurrentTemperatureCelsius)
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.CurrentTemperatureCelsius)
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(HvacCommandActionNumber.CurrentTemperatureCelsius)
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
                        => HvacCommandBuilder.Create()
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsCelsius)
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
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.CurrentTemperatureCelsius)
                    .WithTemperature(new TemperatureCelsius(34))
                    .BuildSetCurrentTemperatureCelsiusCommand();

                Assert.AreEqual("#HVAC,2,15,34<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoTemperatureParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.CurrentTemperatureCelsius)
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
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.CurrentTemperatureCelsius)
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.CurrentTemperatureCelsius)
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(HvacCommandActionNumber.CurrentTemperatureCelsius)
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
                        => HvacCommandBuilder.Create()
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsCelsius)
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
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsCelsius)
                    .BuildGetHeatAndCoolSetPointsCelsiusCommand();

                Assert.AreEqual("?HVAC,2,16<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsCelsius)
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsCelsius)
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsCelsius)
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
                        => HvacCommandBuilder.Create()
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsWithoutEcoOffsetCelsius)
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
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsCelsius)
                    .WithSetPointHeat(new HeatSetPointCelsius(34))
                    .WithSetPointCool(new CoolSetPointCelsius(34))
                    .BuildSetHeatAndCoolSetPointsCelsiusCommand();

                Assert.AreEqual("#HVAC,2,16,34,34<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoSetPointHeatParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsCelsius)
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsCelsius)
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
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsCelsius)
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsCelsius)
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsCelsius)
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
                        => HvacCommandBuilder.Create()
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsWithoutEcoOffsetCelsius)
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
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsWithoutEcoOffsetCelsius)
                    .BuildGetHeatAndCoolSetPointsWithoutEcoOffsetCelsiusCommand();

                Assert.AreEqual("?HVAC,2,17<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoOperation
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<OperationNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsWithoutEcoOffsetCelsius)
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsWithoutEcoOffsetCelsius)
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsWithoutEcoOffsetCelsius)
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
                        => HvacCommandBuilder.Create()
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.SingSetPointAndDriftsFahrenheit)
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
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsWithoutEcoOffsetCelsius)
                    .WithSetPointHeat(new HeatSetPointCelsius(34))
                    .WithSetPointCool(new CoolSetPointCelsius(34))
                    .BuildSetHeatAndCoolSetPointsWithoutEcoOffsetCelsiusCommand();

                Assert.AreEqual("#HVAC,2,17,34,34<CR><LF>", command);
            }

            [TestFixture]
            public class GivenNoSetPointHeatParameter
            {
                [Test]
                public void ShouldThrowException()
                {
                    var exception = Assert.Throws<ParameterNotProvided>(()
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsWithoutEcoOffsetCelsius)
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsWithoutEcoOffsetCelsius)
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
                        => HvacCommandBuilder.Create()
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsWithoutEcoOffsetCelsius)
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Get)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsWithoutEcoOffsetCelsius)
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPointsWithoutEcoOffsetCelsius)
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
                        => HvacCommandBuilder.Create()
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
                        => HvacCommandBuilder.Create()
                            .WithOperation(CommandOperation.Set)
                            .WithIntegrationId(2)
                            .WithAction(HvacCommandActionNumber.SingSetPointAndDriftsFahrenheit)
                            .BuildSetHeatAndCoolSetPointsWithoutEcoOffsetCelsiusCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 17 and not 18",
                        exception.Message);
                }
            }
        }

    }
}