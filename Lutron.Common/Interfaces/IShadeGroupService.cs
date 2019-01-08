using Lutron.Common.Enums;
using Lutron.Common.Models;

namespace Lutron.Common.Interfaces
{
    public interface IShadeGroupService
    {
        double GetShadeGroupLevel(int integrationId);
        void SetShadeGroupLevel(int integrationId, double shadeGroupLevel, Fade fade = null, Delay delay = null);
        void StartRaisingShadeGroupLevel(int integrationId);
        void StartLoweringShadeGroupLevel(int integrationId);
        void StopRaisingOrLoweringShadeGroupLevel(int integrationId);
        void SetCurrentPreset(int integrationId, PresetNumber presetNumber);
        double GetCurrentPreset(int integrationId);
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