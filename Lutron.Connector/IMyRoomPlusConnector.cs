namespace Lutron.Connector
{
    public interface IMyRoomPlusConnector
    {
        string Query(string commandString);
        void Execute(string commandString);
    }
}