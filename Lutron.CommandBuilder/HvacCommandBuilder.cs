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
        private Temperature _temperature;
        private SetPointHeat _setPointHeat;
        private SetPointCool _setPointCool;
        private HvacOperatingMode _operatingMode;
        private HvacFanMode _fanMode;
        private HvacEcoMode _ecoMode;
        private HvacScheduleStatus _scheduleStatus;

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


        public HvacCommandBuilder WithTemperature(Temperature temperature)
        {
            _temperature = temperature;
            return this;
        }

        public HvacCommandBuilder WithSetPointHeat(SetPointHeat setPointHeat)
        {
            _setPointHeat = setPointHeat;
            return this;
        }

        public HvacCommandBuilder WithSetPointCool(SetPointCool setPointCool)
        {
            _setPointCool = setPointCool;
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

        public string BuildGetCurrentTemperatureCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.CurrentTemperature);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildSetCurrentTemperatureCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.CurrentTemperature);

            CheckIfParameterIsProvided(_temperature, "temperature");

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_temperature}<CR><LF>";
        }

        public string BuildGetHeatAndCoolSetPointsCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.HeatAndCoolSetPoints);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildSetHeatAndCoolSetPointsCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.HeatAndCoolSetPoints);

            CheckIfParameterIsProvided(_setPointHeat, "set point heat");

            CheckIfParameterIsProvided(_setPointCool, "set point cool");

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_setPointHeat},{_setPointCool}<CR><LF>";
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

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.EcoOffset);

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