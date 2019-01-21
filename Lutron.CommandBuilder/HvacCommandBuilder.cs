using Lutron.Common.Enums;
using Lutron.Common.Exceptions;
using Lutron.Common.Models;

namespace Lutron.CommandBuilder
{
    public class HvacCommandBuilder
    {
        private CommandOperation _operation;
        private HvacCommandActionNumber _actionNumber;
        private int _integrationId;
        private readonly string _command = "HVAC";
        private Temperature _temperature;
        private SetPointHeat _setPointHeat;
        private SetPointCool _setPointCool;

        public static HvacCommandBuilder Create()
        {
            return new HvacCommandBuilder();
        }

        public HvacCommandBuilder WithOperation(CommandOperation operation)
        {
            _operation = operation;
            return this;
        }

        public HvacCommandBuilder WithIntegrationId(int integrationId)
        {
            _integrationId = integrationId;
            return this;
        }

        public HvacCommandBuilder WithAction(HvacCommandActionNumber actionNumber)
        {
            _actionNumber = actionNumber;
            return this;
        }


        public HvacCommandBuilder WithTemperature(Temperature temperature)
        {
            _temperature = temperature;
            return this;
        }

        public HvacCommandBuilder WithSetPointHeat(SetPointHeat setPointHeat)
        {
            _setPointHeat = setPointHeat;
            return this;
        }

        public HvacCommandBuilder WithSetPointCool(SetPointCool setPointCool)
        {
            _setPointCool = setPointCool;
            return this;
        }

        public string BuildGetCurrentTemperatureCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();
            
            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.CurrentTemperature);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildSetCurrentTemperatureCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.CurrentTemperature);

            CheckIfParameterIsProvided(_temperature, "temperature");

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_temperature}<CR><LF>";
        }

        public string BuildGetHeatAndCoolSetPointsCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Get);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();
            
            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.HeatAndCoolSetPoints);

            return $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildSetHeatAndCoolSetPointsCommand()
        {
            CheckIfOperationIsProvided();

            CheckIfCorrectOperationIsProvided(CommandOperation.Set);

            CheckIfIntegrationIdIsProvided();

            CheckIfActionNumberIsProvided();

            CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber.HeatAndCoolSetPoints);

            CheckIfParameterIsProvided(_setPointHeat, "set point heat");
            
            CheckIfParameterIsProvided(_setPointCool, "set point cool");

            return
                $"{(char) _operation}{_command},{_integrationId},{(int) _actionNumber},{_setPointHeat},{_setPointCool}<CR><LF>";
        }

        private void CheckIfParameterIsProvided(object temperature, string parameterName)
        {
            if (temperature is null)
            {
                throw new ParameterNotProvided(parameterName);
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
            if (_actionNumber == default(HvacCommandActionNumber))
            {
                throw new ActionNumberNotProvided();
            }
        }

        private void CheckIfProvidedActionNumberIsCorrect(HvacCommandActionNumber expectedActionNumber)
        {
            if (_actionNumber != expectedActionNumber)
            {
                throw new IncorrectActionNumberProvided(_actionNumber,
                    expectedActionNumber);
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