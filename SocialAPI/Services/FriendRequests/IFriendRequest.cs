using Infra.Models;

namespace SocialAPI.Services.FriendRequests
{
    public interface IFriendRequest
    {
        Task<string> SendFriendRequest(FriendRequest req);
        Task<List<FriendRequest>> GetFriendRequest(int userId);
        Task<FriendRequest> GetByIds(int fromUserId, int toUserId);
        Task<string> RespondFriendRequest(int Id, bool? IsAccept = true);
    }
}
