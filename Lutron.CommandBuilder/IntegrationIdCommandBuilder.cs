using Lutron.Common.Enums;
using Lutron.Common.Exceptions;
using Lutron.Common.Models;

namespace Lutron.CommandBuilder
{
    public class IntegrationIdCommandBuilder
    {
        private CommandOperation _operation;
        private IntegrationIdCommandActionNumber _actionNumber;
        private int _integrationId;
        private readonly string _command = "INTEGRATIONID";
        private SerialNumber _serialNumber;

        public static IntegrationIdCommandBuilder Create()
        {
            return new IntegrationIdCommandBuilder();
        }

        public IntegrationIdCommandBuilder WithOperation(CommandOperation operation)
        {
            _operation = operation;
            return this;
        }

        public IntegrationIdCommandBuilder WithIntegrationId(int integrationId)
        {
            _integrationId = integrationId;
            return this;
        }

        public IntegrationIdCommandBuilder WithAction(IntegrationIdCommandActionNumber actionNumber)
        {
            _actionNumber = actionNumber;
            return this;
        }


        public IntegrationIdCommandBuilder WithSerialNumber(SerialNumber serialNumber)
        {
            _serialNumber = serialNumber;
            return this;
        }

        public string BuildGetIntegrationIdForSerialNumberCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfActionNumberIsProvided();

            CheckIfSerialNumberIsProvided();

            return $"{(char) _operation}{_command},{(int) _actionNumber},{_serialNumber}<CR><LF>";
        }

        public string BuildGetInfoFromIdCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfActionNumberIsProvided();

            CheckIfIntegrationIdIsProvided();

            return
                $"{(char) _operation}{_command},{(int) _actionNumber},{_integrationId}<CR><LF>";
        }

        private void CheckIfSerialNumberIsProvided()
        {
            if (_serialNumber is null)
            {
                throw new ParameterNotProvided("serial number");
            }
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
            if (_actionNumber == default(IntegrationIdCommandActionNumber))
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