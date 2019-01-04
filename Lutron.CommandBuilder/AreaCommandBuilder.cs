using Lutron.Common.Enums;
using Lutron.Common.Exceptions;

namespace Lutron.CommandBuilder
{
    public class AreaCommandBuilder
    {
        private CommandOperation _operation;
        private AreaCommandActionNumber _actionNumber;
        private int _integrationId;
        private readonly string _command = "AREA";

        public static AreaCommandBuilder Create()
        {
            return new AreaCommandBuilder();
        }

        public AreaCommandBuilder WithOperation(CommandOperation operation)
        {
            _operation = operation;
            return this;
        }

        public AreaCommandBuilder WithIntegrationId(int integrationId)
        {
            _integrationId = integrationId;
            return this;
        }

        public AreaCommandBuilder WithAction(AreaCommandActionNumber actionNumber)
        {
            _actionNumber = actionNumber;
            return this;
        }
        
        public string BuildGetOccupancyStateCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Get);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            return $"{(char) _operation}{_command},{_integrationId},{(int)_actionNumber}<CR><LF>";
        }

        private void CheckIfCorrectOperationIsProvided(CommandOperation expectedOperation)
        {
            if (_operation != expectedOperation)
            {
                throw new IncorrectOperationProvided(_operation, expectedOperation);
            }
        }

        private void CheckIfOperationIsProvided()
        {
            if (_operation == default(CommandOperation))
            {
                throw new OperationNotProvided();
            }
        }

        private void CheckIfActionNumberIsProvided()
        {
            if (_actionNumber == default(AreaCommandActionNumber))
            {
                throw new ActionNumberNotProvided();
            }
        }


        private void CheckIfIntegrationIdIsProvided()
        {
            if (_integrationId == default(int))
            {
                throw new IntegrationIdNotProvided();
            }
        }
    }
}