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

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.DiagnosticMonitoring);
            
            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetDiagnosticMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.DiagnosticMonitoring);
            
            CheckIfActionNumberIsProvided();

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int)_actionNumber}<CR><LF>";
        }

        public string BuildGetEventMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.EventMonitoring);
            
            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetEventMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.EventMonitoring);
            
            CheckIfActionNumberIsProvided();

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildGetButtonMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.ButtonMonitoring);
            
            CheckIfActionNumberIsProvided();
            
            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetButtonMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.ButtonMonitoring);
            
            CheckIfActionNumberIsProvided();

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildGetLEDMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.LEDMonitoring);
            
            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetLEDMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.LEDMonitoring);
            
            CheckIfActionNumberIsProvided();

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildGetZoneMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.ZoneMonitoring);
            
            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetZoneMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.ZoneMonitoring);
            
            CheckIfActionNumberIsProvided();

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildGetOccupancyCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.Occupancy);
            
            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetOccupancyCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.Occupancy);
            
            CheckIfActionNumberIsProvided();

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int)_actionNumber}<CR><LF>";
        }

        public string BuildGetPhotoSensorMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.PhotoSensorMonitoring);
            
            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildSetPhotoSensorMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.PhotoSensorMonitoring);
            
            CheckIfActionNumberIsProvided();

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildGetSceneCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.Scene);
            
            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetSceneCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.Scene);
            
            CheckIfActionNumberIsProvided();

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int)_actionNumber}<CR><LF>";
        }

        public string BuildGetSystemVariableCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.SystemVariable);
            
            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetSystemVariableCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.SystemVariable);
            
            CheckIfActionNumberIsProvided();

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int)_actionNumber}<CR><LF>";
        }

        public string BuildGetReplyStateCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.ReplyState);
            
            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetReplyStateCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.ReplyState);
            
            CheckIfActionNumberIsProvided();

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int)_actionNumber}<CR><LF>";
        }

        public string BuildGetPromptStateCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.PromptState);
            
            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";        }

        public string BuildSetPromptStateCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.PromptState);
            
            CheckIfActionNumberIsProvided();

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int)_actionNumber}<CR><LF>";
        }

        public string BuildGetOccupancyGroupMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.OccupancyGroupMonitoring);
            
            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetOccupancyGroupMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.OccupancyGroupMonitoring);
            
            CheckIfActionNumberIsProvided();

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int)_actionNumber}<CR><LF>";
        }

        public string BuildGetDeviceLockStateMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.DeviceLockStateMonitoring);
            
            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetDeviceLockStateMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.DeviceLockStateMonitoring);
            
            CheckIfActionNumberIsProvided();

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int)_actionNumber}<CR><LF>";
        }

        public string BuildGetSequenceMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.SequenceMonitoring);
            
            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetSequenceMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.SequenceMonitoring);
            
            CheckIfActionNumberIsProvided();

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int)_actionNumber}<CR><LF>";
        }

        public string BuildGetHVACMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.HVACMonitoring);
            
            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetHVACMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.HVACMonitoring);
            
            CheckIfActionNumberIsProvided();

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildGetModeMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.ModeMonitoring);
            
            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetModeMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.ModeMonitoring);
            
            CheckIfActionNumberIsProvided();

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int)_actionNumber}<CR><LF>";
        }

        public string BuildGetShadeGroupMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();
            
            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.ShadeGroupMonitoring);
            
            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetShadeGroupMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.ShadeGroupMonitoring);
            
            CheckIfActionNumberIsProvided();

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int)_actionNumber}<CR><LF>";
        }

        public string BuildGetPartitionWallCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.PartitionWall);
            
            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetPartitionWallCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.PartitionWall);
            
            CheckIfActionNumberIsProvided();
            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int)_actionNumber}<CR><LF>";
        }

        public string BuildGetTemperatureSensorMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.TemperatureSensorMonitoring);
            
            return $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetTemperatureSensorMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.TemperatureSensorMonitoring);
            
            CheckIfActionNumberIsProvided();

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int)_actionNumber}<CR><LF>";
        }

        public string BuildGetStateOfAllMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.StateOfAllMonitoring);
            
            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType}<CR><LF>";
        }

        public string BuildSetStateOfAllMonitoringCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfMonitoringTypeIsProvided();

            CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType.StateOfAllMonitoring);
            
            CheckIfActionNumberIsProvided();

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _monitoringType},{(int)_actionNumber}<CR><LF>";
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

        private void CheckIfMonitoringTypeIsProvided()
        {
            if (_monitoringType == default(MonitoringType))
            {
                throw new MonitoringTypeNotProvided();
            }
        }

        private void CheckIfProvidedMonitoringTypeIsCorrect(MonitoringType expectedMonitoringType)
        {
            if (_monitoringType != expectedMonitoringType)
            {
                throw new IncorrectMonitoringTypeProvided(_monitoringType,
                    expectedMonitoringType);
            }
        }
        
        private void CheckIfActionNumberIsProvided()
        {
            if (_actionNumber == default(MonitoringCommandActionNumber))
            {
                throw new ActionNumberNotProvided();
            }
        }


        private void CheckIfIntegrationIdIsProvided()
        {
            if (_integrationId == default(int))
            {
                throw new IntegrationIdNotProvided();
            }
        }
    }
}