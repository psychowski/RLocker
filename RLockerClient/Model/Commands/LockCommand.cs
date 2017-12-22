using System;
using RLockerClient.Model.Interfaces;

namespace RLockerClient.Model.Commands
{
    public class LockCommand : ICommandRequest
    {
        public string Id
        {
            get
            {
                return "Lock";
            }
        }
    }
}
