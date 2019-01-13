using Lutron.CommandBuilder;
using Lutron.Common.Enums;
using Lutron.Common.Interfaces;
using Lutron.Common.Models;
using Lutron.Connector;

namespace Lutron.Service
{
    public class OutputService : IOutputService
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

        public void StartLoweringOutputLevel(int integrationId)
        {
            var commandString = OutputCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(OutputCommandActionNumber.StartLoweringOutputLevel)
                .BuildStartLoweringOutputLevelCommand();

            _connector.Execute(commandString);
        }

        public void StopRaisingOrLoweringOutputLevel(int integrationId)
        {
            var commandString = OutputCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(OutputCommandActionNumber.StopRaisingOrLoweringOutputLevel)
                .BuildStopRaisingOrLoweringOutputLevelCommand();

            _connector.Execute(commandString);
        }

        public void SetFlashFrequency(int integrationId, Fade fade = null, Delay delay = null)
        {
            var commandString = OutputCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(OutputCommandActionNumber.FlashFrequency)
                .WithFade(fade)
                .WithDelay(delay)
                .BuildSetFlashFrequencyCommand();

            _connector.Execute(commandString);
        }

        public double GetFlashFrequency(int integrationId)
        {
            var commandString = OutputCommandBuilder.Create()
                .WithOperation(CommandOperation.Get)
                .WithIntegrationId(integrationId)
                .WithAction(OutputCommandActionNumber.FlashFrequency)
                .BuildGetFlashFrequencyCommand();

            var response = _connector.Query(commandString);
            return ExtractFlashFrequency(response);
        }

        public void SetContactClosureOutputPulseTime(int integrationId, Pulse pulse = null, Delay delay = null)
        {
            var commandString = OutputCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(OutputCommandActionNumber.ContactClosureOutputPulseTime)
                .WithPulse(pulse)
                .WithDelay(delay)
                .BuildSetContactClosureOutputPulseTimeCommand();

            _connector.Execute(commandString);
        }

        public void SetTiltLevel(int integrationId, TiltLevel tiltLevel, Fade fade = null, Delay delay = null)
        {
            var commandString = OutputCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(OutputCommandActionNumber.TiltLevel)
                .WithTiltLevel(tiltLevel)
                .WithFade(fade)
                .WithDelay(delay)
                .BuildSetTiltLevelCommand();

            _connector.Execute(commandString);
        }

        public void SetLiftAndTiltLevels(int integrationId, LiftLevel liftLevel, TiltLevel tiltLevel, Fade fade = null,
            Delay delay = null)
        {
            var commandString = OutputCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(OutputCommandActionNumber.LiftAndTiltLevels)
                .WithLiftLevel(liftLevel)
                .WithTiltLevel(tiltLevel)
                .WithFade(fade)
                .WithDelay(delay)
                .BuildSetLiftAndTiltLevelsCommand();

            _connector.Execute(commandString);
        }

        public void StartRaisingTilt(int integrationId)
        {
            var commandString = OutputCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(OutputCommandActionNumber.StartRaisingTilt)
                .BuildStartRaisingTiltCommand();

            _connector.Execute(commandString);
        }

        public void StartLoweringTilt(int integrationId)
        {
            var commandString = OutputCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(OutputCommandActionNumber.StartLoweringTilt)
                .BuildStartLoweringTiltCommand();

            _connector.Execute(commandString);
        }

        public void StopRaisingOrLoweringTilt(int integrationId)
        {
            var commandString = OutputCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(OutputCommandActionNumber.StopRaisingOrLoweringTilt)
                .BuildStopRaisingOrLoweringTiltCommand();

            _connector.Execute(commandString);
        }

        public void StartRaisingLift(int integrationId)
        {
            var commandString = OutputCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(OutputCommandActionNumber.StartRaisingLift)
                .BuildStartRaisingLiftCommand();

            _connector.Execute(commandString);
        }

        public void StartLoweringLift(int integrationId)
        {
            var commandString = OutputCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(OutputCommandActionNumber.StartLoweringLift)
                .BuildStartLoweringLiftCommand();

            _connector.Execute(commandString);
        }

        public void StopRaisingOrLoweringLift(int integrationId)
        {
            var commandString = OutputCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(OutputCommandActionNumber.StopRaisingOrLoweringLift)
                .BuildStopRaisingOrLoweringLiftCommand();

            _connector.Execute(commandString);
        }

        public double GetHorizontalSheerShadeRegion(int integrationId, HorizontalSheerShadeRegion region)
        {
            var commandString = OutputCommandBuilder.Create()
                .WithOperation(CommandOperation.Get)
                .WithIntegrationId(integrationId)
                .WithAction(OutputCommandActionNumber.HorizontalSheerShadeRegion)
                .WithHorizontalSheerShadeRegion(region)
                .BuildGetHorizontalSheerShadeRegionCommand();

            var response = _connector.Query(commandString);
            return ExtractHorizontalSheerRegionLevel(response);
        }

        private double ExtractOutputLevel(string response)
        {
            var responseValues = response.Replace("~OUTPUT", "")
                .Replace("<CR><LF>", "")
                .Split(',');

            var outputLevel = double.Parse(responseValues[responseValues.Length - 1]);
            return outputLevel;
        }


        private double ExtractFlashFrequency(string response)
        {
            var responseValues = response.Replace("~OUTPUT", "")
                .Replace("<CR><LF>", "")
                .Split(',');

            var outputLevel = double.Parse(responseValues[responseValues.Length - 1]);
            return outputLevel;
        }
        
        private double ExtractHorizontalSheerRegionLevel(string response)
        {
            var responseValues = response.Replace("~OUTPUT", "")
                .Replace("<CR><LF>", "")
                .Split(',');

            var outputLevel = double.Parse(responseValues[responseValues.Length - 1]);
            return outputLevel;
        }
    }
}