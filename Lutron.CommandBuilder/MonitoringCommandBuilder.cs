using Lutron.Common.Enums;
using Lutron.Common.Exceptions;
using Lutron.Common.Models;

namespace Lutron.CommandBuilder
{
    public class MonitoringCommandBuilder
    {
        private CommandOperation _operation;
        private MonitoringType _monitoringType;
        private int _integrationId;
        private readonly string _command = "MONITORING";
        private MonitoringCommandActionNumber _actionNumber;

        public static MonitoringCommandBuilder Create()
        {
            return new MonitoringCommandBuilder();
        }

        public MonitoringCommandBuilder WithOperation(CommandOperation operation)
        {
            _operation = operation;
            return this;
        }

        public MonitoringCommandBuilder WithIntegrationId(int integrationId)
        {
            _integrationId = integrationId;
            return this;
        }

        public MonitoringCommandBuilder WithMonitoringType(MonitoringType monitoringType)
        {
            _monitoringType = monitoringType;
            return this;
        }


        public MonitoringCommandBuilder WithAction(MonitoringCommandActionNumber actionNumber)
        {
            _actionNumber = actionNumber;
            return this;
        }

        public string BuildGetDiagnosticMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.CurrentTemperatureFahrenheit);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetDiagnosticMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.CurrentTemperatureFahrenheit);

            CheckIfParameterIsProvided(_temperatureFahrenheit, "temperature");

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{_temperatureFahrenheit}<CR><LF>";
        }

        public string BuildGetEventMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.HeatAndCoolSetPointsFahrenheit);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetEventMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.HeatAndCoolSetPointsFahrenheit);

            CheckIfParameterIsProvided(_heatSetPointFahrenheit, "set point heat");

            CheckIfParameterIsProvided(_coolSetPointFahrenheit, "set point cool");

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{_heatSetPointFahrenheit},{_coolSetPointFahrenheit}<CR><LF>";
        }

        public string BuildGetButtonMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.OperatingMode);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetButtonMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.OperatingMode);

            CheckIfParameterIsProvided(_operatingMode, "operating mode");

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int) _operatingMode}<CR><LF>";
        }

        public string BuildGetLedMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.FanMode);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetLedMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.FanMode);

            CheckIfParameterIsProvided(_fanMode, "fan mode");

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int) _fanMode}<CR><LF>";
        }

        public string BuildGetZoneMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.EcoMode);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetZoneMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.EcoMode);

            CheckIfParameterIsProvided(_ecoMode, "eco mode");

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int) _ecoMode}<CR><LF>";
        }

        public string BuildGetOccupancyCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.EcoOffsetFahrenheit);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetOccupancyCommand()
        {
            throw new System.NotImplementedException();
        }

        public string BuildGetPhotoSensorMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.ScheduleStatus);

            CheckIfProvidedParameterIsAGetScheduleStatus(_scheduleStatus);

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int) _scheduleStatus}<CR><LF>";
        }

        public string BuildSetPhotoSensorMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.ScheduleStatus);

            CheckIfProvidedParameterIsASetScheduleStatus(_scheduleStatus);

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int) _scheduleStatus}<CR><LF>";
        }

        public string BuildGetSceneCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.TemperatureSensorConnectionStatus);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetSceneCommand()
        {
            throw new System.NotImplementedException();
        }

        public string BuildGetSystemVariableCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.ScheduleEvent);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildGetScheduleDayAssignmentCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.ScheduleDayAssignment);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildGetSystemModeCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.SystemMode);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildGetHeatAndCoolSetPointsWithoutEcoOffsetCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber
                .HeatAndCoolSetPointsWithoutEcoOffsetFahrenheit);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildGetEmergencyHeatAvailableCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.EmergencyHeatAvailable);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildGetCallStatusCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.CallStatus);

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetCallStatusCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.CallStatus);

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int) _callStatus}<CR><LF>";
        }

        public string BuildGetCurrentTemperatureCelsiusCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.CurrentTemperatureCelsius);

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetCurrentTemperatureCelsiusCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.CurrentTemperatureCelsius);

            CheckIfParameterIsProvided(_temperatureCelsius, "temperature");

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{_temperatureCelsius}<CR><LF>";
        }

        public string BuildGetHeatAndCoolSetPointsCelsiusCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.HeatAndCoolSetPointsCelsius);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetHeatAndCoolSetPointsCelsiusCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.HeatAndCoolSetPointsCelsius);

            CheckIfParameterIsProvided(_heatSetPointCelsius, "set point heat");

            CheckIfParameterIsProvided(_coolSetPointCelsius, "set point cool");

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{_heatSetPointCelsius},{_coolSetPointCelsius}<CR><LF>";
        }

        public string BuildGetHeatAndCoolSetPointsWithoutEcoOffsetCelsiusCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.HeatAndCoolSetPointsWithoutEcoOffsetCelsius);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetHeatAndCoolSetPointsWithoutEcoOffsetCelsiusCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.HeatAndCoolSetPointsWithoutEcoOffsetCelsius);

            CheckIfParameterIsProvided(_heatSetPointCelsius, "set point heat");

            CheckIfParameterIsProvided(_coolSetPointCelsius, "set point cool");

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{_heatSetPointCelsius},{_coolSetPointCelsius}<CR><LF>";
        }

        public string BuildGetSingleSetPointAndDriftsFahrenheitCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.SingleSetPointAndDriftsFahrenheit);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetSingleSetPointAndDriftsFahrenheitCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.SingleSetPointAndDriftsFahrenheit);

            CheckIfParameterIsProvided(_singleSetPointFahrenheit, "single set point");

            CheckIfParameterIsProvided(_negativeDriftFahrenheit, "negative drift");

            CheckIfParameterIsProvided(_positiveDriftFahrenheit, "positive drift");

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{_singleSetPointFahrenheit},{_negativeDriftFahrenheit},{_positiveDriftFahrenheit}<CR><LF>";
        }

        public string BuildGetSingleSetPointAndDriftsCelsiusCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.SingleSetPointAndDriftsCelsius);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetSingleSetPointAndDriftsCelsiusCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber.SingleSetPointAndDriftsCelsius);

            CheckIfParameterIsProvided(_singleSetPointCelsius, "single set point");

            CheckIfParameterIsProvided(_negativeDriftCelsius, "negative drift");

            CheckIfParameterIsProvided(_positiveDriftCelsius, "positive drift");

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{_singleSetPointCelsius},{_negativeDriftCelsius},{_positiveDriftCelsius}<CR><LF>";
        }

        private void CheckIfParameterIsProvided(object parameter, string parameterName)
        {
            if (parameter is null ||
                parameter is MonitoringOperatingMode operatingMode && operatingMode == default(MonitoringOperatingMode) ||
                parameter is MonitoringFanMode fanMode && fanMode == default(MonitoringFanMode) ||
                parameter is MonitoringEcoMode ecoMode && ecoMode == default(MonitoringEcoMode)
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
            if (_monitoringType == default(MonitoringCommandActionNumber))
            {
                throw new ActionNumberNotProvided();
            }
        }

        private void CheckIfProvidedActionNumberIsCorrect(MonitoringCommandActionNumber expectedActionNumber)
        {
            if (_monitoringType != expectedActionNumber)
            {
                throw new IncorrectActionNumberProvided(_monitoringType,
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

        private void CheckIfProvidedParameterIsAGetScheduleStatus(MonitoringScheduleStatus scheduleStatus)
        {
            if (scheduleStatus == MonitoringScheduleStatus.FollowingSchedule)
            {
                throw new IncorrectScheduleStatusProvided(MonitoringScheduleStatus.FollowingSchedule,
                    MonitoringScheduleStatus.ScheduleUnavailable, MonitoringScheduleStatus.TemporaryHold);
            }

            if (scheduleStatus == MonitoringScheduleStatus.PermanentHold)
            {
                throw new IncorrectScheduleStatusProvided(MonitoringScheduleStatus.PermanentHold,
                    MonitoringScheduleStatus.ScheduleUnavailable, MonitoringScheduleStatus.TemporaryHold);
            }
        }


        private void CheckIfProvidedParameterIsASetScheduleStatus(MonitoringScheduleStatus scheduleStatus)
        {
            if (scheduleStatus == MonitoringScheduleStatus.ScheduleUnavailable)
            {
                throw new IncorrectScheduleStatusProvided(MonitoringScheduleStatus.ScheduleUnavailable,
                    MonitoringScheduleStatus.FollowingSchedule, MonitoringScheduleStatus.PermanentHold);
            }

            if (scheduleStatus == MonitoringScheduleStatus.TemporaryHold)
            {
                throw new IncorrectScheduleStatusProvided(MonitoringScheduleStatus.TemporaryHold,
                    MonitoringScheduleStatus.FollowingSchedule, MonitoringScheduleStatus.PermanentHold);
            }
        }
    }
}