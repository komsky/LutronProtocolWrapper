using Lutron.CommandBuilder;
using Lutron.Common.Enums;
using Lutron.Common.Interfaces;
using Lutron.Common.Models;

namespace Lutron.Service
{
    public class TimeClockService : ITimeClockService
    {
        private readonly IMyRoomPlusConnector _connector;

        public TimeClockService(IMyRoomPlusConnector connector)
        {
            _connector = connector;
        }

        public string GetSunriseTime(int integrationId)
        {
            var commandString = TimeClockCommandBuilder.Create()
                .WithOperation(CommandOperation.Get)
                .WithIntegrationId(integrationId)
                .WithAction(TimeClockCommandActionNumber.SunriseTime)
                .BuildGetSunriseTimeCommand();

            var response = _connector.Query(commandString);

            return GetValue(response);
        }

        public string GetSunsetTime(int integrationId)
        {
            var commandString = TimeClockCommandBuilder.Create()
                .WithOperation(CommandOperation.Get)
                .WithIntegrationId(integrationId)
                .WithAction(TimeClockCommandActionNumber.SunsetTime)
                .BuildGetSunsetTimeCommand();

            var response = _connector.Query(commandString);

            return GetValue(response);
        }

        public string GetDaysSchedule(int integrationId)
        {
            var commandString = TimeClockCommandBuilder.Create()
                .WithOperation(CommandOperation.Get)
                .WithIntegrationId(integrationId)
                .WithAction(TimeClockCommandActionNumber.DaysSchedule)
                .BuildGetDaysScheduleCommand();

            var response = _connector.Query(commandString);

            return GetValue(response);
        }

        public void ExecuteIndexedEvent(int integrationId, EventIndex eventIndex)
        {
            var commandString = TimeClockCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(TimeClockCommandActionNumber.ExecuteIndexedEvent)
                .WithEventIndex(eventIndex)
                .BuildSetExecuteIndexedEventCommand();

            _connector.Execute(commandString);
        }

        public void SetIndexedEventEnableState(int integrationId, EventIndex eventIndex, TimeClockEnableState enableState)
        {
            var commandString = TimeClockCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithIntegrationId(integrationId)
                .WithAction(TimeClockCommandActionNumber.IndexedEventEnableState)
                .WithEventIndex(eventIndex)
                .WithEnableState(enableState)
                .BuildSetIndexedEventEnableStateCommand();

            _connector.Execute(commandString);
        }

        private string GetValue(string response)
        {
            var responseValues = response.Replace("~TIMECLOCK", "")
                .Replace("<CR><LF>", "")
                .Split(',');

            return responseValues[responseValues.Length - 1];
        }
    }
}