using Lutron.Common.Enums;
using Lutron.Common.Exceptions;
using Lutron.Common.Models;

namespace Lutron.CommandBuilder
{
    public class EthernetCommandBuilder
    {
        private CommandOperation _operation;
        private EthernetCommandConfigurationNumber _actionNumber;
        private IpAddress _ipAddress;
        private readonly string _command = "ETHERNET";
        private IpAddress _multicastAddress;
        private IpAddress _gatewayAddress;
        private IpAddress _subnetMask;

        public static EthernetCommandBuilder Create()
        {
            return new EthernetCommandBuilder();
        }

        public EthernetCommandBuilder WithOperation(CommandOperation operation)
        {
            _operation = operation;
            return this;
        }

        public EthernetCommandBuilder WithAction(EthernetCommandConfigurationNumber actionNumber)
        {
            _actionNumber = actionNumber;
            return this;
        }

        public EthernetCommandBuilder WithIpAddress(IpAddress ipAddress)
        {
            _ipAddress = ipAddress;
            return this;
        }

        public EthernetCommandBuilder WithMulticastAddress(IpAddress multicastAddress)
        {
            _multicastAddress = multicastAddress;
            return this;
        }

        public EthernetCommandBuilder WithGatewayAddress(IpAddress gatewayAddress)
        {
            _gatewayAddress = gatewayAddress;
            return this;
        }

        public EthernetCommandBuilder WithSubnetMask(IpAddress subnetMask)
        {
            _subnetMask = subnetMask;
            return this;
        }

        public string BuildSetIpAddressCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Set);
            
            CheckIfProvidedActionNumberIsCorrect(EthernetCommandConfigurationNumber.IpAddress);

            CheckIfIpAddressParameterIsProvided();

            return
                $"{(char) _operation}{_command},{(int) _actionNumber},{_ipAddress}<CR><LF>";
        }

        public string BuildGetIpAddressCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Get);
            
            CheckIfProvidedActionNumberIsCorrect(EthernetCommandConfigurationNumber.IpAddress);

            return $"{(char) _operation}{_command},{(int)_actionNumber}<CR><LF>";
        }

        public string BuildSetGatewayAddressCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Set);
            
            CheckIfProvidedActionNumberIsCorrect(EthernetCommandConfigurationNumber.GatewayAddress);
            
            CheckIfGatewayAddressParameterIsProvided();

            return $"{(char) _operation}{_command},{(int) _actionNumber},{_gatewayAddress}<CR><LF>";
        }

        public string BuildGetGatewayAddressCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Get);
            
            CheckIfProvidedActionNumberIsCorrect(EthernetCommandConfigurationNumber.GatewayAddress);

            return $"{(char) _operation}{_command},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildSetSubnetMaskCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Set);
            
            CheckIfProvidedActionNumberIsCorrect(EthernetCommandConfigurationNumber.SubnetMask);
            
            CheckIfSubnetMaskParameterIsProvided();
            
            return $"{(char) _operation}{_command},{(int) _actionNumber},{_subnetMask}<CR><LF>";
        }

        public string BuildGetSubnetMaskCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Get);
            
            CheckIfProvidedActionNumberIsCorrect(EthernetCommandConfigurationNumber.SubnetMask);

            return $"{(char) _operation}{_command},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildGetDhcpCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Get);
            
            CheckIfProvidedActionNumberIsCorrect(EthernetCommandConfigurationNumber.Dhcp);
            
            return $"{(char) _operation}{_command},{(int) _actionNumber}<CR><LF>";
        }

        public string BuildSetMulticastAddressCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Set);
            
            CheckIfProvidedActionNumberIsCorrect(EthernetCommandConfigurationNumber.MulticastAddress);
            
            CheckIfMulticastAddressParameterIsProvided();

            return $"{(char) _operation}{_command},{(int) _actionNumber},{_multicastAddress}<CR><LF>";
        }

        public string BuildGetMulticastAddressCommand()
        {
            CheckIfOperationIsProvided();
            
            CheckIfCorrectOperationIsProvided(CommandOperation.Get);
            
            CheckIfProvidedActionNumberIsCorrect(EthernetCommandConfigurationNumber.MulticastAddress);
            
            return $"{(char) _operation}{_command},{(int) _actionNumber}<CR><LF>";
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


        private void CheckIfIpAddressParameterIsProvided()
        {
            if (_ipAddress is null)
            {
                throw new ParameterNotProvided("ip address");
            }
        }

        private void CheckIfGatewayAddressParameterIsProvided()
        {
            if (_gatewayAddress is null)
            {
                throw new ParameterNotProvided("gateway address");
            }
        }

        private void CheckIfSubnetMaskParameterIsProvided()
        {
            if (_subnetMask is null)
            {
                throw new ParameterNotProvided("subnet mask");
            }
        }

        private void CheckIfMulticastAddressParameterIsProvided()
        {
            if (_multicastAddress is null)
            {
                throw new ParameterNotProvided("multicast address");
            }
        }

        private void CheckIfProvidedActionNumberIsCorrect(EthernetCommandConfigurationNumber expectedActionNumber)
        {
            if (_actionNumber != expectedActionNumber)
            {
                throw new IncorrectActionNumberProvided(_actionNumber,
                    expectedActionNumber);
            }
        }

    }
}