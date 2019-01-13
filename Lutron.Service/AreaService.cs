using Lutron.CommandBuilder;
using Lutron.Common.Enums;
using Lutron.Common.Interfaces;
using Lutron.Connector;

namespace Lutron.Service
{
    public class AreaService : IAreaService
    {
        private readonly IMyRoomPlusConnector _connector;

        public AreaService(IMyRoomPlusConnector connector)
        {
            _connector = connector;
        }

        public string GetOccupancyState(int integrationId)
        {
            var commandString = AreaCommandBuilder.Create()
                .WithOperation(CommandOperation.Get)
                .WithIntegrationId(integrationId)
                .WithAction(AreaCommandActionNumber.OccupancyState)
                .BuildGetOccupancyStateCommand();

            var response = _connector.Query(commandString);

            return GetValue(response);
        }

        private string GetValue(string response)
        {
            var responseValues = response.Replace("~AREA", "")
                .Replace("<CR><LF>", "")
                .Split(',');

            return responseValues[responseValues.Length - 1];
        }
    }
}