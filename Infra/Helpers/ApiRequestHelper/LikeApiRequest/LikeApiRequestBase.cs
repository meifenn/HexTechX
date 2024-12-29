using Infra.Models;
using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helpers.ApiRequestHelper.LikeApiRequest
{
    public class LikeApiRequestBase : ILikeApiRequest
    {
        private readonly ApiRequest _apiRequest;
        public LikeApiRequestBase(ApiRequest apiRequest)
        {
            _apiRequest = apiRequest;
        }
        public async Task<string> ProcessLike(int userId = 0, int postId = 0)
        {
            LikeViewModel likevm = new LikeViewModel
            {
                userId = userId,
                postId = postId,
            };
            string url = $@"{ApiUrl.Url}api/likes/processlike";
            var model = await _apiRequest.PostAsync<LikeViewModel, string>(url, likevm);
            throw new NotImplementedException();
        }
    }
}
