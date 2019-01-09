using Lutron.Common.Enums;
using Lutron.Common.Models;

namespace Lutron.Common.Interfaces
{
    public interface ITimeClockService
    {
        string GetSunriseTime(int integrationId);
        string GetSunsetTime(int integrationId);
        string GetDaysSchedule(int integrationId);
        void ExecuteIndexedEvent(int integrationId, EventIndex eventIndex);
        void SetIndexedEventEnableState(int integrationId, EventIndex eventIndex, TimeClockEnableState enableState);
    }
}