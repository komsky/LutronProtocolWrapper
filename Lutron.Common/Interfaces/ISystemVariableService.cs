using Lutron.Common.Enums;
using Lutron.Common.Models;

namespace Lutron.Common.Interfaces
{
    public interface ISystemVariableService
    {
        string GetSystemVariable(int integrationId);
        void SetSystemVariable(int integrationId, VariableState variableState);
    }
}