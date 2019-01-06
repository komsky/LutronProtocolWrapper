using Lutron.CommandBuilder;
using Lutron.Common.Enums;
using Lutron.Common.Interfaces;
using Lutron.Common.Models;

namespace Lutron.Service
{
    public class OutputService
    {
        private readonly IMyRoomPlusConnector _connector;

        public OutputService(IMyRoomPlusConnector connector)
        {
            _connector = connector;
        }

        public double GetOutputLevel(int integrationId)
        {
            var commandString = OutputCommandBuilder.Create()
                .WithOperation(CommandOperation.Get)
                .WithIntegrationId(integrationId)
                .WithAction(OutputCommandActionNumber.OutputLevel)
                .BuildGetOutputLevelCommand();

            var response = _connector.Query(commandString);

            return ExtractOutputLevel(response);
        }

        private double ExtractOutputLevel(string response)
        {
            var responseValues = response.Replace("~OUTPUT", "")
                .Replace("<CR><LF>", "")
                .Split(',');

            var outputLevel = double.Parse(responseValues[responseValues.Length - 1]);
            return outputLevel;
        }

        public void SetOutputLevel(int integrationId, double outputLevel, Fade fade = null, Delay delay = null)
        {
            var commandString = OutputCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(OutputCommandActionNumber.OutputLevel)
                .WithOutputLevel(new OutputLevel(outputLevel))
                .WithFade(fade)
                .WithDelay(delay)
                .BuildSetOutputLevelCommand();

            _connector.Execute(commandString);
        }

        public void StartRaisingOutputLevel(int integrationId)
        {
            var commandString = OutputCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(OutputCommandActionNumber.StartRaisingOutputLevel)
                .BuildStartRaisingOutputLevelCommand();

            _connector.Execute(commandString);
        }
    }
}