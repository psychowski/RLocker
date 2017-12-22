using RLockerClient.Model.Commands;
using RLockerClient.Model.Interfaces;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RLockerClient.Model
{
    public class RemoteLockerViewModel: INotifyPropertyChanged
    {
        ILocker lockProvider;
        IConnection connection;
        ClientConfiguration config;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsMaster { get { return config.IsMaster; } set { config.IsMaster = value; NotifyPropertyChanged(); } }
        public string CorrelationId { get { return config.CorrelationId; } set { config.CorrelationId = value; NotifyPropertyChanged(); } }

        public RemoteLockerViewModel(ILocker lockProvider, IConnection connection)
        {
            this.lockProvider = lockProvider;
            this.connection = connection;
            this.lockProvider.IsLockedChanged(SendLockCommand);
            this.connection.ReceiveCommand(ReceiveCommand);

            this.connection = connection;
            this.config = new ClientConfiguration();
        }

        public void GenerateCorrelationId()
        {
            config.CorrelationId = Guid.NewGuid().ToString().ToUpper();
        }

        public void Connect()
        {
            connection.ConnectToServer("http://localhost:10957");
        }

        public void SetCorrelationId()
        {
            connection.SetCorelationId(CorrelationId);
        }

        private void SendLockCommand(bool isLocked)
        {
            if (isLocked)
            {
                this.connection.SendCommand(new LockCommand());
            }
        }

        private void ReceiveCommand(ICommandRequest command)
        {
            if (command.Id == "Lock")
            {
                this.lockProvider.Lock();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
