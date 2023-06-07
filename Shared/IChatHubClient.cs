using BlazorChat.Shared.DTOs;

namespace BlazorChat.Shared
{
    public interface IChatHubClient
    {
        Task UserConnected(UserDto user);
       
        Task OnlineUsersList(IEnumerable<UserDto> users);
        Task UserIsOnline(int userId);
        Task MessageRecieved(MessageDto messageDto);

    }
}
