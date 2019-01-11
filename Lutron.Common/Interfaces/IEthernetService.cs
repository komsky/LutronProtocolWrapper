namespace Lutron.Common.Interfaces
{
    public interface IEthernetService
    {
        string GetIpAddress();
        void SetIpAddress(string ipAddress);
        string GetGatewayAddress();
        void SetGatewayAddress(string gatewayAddress);
        string GetSubnetMask();
        void SetSubnetMask(string subnetMask);
        string GetDhcp();
        string GetMulticastAddress();
        void SetMulticastAddress(string multicastAddress);
    }
}