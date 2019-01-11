using Lutron.CommandBuilder;
using Lutron.Common.Enums;
using Lutron.Common.Interfaces;
using Lutron.Common.Models;

namespace Lutron.Service
{
    public class EthernetService : IEthernetService
    {
        private readonly IMyRoomPlusConnector _connector;

        public EthernetService(IMyRoomPlusConnector connector)
        {
            _connector = connector;
        }

        public string GetIpAddress()
        {
            var commandString = EthernetCommandBuilder.Create()
                .WithOperation(CommandOperation.Get)
                .WithAction(EthernetCommandConfigurationNumber.IpAddress)
                .BuildGetIpAddressCommand();

            var response = _connector.Query(commandString);

            return GetValue(response);
        }

        public void SetIpAddress(string ipAddress)
        {
            var commandString = EthernetCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithAction(EthernetCommandConfigurationNumber.IpAddress)
                .WithIpAddress(new IpAddress(ipAddress))
                .BuildSetIpAddressCommand();

            _connector.Execute(commandString);
        }

        public string GetGatewayAddress()
        {
            var commandString = EthernetCommandBuilder.Create()
                .WithOperation(CommandOperation.Get)
                .WithAction(EthernetCommandConfigurationNumber.GatewayAddress)
                .BuildGetGatewayAddressCommand();

            var response = _connector.Query(commandString);

            return GetValue(response);        }

        public void SetGatewayAddress(string gatewayAddress)
        {
            var commandString = EthernetCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithAction(EthernetCommandConfigurationNumber.GatewayAddress)
                .WithGatewayAddress(new IpAddress(gatewayAddress))
                .BuildSetGatewayAddressCommand();

            _connector.Execute(commandString);
        }

        public string GetSubnetMask()
        {
            var commandString = EthernetCommandBuilder.Create()
                .WithOperation(CommandOperation.Get)
                .WithAction(EthernetCommandConfigurationNumber.SubnetMask)
                .BuildGetSubnetMaskCommand();

            var response = _connector.Query(commandString);

            return GetValue(response);        }

        public void SetSubnetMask(string subnetMask)
        {
            var commandString = EthernetCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithAction(EthernetCommandConfigurationNumber.SubnetMask)
                .WithSubnetMask(new IpAddress(subnetMask))
                .BuildSetSubnetMaskCommand();

            _connector.Execute(commandString);
        }

        public string GetDhcp()
        {
            var commandString = EthernetCommandBuilder.Create()
                .WithOperation(CommandOperation.Get)
                .WithAction(EthernetCommandConfigurationNumber.Dhcp)
                .BuildGetDhcpCommand();

            var response = _connector.Query(commandString);

            return GetValue(response);        }

        public string GetMulticastAddress()
        {
            var commandString = EthernetCommandBuilder.Create()
                .WithOperation(CommandOperation.Get)
                .WithAction(EthernetCommandConfigurationNumber.MulticastAddress)
                .BuildGetMulticastAddressCommand();

            var response = _connector.Query(commandString);

            return GetValue(response);        }

        public void SetMulticastAddress(string multicastAddress)
        {
            var commandString = EthernetCommandBuilder.Create()
                .WithOperation(CommandOperation.Set)
                .WithAction(EthernetCommandConfigurationNumber.MulticastAddress)
                .WithMulticastAddress(new IpAddress(multicastAddress))
                .BuildSetMulticastAddressCommand();

            _connector.Execute(commandString);
        }


        private string GetValue(string response)
        {
            var responseValues = response.Replace("~ETHERNET", "")
                .Replace("<CR><LF>", "")
                .Split(',');

            return responseValues[responseValues.Length - 1];
        }
    }
}