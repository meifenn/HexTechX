using Azure.Core;
using Infra.Helpers.Paging;
using Infra.Models;
using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helpers.ApiRequestHelper.PostApiRequest
{
    public class PostApiRequestBase : IPostApiRequest
    {
        private readonly ApiRequest _apiRequest;
        public PostApiRequestBase(ApiRequest apiRequest) 
        { 
            _apiRequest = apiRequest;
        }

        public async Task<string> Delete(int id)
        {
            string url = $@"{ApiUrl.Url}api/posts/delete?id={id}";
            var model = await _apiRequest.DeleteAsync(url);
            return model;
        }

        public async Task<Post> GetByID(int id)
        {
            string url = $@"{ApiUrl.Url}api/posts/getbyid?id={id}";
            var model = await _apiRequest.GetAsync<Post>(url);
            return model;
        }

        public async Task<Paging<Post>> GetPaging(int page = 1, int pageSize = 10, string? searchString = null, int? userId = null, string? tag = null)
        {
            string url = $@"{ApiUrl.Url}api/posts/get?page={1}&pageSize={pageSize}&searchString={searchString}&userId={userId}&tag={tag}";
            var model = await _apiRequest.GetAsync<Paging<Post>>(url);
            return model;
        }

        public async Task<string> Insert(Post post)
        {
            string url = $@"{ApiUrl.Url}api/posts/insert";
            var model = await _apiRequest.PostAsync<Post, string>(url, post);
            throw new NotImplementedException();
        }

        public async Task<string> Update(Post post)
        {
            string url = $@"{ApiUrl.Url}api/posts/update";
            var model = await _apiRequest.PostAsync<Post, string>(url, post);
            throw new NotImplementedException();
        }
    }
}
