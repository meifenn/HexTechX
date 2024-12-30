using Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace SocialAPI.Services.Friends
{
    public class FriendBase : IFriend
    {
        private readonly AppDbContext _context;
        DateTime now;
        public FriendBase(AppDbContext context)
        {
            _context = context;
            now = DateTime.Now;

        }
        public async Task<List<User>> GetFriends(int userId)
        {
            var friends = _context.Friends.AsNoTracking().Where(x => x.UserID == userId);
            if (friends is null)
            {
                return new List<User>();
            }

            List<User> users = new List<User>();
            foreach (var friend in friends)
            {
                var user = await _context.Users.FindAsync(friend.FriendID);
                if (user is not null)
                {
                    users.Add(user);
                }
            }
            return users;
        }

        public async Task<string> RemoveFriend(int userId, int friendId)
        {
            var friend = _context.Friends.FirstOrDefault(a => a.UserID == userId && a.FriendID == friendId);
            if(friend is null)
            {
                return "friendship does not exist";
            }
            //remove from reverse friendship
            var reverseFriend = _context.Friends.FirstOrDefault(a => a.UserID == friendId && a.FriendID == userId);

            _context.Friends.Remove(friend);
            if(reverseFriend != null)
            {
                _context.Friends.Remove(reverseFriend);
            }
            var res = await _context.SaveChangesAsync();
            return "success";
        }
    }
}
