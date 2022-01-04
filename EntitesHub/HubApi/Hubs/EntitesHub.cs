using HubApi.Models;
using Microsoft.AspNetCore.SignalR;

namespace HubApi.Hubs
{
    public class EntitesHub : Hub
    {
        public async Task SendMessage(Entity entity)
        {
            if (Clients is not null)
                await Clients.All.SendAsync("addNewCoordinate", entity);
        }
    }
}
