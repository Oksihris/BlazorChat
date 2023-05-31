namespace BlazorChat.Shared
{
    public interface IChatHubClient
    {
        Task UserConnected(string userName);

    }
}
