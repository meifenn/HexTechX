using Infra.Models;

namespace SocialAPI.Services.FriendRequests
{
    public interface IFriendRequest
    {
        Task<string> SendFriendRequest(FriendRequest req);
        Task<List<FriendRequest>> GetFriendRequest(int userId);
        Task<string> RespondFriendRequest(int Id, bool? IsAccept = true);
    }
}
