using BlazorSignalRApp.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace BlazorSignalRApp.Controller;

[Route("api/[controller]")]
[ApiController]
public class HubController(IHubContext<ChatHub> _hub) : ControllerBase
{
	[HttpGet]
	public async Task<bool> Get(string Message,string GroupName)
	{
		await _hub.Clients.Group(GroupName).SendAsync("ReceiveMessage", new
		{
			Message
		},
		new
		{
			Message,
		}
		);
		return true;
	}

	[HttpGet("Join")]
	public async Task<string> Join(string ConnectionId,string GroupName)
	{
		await _hub.Groups.AddToGroupAsync(ConnectionId, GroupName);
		return $"{GroupName} - {ConnectionId}";
	}
}
