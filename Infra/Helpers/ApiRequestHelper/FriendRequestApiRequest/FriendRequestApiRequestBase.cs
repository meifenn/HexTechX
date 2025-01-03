﻿using Infra.Models;
using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helpers.ApiRequestHelper.FriendRequestApiRequest
{
    public class FriendRequestApiRequestBase : IFriendRequestApiRequest
    {
        private readonly ApiRequest _apiRequest;
        public FriendRequestApiRequestBase(ApiRequest apiRequest)
        {
            _apiRequest = apiRequest;
        }

        public async Task<FriendRequest> GetByIds(int fromUserId, int toUserId)
        {
            string url = $@"{ApiUrl.Url}api/friendrequests/getbyids?fromUserId={fromUserId}&toUserId={toUserId}";
            var model = await _apiRequest.GetAsync<FriendRequest>(url);
            return model;
        }

        public async Task<List<FriendRequest>> GetFriendRequest(int userId)
        {
            string url = $@"{ApiUrl.Url}api/friendrequests/get?userId={userId}";
            var model = await _apiRequest.GetAsync<List<FriendRequest>>(url);
            return model;
        }

        public async Task<string> RespondFriendRequest(int Id, bool? IsAccept = true)
        {
            FriendRequestResponseViewModel vm = new FriendRequestResponseViewModel
            {
                Id = Id,
                IsAccepted = IsAccept
            };
            string url = $@"{ApiUrl.Url}api/friendrequests/respond";
            var model = await _apiRequest.PostAsync<FriendRequestResponseViewModel, string>(url, vm);
            return model;
        }

        public async Task<string> SendFriendRequest(FriendRequest req)
        {
            string url = $@"{ApiUrl.Url}api/friendrequests/send";
            var model = await _apiRequest.PostAsync<FriendRequest, string>(url, req);
            return model;
        }
    }
}
