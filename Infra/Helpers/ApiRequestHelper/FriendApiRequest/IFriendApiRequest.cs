using Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helpers.ApiRequestHelper.FriendApiRequest
{
    public interface IFriendApiRequest
    {
        Task<List<User>> GetFriends(int userId);
        Task<string> RemoveFriend(int userId, int friendId);
    }
}
