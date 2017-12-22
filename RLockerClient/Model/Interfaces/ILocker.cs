using System;
namespace RLockerClient.Model.Interfaces
{
    public interface ILocker
    {
        bool IsLocked { get; }
        void IsLockedChanged(Action<bool> action);
        void Lock();
    }
}
