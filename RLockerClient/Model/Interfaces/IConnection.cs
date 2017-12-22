using System;
namespace RLockerClient.Model.Interfaces
{
    public interface IConnection
    {
        bool IsConnected { get; }
        void IsIsConnectedChanged(Action<bool> action);
        void ConnectToServer(string url);
        void SetCorelationId(string corelationId);
        void SendCommand(ICommandRequest command);
        void ReceiveCommand(Action<ICommandRequest> command);
    }
}
