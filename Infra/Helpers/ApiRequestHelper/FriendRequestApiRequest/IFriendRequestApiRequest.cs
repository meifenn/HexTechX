using Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helpers.ApiRequestHelper.FriendRequestApiRequest
{
    public interface IFriendRequestApiRequest
    {
        Task<string> SendFriendRequest(FriendRequest req);
        Task<List<FriendRequest>> GetFriendRequest(int userId);
        Task<string> RespondFriendRequest(int Id, bool? IsAccept = true);
    }
}
