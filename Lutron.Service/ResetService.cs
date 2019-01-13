using Lutron.CommandBuilder;
using Lutron.Common.Enums;
using Lutron.Common.Interfaces;
using Lutron.Connector;

namespace Lutron.Service
{
    public class ResetService : IResetService
    {
        private readonly IMyRoomPlusConnector _connector;

        public ResetService(IMyRoomPlusConnector connector)
        {
            _connector = connector;
        }

        public void Reset()
        {
            var commandString = ResetCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithAction(ResetCommandActionNumber.Reset)
                .BuildSetResetCommand();

             _connector.Execute(commandString);
        }
    }
}