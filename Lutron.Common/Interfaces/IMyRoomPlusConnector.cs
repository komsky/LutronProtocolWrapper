namespace Lutron.Common.Interfaces
{
    public interface IMyRoomPlusConnector
    {
        string Query(string commandString);
        void Execute(string commandString);
    }
}