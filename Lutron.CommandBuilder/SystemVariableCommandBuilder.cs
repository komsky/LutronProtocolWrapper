using Lutron.Common.Enums;
using Lutron.Common.Exceptions;
using Lutron.Common.Models;

namespace Lutron.CommandBuilder
{
    public class SystemVariableCommandBuilder
    {
        private CommandOperation _operation;
        private SystemVariableCommandActionNumber _actionNumber;
        private int _integrationId;
        private readonly string _command = "SYSVAR";
        private VariableState _variableState;

        public static SystemVariableCommandBuilder Create()
        {
            return new SystemVariableCommandBuilder();
        }

        public SystemVariableCommandBuilder WithOperation(CommandOperation operation)
        {
            _operation = operation;
            return this;
        }

        public SystemVariableCommandBuilder WithIntegrationId(int integrationId)
        {
            _integrationId = integrationId;
            return this;
        }

        public SystemVariableCommandBuilder WithAction(SystemVariableCommandActionNumber actionNumber)
        {
            _actionNumber = actionNumber;
            return this;
        }


        public SystemVariableCommandBuilder WithVariableState(VariableState variableState)
        {
            _variableState = variableState;
            return this;
        }

        public string BuildGetSystemVariableStateCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Get);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            return $"{(char) _operation}{_command},{_integrationId},{(int)_actionNumber}<CR><LF>";
        }

        public string BuildSetSystemVariableStateCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Set);
            
            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfVariableStateParameterIsProvided();

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_variableState}<CR><LF>";
        }

        private void CheckIfVariableStateParameterIsProvided()
        {
            if (_variableState is null)
            {
                throw new ParameterNotProvided("variable state");
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
            if (_actionNumber == default(SystemVariableCommandActionNumber))
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