using Lutron.CommandBuilder;
using Lutron.Common.Enums;
using Lutron.Common.Interfaces;
using Lutron.Common.Models;

namespace Lutron.Service
{
    public class IntegrationIdService : IIntegrationIdService
    {
        private readonly IMyRoomPlusConnector _connector;

        public IntegrationIdService(IMyRoomPlusConnector connector)
        {
            _connector = connector;
        }

        public int GetIntegrationId(string serialNumber)
        {
            var commandString = IntegrationIdCommandBuilder.Create()
                .WithOperation(CommandOperation.Get)
                .WithAction(IntegrationIdCommandActionNumber.IntegrationIdForSerialNumber)
                .WithSerialNumber(new SerialNumber(serialNumber))
                .BuildGetIntegrationIdForSerialNumberCommand();

            var response = _connector.Query(commandString);

            return GetValue(response);
        }


        public string GetInfoFromId(int integrationId)
        {
            var commandString = IntegrationIdCommandBuilder.Create()
                .WithOperation(CommandOperation.Get)
                .WithIntegrationId(integrationId)
                .WithAction(IntegrationIdCommandActionNumber.InfoFromIntegrationId)
                .BuildGetInfoFromIdCommand();

            var response = _connector.Query(commandString);

            return GetStringValue(response);
        }

        private int GetValue(string response)
        {
            var responseValues = response.Replace("~INTEGRATIONID", "")
                .Replace("<CR><LF>", "")
                .Split(',');

            return int.Parse(responseValues[responseValues.Length - 1]);
        }


        private string GetStringValue(string response)
        {
            var responseValues = response.Replace("~INTEGRATIONID", "")
                .Replace("<CR><LF>", "")
                .Split(',');

            return responseValues[responseValues.Length - 1];
        }
    }
}