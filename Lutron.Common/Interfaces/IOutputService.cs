using Lutron.Common.Enums;
using Lutron.Common.Models;

namespace Lutron.Common.Interfaces
{
    public interface IOutputService
    {
        double GetOutputLevel(int integrationId);
        void SetOutputLevel(int integrationId, double outputLevel, Fade fade = null, Delay delay = null);
        void StartRaisingOutputLevel(int integrationId);
        void StartLoweringOutputLevel(int integrationId);
        void StopRaisingOrLoweringOutputLevel(int integrationId);
        void SetFlashFrequency(int integrationId, Fade fade = null, Delay delay = null);
        double GetFlashFrequency(int integrationId);
        void SetContactClosureOutputPulseTime(int integrationId, Pulse pulse = null, Delay delay = null);
        void SetTiltLevel(int integrationId, TiltLevel tiltLevel, Fade fade = null, Delay delay = null);

        void SetLiftAndTiltLevels(int integrationId, LiftLevel liftLevel, TiltLevel tiltLevel, Fade fade = null,
            Delay delay = null);

        void StartRaisingTilt(int integrationId);
        void StartLoweringTilt(int integrationId);
        void StopRaisingOrLoweringTilt(int integrationId);
        void StartRaisingLift(int integrationId);
        void StartLoweringLift(int integrationId);
        void StopRaisingOrLoweringLift(int integrationId);
        double GetHorizontalSheerShadeRegion(int integrationId, HorizontalSheerShadeRegion region);
    }
}