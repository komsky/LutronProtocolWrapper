namespace Lutron.Common.Interfaces
{
    public interface IIntegrationIdService
    {
        int GetIntegrationId(string serialNumber);
        string GetInfoFromId(int integrationId);
    }
}