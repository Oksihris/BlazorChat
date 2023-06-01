using BlazorChat.Shared.DTOs;

namespace BlazorChat.Shared
{
    public interface IChatHubClient
    {
        Task UserConnected(UserDto user);
        Task ConnectedUsersList(IEnumerable<UserDto> users);


    }
}
