using BlazorChat.Shared;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;


namespace BlazorChat.Server.Hubs
{
   
    public class ChatHub:Hub<IChatHubClient>, IChatHubServer
    {
        
        private static readonly IDictionary<int, UserDto> _connectedUsers = new Dictionary<int, UserDto>();
        public ChatHub() 
        {

        }
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public async Task ConnectUser(UserDto user)
        {
            await Clients.Caller.ConnectedUsersList(_connectedUsers.Values);
            if (!_connectedUsers.ContainsKey(user.Id))
            {
                _connectedUsers.Add(user.Id, user);

                await Clients.Others.UserConnected(user);
            }
            
        }
    }
}
