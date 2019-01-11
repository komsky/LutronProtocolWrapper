using Lutron.Common.Enums;
using Lutron.Common.Models;

namespace Lutron.Common.Interfaces
{
    public interface IEthernetService
    {
        string GetIpAddress();
        void SetIpAddress(string ipAddress);
    }
}