using Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helpers.ApiRequestHelper.CommentApiRequest
{
    public interface ICommentApiRequest
    {
        Task<string> InsertComment(Comment comment);
        Task<string> DeleteComment(int commentId);
        Task<List<Comment>> GetComments(int? postId = 0);

    }
}
