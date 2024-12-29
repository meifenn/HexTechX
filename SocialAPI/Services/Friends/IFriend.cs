using Infra.Models;

namespace SocialAPI.Services.Friends
{
    public interface IFriend
    {
        Task<List<User>> GetFriends(int userId);
        Task<string> RemoveFriend(int userId, int friendId);
    }
}
