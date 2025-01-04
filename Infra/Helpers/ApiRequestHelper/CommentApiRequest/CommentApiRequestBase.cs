using Infra.Models;
using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helpers.ApiRequestHelper.CommentApiRequest
{
    public class CommentApiRequestBase : ICommentApiRequest
    {
        private readonly ApiRequest _apiRequest;
        public CommentApiRequestBase(ApiRequest apiRequest)
        {
            _apiRequest = apiRequest;
        }
        public async Task<string> DeleteComment(int commentId)
        {
            string url = $@"{ApiUrl.Url}api/comments/delete?commentId={commentId}";
            var model = await _apiRequest.DeleteAsync(url);
            return model;
        }

        public async Task<List<Comment>> GetComments(int? postId = 0)
        {
            string url = $@"{ApiUrl.Url}api/comments/get?postId={postId}";
            var model = await _apiRequest.GetAsync<List<Comment>>(url);
            return model;
        }

        public async Task<string> InsertComment(Comment comment)
        {
            string url = $@"{ApiUrl.Url}api/comments/insert";
            var model = await _apiRequest.PostAsync<Comment, string>(url, comment);
            return model;
        }
    }
}
