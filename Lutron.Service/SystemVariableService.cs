using Lutron.CommandBuilder;
using Lutron.Common.Enums;
using Lutron.Common.Interfaces;
using Lutron.Common.Models;
using Lutron.Connector;

namespace Lutron.Service
{
    public class SystemVariableService : ISystemVariableService
    {
        private readonly IMyRoomPlusConnector _connector;

        public SystemVariableService(IMyRoomPlusConnector connector)
        {
            _connector = connector;
        }

        public string GetSystemVariable(int integrationId)
        {
            var commandString = SystemVariableCommandBuilder.Create()
                .WithOperation(CommandOperation.Get)
                .WithIntegrationId(integrationId)
                .WithAction(SystemVariableCommandActionNumber.VariableState)
                .BuildGetSystemVariableStateCommand();

            var response = _connector.Query(commandString);

            return GetValue(response);
        }

        public void SetSystemVariable(int integrationId, VariableState variableState)
        {
            var commandString = SystemVariableCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(SystemVariableCommandActionNumber.VariableState)
                .WithVariableState(variableState)
                .BuildSetSystemVariableStateCommand();

            _connector.Execute(commandString);
        }

        private string GetValue(string response)
        {
            var responseValues = response.Replace("~SYSVAR", "")
                .Replace("<CR><LF>", "")
                .Split(',');

            return responseValues[responseValues.Length - 1];
        }
    }
}