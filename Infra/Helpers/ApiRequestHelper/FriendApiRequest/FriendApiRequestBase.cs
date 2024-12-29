using Infra.Models;
using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helpers.ApiRequestHelper.FriendApiRequest
{
    public class FriendApiRequestBase : IFriendApiRequest
    {
        private readonly ApiRequest _apiRequest;
        public FriendApiRequestBase(ApiRequest apiRequest)
        {
            _apiRequest = apiRequest;
        }

        public async Task<List<User>> GetFriends(int userId)
        {
            string url = $@"{ApiUrl.Url}api/friends/get?userId={userId}";
            var model = await _apiRequest.GetAsync<List<User>>(url);
            return model;
        }

        public async Task<string> RemoveFriend(int userId, int friendId)
        {
            string url = $@"{ApiUrl.Url}api/friends/remove?userId={userId}&friendId={friendId}";
            var model = await _apiRequest.DeleteAsync(url);
            return model;
        }
    }
}
