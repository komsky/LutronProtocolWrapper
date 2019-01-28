namespace Lutron.Common.Enums
{
    public enum HvacCallStatus
    {
        NoneLastWasHeat = 0,
        HeatStageOne = 1,
        HeatStageOneAndTwo = 2,
        HeatStageOneTwoAndThree = 3,
        HeatStageThree = 4,
        NoneLastWasCool = 5,
        CoolStageOne = 6,
        CoolStageOneAndTwo = 7,
        Off = 8,
        EmergencyHeat = 9,
        Dry = 10,
    }
}