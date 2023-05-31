using BlazorChat.Shared;
using Microsoft.AspNetCore.SignalR;

namespace BlazorChat.Server.Hubs
{
   
    public class ChatHub:Hub<IChatHubClient>, IChatHubServer
    {
        private static ICollection<string> _connectedUsers = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        public ChatHub() 
        {

        }
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public async Task ConnectUser(string userName)
        {
            if (!_connectedUsers.Contains(userName))
            {
                _connectedUsers.Add(userName);

                await Clients.Others.UserConnected(userName);
            }
            
        }
    }
}
