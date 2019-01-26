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
                    .WithAction(HvacCommandActionNumber.CurrentTemperature)
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
                            .WithAction(HvacCommandActionNumber.CurrentTemperature)
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
                            .WithAction(HvacCommandActionNumber.CurrentTemperature)
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
                            .WithAction(HvacCommandActionNumber.CurrentTemperature)
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
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPoints)
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
                    .WithAction(HvacCommandActionNumber.CurrentTemperature)
                    .WithTemperature(new Temperature(34))
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
                            .WithAction(HvacCommandActionNumber.CurrentTemperature)
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
                            .WithAction(HvacCommandActionNumber.CurrentTemperature)
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
                            .WithAction(HvacCommandActionNumber.CurrentTemperature)
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
                            .WithAction(HvacCommandActionNumber.CurrentTemperature)
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
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPoints)
                            .BuildSetCurrentTemperatureCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 1 and not 2",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildGetHeatAndCoolSetPointsCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Get)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.HeatAndCoolSetPoints)
                    .BuildGetHeatAndCoolSetPointsCommand();

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
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPoints)
                            .BuildGetHeatAndCoolSetPointsCommand());

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
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPoints)
                            .BuildGetHeatAndCoolSetPointsCommand());

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
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPoints)
                            .BuildGetHeatAndCoolSetPointsCommand());

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
                            .BuildGetHeatAndCoolSetPointsCommand());

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
                            .BuildGetHeatAndCoolSetPointsCommand());

                    Assert.AreEqual("The action number provided is incorrect. Expected 2 and not 3",
                        exception.Message);
                }
            }
        }

        [TestFixture]
        public class BuildSetHeatAndCoolSetPointsCommand
        {
            [Test]
            public void ShouldReturnCommandString()
            {
                var command = HvacCommandBuilder.Create()
                    .WithOperation(CommandOperation.Set)
                    .WithIntegrationId(2)
                    .WithAction(HvacCommandActionNumber.HeatAndCoolSetPoints)
                    .WithSetPointHeat(new SetPointHeat(34))
                    .WithSetPointCool(new SetPointCool(34))
                    .BuildSetHeatAndCoolSetPointsCommand();

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
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPoints)
                            .WithSetPointCool(new SetPointCool(55))
                            .BuildSetHeatAndCoolSetPointsCommand());

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
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPoints)
                            .WithSetPointHeat(new SetPointHeat(98))
                            .BuildSetHeatAndCoolSetPointsCommand());

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
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPoints)
                            .BuildSetHeatAndCoolSetPointsCommand());

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
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPoints)
                            .BuildSetHeatAndCoolSetPointsCommand());

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
                            .WithAction(HvacCommandActionNumber.HeatAndCoolSetPoints)
                            .BuildSetHeatAndCoolSetPointsCommand());

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
                            .BuildSetHeatAndCoolSetPointsCommand());

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
                            .BuildSetHeatAndCoolSetPointsCommand());

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
    }
}