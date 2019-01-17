using Lutron.Common.Enums;
using Lutron.Common.Exceptions;

namespace Lutron.CommandBuilder
{
    public class DeviceCommandBuilder
    {
        private CommandOperation _operation;
        private DeviceCommandActionNumber _actionNumber;
        private int _integrationId;
        private readonly string _command = "DEVICE";
        private int _componentNumber;

        public static DeviceCommandBuilder Create()
        {
            return new DeviceCommandBuilder();
        }

        public DeviceCommandBuilder WithOperation(CommandOperation operation)
        {
            _operation = operation;
            return this;
        }

        public DeviceCommandBuilder WithIntegrationId(int integrationId)
        {
            _integrationId = integrationId;
            return this;
        }

        public DeviceCommandBuilder WithComponent(int componentNumber)
        {
            _componentNumber = componentNumber;
            return this;
        }

        public DeviceCommandBuilder WithAction(DeviceCommandActionNumber actionNumber)
        {
            _actionNumber = actionNumber;
            return this;
        }

        public string BuildPressCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();
            
            CheckIfComponentNumberIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(DeviceCommandActionNumber.Press);

            return
                $"{(char) _operation}{_command},{_integrationId},{_componentNumber},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildReleaseCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();
            
            CheckIfComponentNumberIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(DeviceCommandActionNumber.Release);

            return
                $"{(char) _operation}{_command},{_integrationId},{_componentNumber},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildDoubleTapCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();
            
            CheckIfComponentNumberIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(DeviceCommandActionNumber.DoubleTap);

            return
                $"{(char) _operation}{_command},{_integrationId},{_componentNumber},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildHoldCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();
            
            CheckIfComponentNumberIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(DeviceCommandActionNumber.Hold);

            return
                $"{(char) _operation}{_command},{_integrationId},{_componentNumber},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildHoldReleaseCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();
            
            CheckIfComponentNumberIsProvided();
            
            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(DeviceCommandActionNumber.HoldRelease);

            return
                $"{(char) _operation}{_command},{_integrationId},{_componentNumber},{(int) _actionNumber}<CR><LF>";
        }

        private void CheckIfOperationIsProvided()
        {
            if (_operation == default(CommandOperation))
            {
                throw new OperationNotProvided();
            }
        }

        private void CheckIfCorrectOperationIsProvided(CommandOperation expectedOperation)
        {
            if (_operation != expectedOperation)
            {
                throw new IncorrectOperationProvided(_operation, expectedOperation);
            }
        }

        private void CheckIfIntegrationIdIsProvided()
        {
            if (_integrationId == default(int))
            {
                throw new IntegrationIdNotProvided();
            }
        }

        private void CheckIfComponentNumberIsProvided()
        {
            if (_componentNumber == default(int))
            {
                throw new ComponentNumberNotProvided();
            }
        }

        private void CheckIfActionNumberIsProvided()
        {
            if (_actionNumber == default(DeviceCommandActionNumber))
            {
                throw new ActionNumberNotProvided();
            }
        }

        private void CheckIfProvidedActionNumberIsCorrect(DeviceCommandActionNumber expectedActionNumber)
        {
            if (_actionNumber != expectedActionNumber)
            {
                throw new IncorrectActionNumberProvided(_actionNumber,
                    expectedActionNumber);
            }
        }
    }
}