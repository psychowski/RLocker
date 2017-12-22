using System;
using RLockerClient.Model.Interfaces;
using Microsoft.AspNet.SignalR.Client;
using RLockerClient.Model.Commands;

namespace RLockerClient.Model
{
    public class Connection : Interfaces.IConnection
    {
        public bool IsConnected => true;
        HubConnection hubConnection;
        IHubProxy commandHub;
        Action<ICommandRequest> receiveCommand;
        string corelationId;
        public Connection()
        {

        }

        public async void ConnectToServer(string url)
        {
            hubConnection = new HubConnection(url);
            commandHub = hubConnection.CreateHubProxy("CommandHub");
            await hubConnection.Start();
            commandHub.On("sendCommand", () =>
            {
                receiveCommand?.Invoke(new LockCommand());
            });

        }

        public void IsIsConnectedChanged(Action<bool> action)
        {

        }

        public void ReceiveCommand(Action<ICommandRequest> command)
        {
            receiveCommand = command;   
        }

        public async void SendCommand(ICommandRequest command)
        {
            await commandHub.Invoke<string>("Join", this.corelationId);
            await commandHub.Invoke<string>("Lock", command.Id, this.corelationId);
        }

        public void SetCorelationId(string corelationId)
        {
            this.corelationId = corelationId;
            
        }
    }
}
