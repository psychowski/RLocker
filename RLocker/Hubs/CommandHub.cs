using Microsoft.AspNet.SignalR;

namespace RLocker.Hubs
{
    public class CommandHub : Hub
    {
        public void Join(string corelationId)
        {
            Groups.Add(Context.ConnectionId, corelationId);
        }
        public void Lock(string command, string corelationId)
        {
            Clients.Group(corelationId).sendCommand(command);
        }
    }
}