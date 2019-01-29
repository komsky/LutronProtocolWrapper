using System;
using Lutron.Common.Enums;
using Lutron.Common.Exceptions;
using Lutron.Common.Models;

namespace Lutron.CommandBuilder
{
    public class HvacCommandBuilder
    {
        private CommandOperation _operation;
        private HvacCommandActionNumber _actionNumber;
        private int _integrationId;
        private readonly string _command = "HVAC";
        private TemperatureFahrenheit _temperatureFahrenheit;
        private HeatSetPointFahrenheit _heatSetPointFahrenheit;
        private CoolSetPointFahrenheit _coolSetPointFahrenheit;
        private HvacOperatingMode _operatingMode;
        private HvacFanMode _fanMode;
        private HvacEcoMode _ecoMode;
        private HvacScheduleStatus _scheduleStatus;
        private HvacCallStatus _callStatus;
        private TemperatureCelsius _temperatureCelsius;
        private HeatSetPointCelsius _heatSetPointCelsius;
        private CoolSetPointCelsius _coolSetPointCelsius;

        public static HvacCommandBuilder Create()
        {
            return new HvacCommandBuilder();
        }

        public HvacCommandBuilder WithOperation(CommandOperation operation)
        {
            _operation = operation;
            return this;
        }

        public HvacCommandBuilder WithIntegrationId(int integrationId)
        {
            _integrationId = integrationId;
            return this;
        }

        public HvacCommandBuilder WithAction(HvacCommandActionNumber actionNumber)
        {
            _actionNumber = actionNumber;
            return this;
        }


        public HvacCommandBuilder WithTemperature(TemperatureFahrenheit temperatureFahrenheit)
        {
            _temperatureFahrenheit = temperatureFahrenheit;
            return this;
        }

        public HvacCommandBuilder WithTemperature(TemperatureCelsius temperatureCelsius)
        {
            _temperatureCelsius = temperatureCelsius;
            return this;
        }

        public HvacCommandBuilder WithSetPointHeat(HeatSetPointFahrenheit heatSetPointFahrenheit)
        {
            _heatSetPointFahrenheit = heatSetPointFahrenheit;
            return this;
        }

        public HvacCommandBuilder WithSetPointCool(CoolSetPointFahrenheit coolSetPointFahrenheit)
        {
            _coolSetPointFahrenheit = coolSetPointFahrenheit;
            return this;
        }

        public HvacCommandBuilder WithSetPointHeat(HeatSetPointCelsius heatSetPointCelsius)
        {
            _heatSetPointCelsius = heatSetPointCelsius;
            return this;
        }

        public HvacCommandBuilder WithSetPointCool(CoolSetPointCelsius coolSetPointCelsius)
        {
            _coolSetPointCelsius = coolSetPointCelsius;
            return this;
        }

        public HvacCommandBuilder WithOperatingMode(HvacOperatingMode operatingMode)
        {
            _operatingMode = operatingMode;
            return this;
        }

        public HvacCommandBuilder WithFanMode(HvacFanMode fanMode)
        {
            _fanMode = fanMode;
            return this;
        }

        public HvacCommandBuilder WithEcoMode(HvacEcoMode ecoMode)
        {
            _ecoMode = ecoMode;
            return this;
        }

        public HvacCommandBuilder WithScheduleStatus(HvacScheduleStatus scheduleStatus)
        {
            _scheduleStatus = scheduleStatus;
            return this;
        }

        public HvacCommandBuilder WithCallStatus(HvacCallStatus callStatus)
        {
            _callStatus = callStatus;
            return this;
        }

        public string BuildGetCurrentTemperatureCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.CurrentTemperatureFahrenheit);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildSetCurrentTemperatureCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.CurrentTemperatureFahrenheit);

            CheckIfParameterIsProvided(_temperatureFahrenheit, "temperature");

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_temperatureFahrenheit}<CR><LF>";
        }

        public string BuildGetHeatAndCoolSetPointsFahrenheitCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.HeatAndCoolSetPointsFahrenheit);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildSetHeatAndCoolSetPointsFahrenheitCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.HeatAndCoolSetPointsFahrenheit);

            CheckIfParameterIsProvided(_heatSetPointFahrenheit, "set point heat");

            CheckIfParameterIsProvided(_coolSetPointFahrenheit, "set point cool");

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_heatSetPointFahrenheit},{_coolSetPointFahrenheit}<CR><LF>";
        }

        public string BuildGetOperatingModeCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.OperatingMode);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildSetOperatingModeCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.OperatingMode);

            CheckIfParameterIsProvided(_operatingMode, "operating mode");

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{(int) _operatingMode}<CR><LF>";
        }

        public string BuildGetFanModeCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.FanMode);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildSetFanModeCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.FanMode);

            CheckIfParameterIsProvided(_fanMode, "fan mode");

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{(int) _fanMode}<CR><LF>";
        }

        public string BuildGetEcoModeCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.EcoMode);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildSetEcoModeCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.EcoMode);

            CheckIfParameterIsProvided(_ecoMode, "eco mode");

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{(int) _ecoMode}<CR><LF>";
        }

        public string BuildGetEcoOffsetCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.EcoOffsetFahrenheit);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildGetScheduleStatusCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.ScheduleStatus);

            CheckIfProvidedParameterIsAGetScheduleStatus(_scheduleStatus);

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{(int) _scheduleStatus}<CR><LF>";
        }

        public string BuildSetScheduleStatusCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.ScheduleStatus);

            CheckIfProvidedParameterIsASetScheduleStatus(_scheduleStatus);

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{(int) _scheduleStatus}<CR><LF>";
        }

        public string BuildGetTemperatureSensorConnectionStatusCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.TemperatureSensorConnectionStatus);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildGetScheduleEventCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.ScheduleEvent);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildGetScheduleDayAssignmentCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.ScheduleDayAssignment);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildGetSystemModeCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.SystemMode);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildGetHeatAndCoolSetPointsWithoutEcoOffsetCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber
                .HeatAndCoolSetPointsWithoutEcoOffsetFahrenheit);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildGetEmergencyHeatAvailableCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.EmergencyHeatAvailable);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildGetCallStatusCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.CallStatus);

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildSetCallStatusCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.CallStatus);

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{(int) _callStatus}<CR><LF>";
        }

        public string BuildGetCurrentTemperatureCelsiusCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.CurrentTemperatureCelsius);

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildSetCurrentTemperatureCelsiusCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.CurrentTemperatureCelsius);

            CheckIfParameterIsProvided(_temperatureCelsius, "temperature");

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_temperatureCelsius}<CR><LF>";
        }

        public string BuildGetHeatAndCoolSetPointsCelsiusCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.HeatAndCoolSetPointsCelsius);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildSetHeatAndCoolSetPointsCelsiusCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.HeatAndCoolSetPointsCelsius);

            CheckIfParameterIsProvided(_heatSetPointCelsius, "set point heat");

            CheckIfParameterIsProvided(_coolSetPointCelsius, "set point cool");

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_heatSetPointCelsius},{_coolSetPointCelsius}<CR><LF>";
        }

        public string BuildGetHeatAndCoolSetPointsWithoutEcoOffsetCelsiusCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.HeatAndCoolSetPointsWithoutEcoOffsetCelsius);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildSetHeatAndCoolSetPointsWithoutEcoOffsetCelsiusCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.HeatAndCoolSetPointsWithoutEcoOffsetCelsius);

            CheckIfParameterIsProvided(_heatSetPointCelsius, "set point heat");

            CheckIfParameterIsProvided(_coolSetPointCelsius, "set point cool");

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_heatSetPointCelsius},{_coolSetPointCelsius}<CR><LF>";
        }

        private void CheckIfParameterIsProvided(object parameter, string parameterName)
        {
            if (parameter is null ||
                parameter is HvacOperatingMode operatingMode && operatingMode == default(HvacOperatingMode) ||
                parameter is HvacFanMode fanMode && fanMode == default(HvacFanMode) ||
                parameter is HvacEcoMode ecoMode && ecoMode == default(HvacEcoMode)
            )
            {
                throw new ParameterNotProvided(parameterName);
            }
        }

        private void CheckIfCorrectOperationIsProvided(CommandOperation expectedOperation)
        {
            if (_operation != expectedOperation)
            {
                throw new IncorrectOperationProvided(_operation, expectedOperation);
            }
        }

        private void CheckIfOperationIsProvided()
        {
            if (_operation == default(CommandOperation))
            {
                throw new OperationNotProvided();
            }
        }

        private void CheckIfActionNumberIsProvided()
        {
            if (_actionNumber == default(HvacCommandActionNumber))
            {
                throw new ActionNumberNotProvided();
            }
        }

        private void CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber expectedActionNumber)
        {
            if (_actionNumber != expectedActionNumber)
            {
                throw new IncorrectActionNumberProvided(_actionNumber,
                    expectedActionNumber);
            }
        }


        private void CheckIfIntegrationIdIsProvided()
        {
            if (_integrationId == default(int))
            {
                throw new IntegrationIdNotProvided();
            }
        }

        private void CheckIfProvidedParameterIsAGetScheduleStatus(HvacScheduleStatus scheduleStatus)
        {
            if (scheduleStatus == HvacScheduleStatus.FollowingSchedule)
            {
                throw new IncorrectScheduleStatusProvided(HvacScheduleStatus.FollowingSchedule,
                    HvacScheduleStatus.ScheduleUnavailable, HvacScheduleStatus.TemporaryHold);
            }

            if (scheduleStatus == HvacScheduleStatus.PermanentHold)
            {
                throw new IncorrectScheduleStatusProvided(HvacScheduleStatus.PermanentHold,
                    HvacScheduleStatus.ScheduleUnavailable, HvacScheduleStatus.TemporaryHold);
            }
        }

        private void CheckIfProvidedParameterIsASetScheduleStatus(HvacScheduleStatus scheduleStatus)
        {
            if (scheduleStatus == HvacScheduleStatus.ScheduleUnavailable)
            {
                throw new IncorrectScheduleStatusProvided(HvacScheduleStatus.ScheduleUnavailable,
                    HvacScheduleStatus.FollowingSchedule, HvacScheduleStatus.PermanentHold);
            }

            if (scheduleStatus == HvacScheduleStatus.TemporaryHold)
            {
                throw new IncorrectScheduleStatusProvided(HvacScheduleStatus.TemporaryHold,
                    HvacScheduleStatus.FollowingSchedule, HvacScheduleStatus.PermanentHold);
            }
        }
    }
}