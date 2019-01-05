using Lutron.CommandBuilder;
using Lutron.Common.Enums;
using Lutron.Common.Interfaces;

namespace Lutron.Service
{
    public class MyRoomPlusService
    {
        private readonly IMyRoomPlusConnector _connector;

        public MyRoomPlusService(IMyRoomPlusConnector connector)
        {
            _connector = connector;
        }
        public OutputLevelResponse GetOutputLevel(int integrationId)
        {
            var commandString = OutputCommandBuilder.Create()
                .WithOperation(CommandOperation.Get)
                .WithIntegrationId(integrationId)
                .WithAction(OutputCommandActionNumber.OutputLevel)
                .BuildGetOutputLevelCommand();

            var response = _connector.Query(commandString);
            var outputLevel = ExtractOutputLevel(response);

            return new OutputLevelResponse
            {
                Level = outputLevel
            };
        }

        private double ExtractOutputLevel(string response)
        {
            var responseValues = response.Replace("~OUTPUT", "")
                .Replace("<CR><LF>", "")
                .Split(',');

            var outputLevel = double.Parse(responseValues[responseValues.Length - 1]);
            return outputLevel;
        }
    }
}