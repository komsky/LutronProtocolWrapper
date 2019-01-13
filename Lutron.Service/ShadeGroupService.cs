using Lutron.CommandBuilder;
using Lutron.Common.Enums;
using Lutron.Common.Interfaces;
using Lutron.Common.Models;
using Lutron.Connector;

namespace Lutron.Service
{
    public class ShadeGroupService : IShadeGroupService
    {
        private readonly IMyRoomPlusConnector _connector;

        public ShadeGroupService(IMyRoomPlusConnector connector)
        {
            _connector = connector;
        }

        public double GetShadeGroupLevel(int integrationId)
        {
            var commandString = ShadeGroupCommandBuilder.Create()
                .WithOperation(CommandOperation.Get)
                .WithIntegrationId(integrationId)
                .WithAction(ShadeGroupCommandActionNumber.ShadeGroupLevel)
                .BuildGetShadeGroupLevelCommand();

            var response = _connector.Query(commandString);

            return ExtractShadeGroupLevel(response);
        }

        public void SetShadeGroupLevel(int integrationId, double shadeGroupLevel, Fade fade = null, Delay delay = null)
        {
            var commandString = ShadeGroupCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(ShadeGroupCommandActionNumber.ShadeGroupLevel)
                .WithLevel(new ShadeGroupLevel(shadeGroupLevel))
                .WithFade(fade)
                .WithDelay(delay)
                .BuildSetShadeGroupLevelCommand();

            _connector.Execute(commandString);
        }

        public void StartRaisingShadeGroupLevel(int integrationId)
        {
            var commandString = ShadeGroupCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(ShadeGroupCommandActionNumber.StartRaisingShadeGroupLevel)
                .BuildStartRaisingShadeGroupLevelCommand();

            _connector.Execute(commandString);
        }

        public void StartLoweringShadeGroupLevel(int integrationId)
        {
            var commandString = ShadeGroupCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(ShadeGroupCommandActionNumber.StartLoweringShadeGroupLevel)
                .BuildStartLoweringShadeGroupLevelCommand();

            _connector.Execute(commandString);
        }

        public void StopRaisingOrLoweringShadeGroupLevel(int integrationId)
        {
            var commandString = ShadeGroupCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(ShadeGroupCommandActionNumber.StopRaisingOrLoweringShadeGroupLevel)
                .BuildStopRaisingOrLoweringShadeGroupLevelCommand();

            _connector.Execute(commandString);
        }

        public void SetCurrentPreset(int integrationId, PresetNumber presetNumber)
        {
            var commandString = ShadeGroupCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(ShadeGroupCommandActionNumber.CurrentPreset)
                .WithPresetNumber(presetNumber)
                .BuildSetCurrentPresetCommand();

            _connector.Execute(commandString);
        }

        public double GetCurrentPreset(int integrationId)
        {
            var commandString = ShadeGroupCommandBuilder.Create()
                .WithOperation(CommandOperation.Get)
                .WithIntegrationId(integrationId)
                .WithAction(ShadeGroupCommandActionNumber.CurrentPreset)
                .BuildGetCurrentPresetCommand();

            var response = _connector.Query(commandString);
            return ExtractCurrentPreset(response);
        }

        public void SetTiltLevel(int integrationId, TiltLevel tiltLevel, Fade fade = null, Delay delay = null)
        {
            var commandString = ShadeGroupCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(ShadeGroupCommandActionNumber.TiltLevel)
                .WithTiltLevel(tiltLevel)
                .WithFade(fade)
                .WithDelay(delay)
                .BuildSetTiltLevelCommand();

            _connector.Execute(commandString);
        }

        public void SetLiftAndTiltLevels(int integrationId, LiftLevel liftLevel, TiltLevel tiltLevel, Fade fade = null,
            Delay delay = null)
        {
            var commandString = ShadeGroupCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(ShadeGroupCommandActionNumber.LiftAndTiltLevels)
                .WithLiftLevel(liftLevel)
                .WithTiltLevel(tiltLevel)
                .WithFade(fade)
                .WithDelay(delay)
                .BuildSetLiftAndTiltLevelsCommand();

            _connector.Execute(commandString);
        }

        public void StartRaisingTilt(int integrationId)
        {
            var commandString = ShadeGroupCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(ShadeGroupCommandActionNumber.StartRaisingTilt)
                .BuildStartRaisingTiltCommand();

            _connector.Execute(commandString);
        }

        public void StartLoweringTilt(int integrationId)
        {
            var commandString = ShadeGroupCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(ShadeGroupCommandActionNumber.StartLoweringTilt)
                .BuildStartLoweringTiltCommand();

            _connector.Execute(commandString);
        }

        public void StopRaisingOrLoweringTilt(int integrationId)
        {
            var commandString = ShadeGroupCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(ShadeGroupCommandActionNumber.StopRaisingOrLoweringTilt)
                .BuildStopRaisingOrLoweringTiltCommand();

            _connector.Execute(commandString);
        }

        public void StartRaisingLift(int integrationId)
        {
            var commandString = ShadeGroupCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(ShadeGroupCommandActionNumber.StartRaisingLift)
                .BuildStartRaisingLiftCommand();

            _connector.Execute(commandString);
        }

        public void StartLoweringLift(int integrationId)
        {
            var commandString = ShadeGroupCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(ShadeGroupCommandActionNumber.StartLoweringLift)
                .BuildStartLoweringLiftCommand();

            _connector.Execute(commandString);
        }

        public void StopRaisingOrLoweringLift(int integrationId)
        {
            var commandString = ShadeGroupCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(ShadeGroupCommandActionNumber.StopRaisingOrLoweringLift)
                .BuildStopRaisingOrLoweringLiftCommand();

            _connector.Execute(commandString);
        }

        public double GetHorizontalSheerShadeRegion(int integrationId, HorizontalSheerShadeRegion region)
        {
            var commandString = ShadeGroupCommandBuilder.Create()
                .WithOperation(CommandOperation.Get)
                .WithIntegrationId(integrationId)
                .WithAction(ShadeGroupCommandActionNumber.HorizontalSheerShadeRegion)
                .WithHorizontalSheerShadeRegion(region)
                .BuildGetHorizontalSheerShadeRegionCommand();

            var response = _connector.Query(commandString);
            return ExtractHorizontalSheerRegionLevel(response);
        }

        private double ExtractShadeGroupLevel(string response)
        {
            var responseValues = response.Replace("~SHADEGRP", "")
                .Replace("<CR><LF>", "")
                .Split(',');

            var outputLevel = double.Parse(responseValues[responseValues.Length - 1]);
            return outputLevel;
        }


        private double ExtractCurrentPreset(string response)
        {
            var responseValues = response.Replace("~SHADEGRP", "")
                .Replace("<CR><LF>", "")
                .Split(',');

            var outputLevel = double.Parse(responseValues[responseValues.Length - 1]);
            return outputLevel;
        }
        
        private double ExtractHorizontalSheerRegionLevel(string response)
        {
            var responseValues = response.Replace("~SHADEGRP", "")
                .Replace("<CR><LF>", "")
                .Split(',');

            var outputLevel = double.Parse(responseValues[responseValues.Length - 1]);
            return outputLevel;
        }
    }
}