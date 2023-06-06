﻿using BlazorChat.Shared;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;


namespace BlazorChat.Server.Hubs
{
    [Authorize]
    public class ChatHub:Hub<IChatHubClient>, IChatHubServer
    {
        
        private static readonly IDictionary<int, UserDto> _onlineUsers = new Dictionary<int, UserDto>();
        public ChatHub() 
        {

        }
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public async Task SetUserOnline(UserDto user)
        {
            await Clients.Caller.OnlineUsersList(_onlineUsers.Values);
            if (!_onlineUsers.ContainsKey(user.Id))
            {
                _onlineUsers.Add(user.Id, user);
                await Clients.Others.UserIsOnline(user.Id);
            }
        }
    }
}
