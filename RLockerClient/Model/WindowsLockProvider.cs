using Microsoft.Win32;
using RLockerClient.Model.Interfaces;
using System;
using System.Runtime.InteropServices;

namespace RLockerClient.Model
{
    public class WindowsLockProvider : ILocker
    {
        [DllImport("user32.dll")]
        static extern bool LockWorkStation();

        bool isLocked;
        Action<bool> isLockedChangedAction;
        public bool IsLocked
        {
            get
            {
                return isLocked;
            }
            private set
            {
                isLockedChangedAction?.Invoke(value);
                isLocked = value;
            }
        }
        public WindowsLockProvider()
        {
            SystemEvents.SessionSwitch += new SessionSwitchEventHandler((sender, e) =>
            {
                if (e.Reason == SessionSwitchReason.SessionLock)
                {
                    IsLocked = true;
                }
                else if (e.Reason == SessionSwitchReason.SessionUnlock)
                {
                    IsLocked = false;
                }
            }); 
        }

        public void IsLockedChanged(Action<bool> action)
        {
            isLockedChangedAction = action;
        }

        public void Lock()
        {
            LockWorkStation();
        }
    }
}
