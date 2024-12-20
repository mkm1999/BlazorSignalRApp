using Microsoft.AspNetCore.SignalR;

namespace BlazorSignalRApp.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.Group("await Groups.AddToGroupAsync(Context.ConnectionId, \"1\");").SendAsync("ReceiveMessage", user, message);
    }

    public string GetConnectionId() => Context.ConnectionId;
}
