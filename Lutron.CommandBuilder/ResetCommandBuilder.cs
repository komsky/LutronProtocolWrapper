using Lutron.Common.Enums;
using Lutron.Common.Exceptions;

namespace Lutron.CommandBuilder
{
    public class ResetCommandBuilder
    {
        private CommandOperation _operation;
        private ResetCommandActionNumber _actionNumber;
        private readonly string _command = "RESET";

        public static ResetCommandBuilder Create()
        {
            return new ResetCommandBuilder();
        }

        public ResetCommandBuilder WithOperation(CommandOperation operation)
        {
            _operation = operation;
            return this;
        }

        public ResetCommandBuilder WithAction(ResetCommandActionNumber actionNumber)
        {
            _actionNumber = actionNumber;
            return this;
        }


        public string BuildSetResetCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            return
                $"{(char) _operation}{_command},{(int) _actionNumber}<CR><LF>";
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
    }
}