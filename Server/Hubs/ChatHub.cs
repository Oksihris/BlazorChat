using Microsoft.AspNetCore.SignalR;

namespace BlazorChat.Server.Hubs
{
    public interface IChatHubClient
    {
        void RecieveMessage(string message);

    }
    public class ChatHub:Hub<IChatHubClient>
    {
        public ChatHub() 
        {

        }
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}
