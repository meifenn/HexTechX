using Infra.Models;

namespace SocialAPI.Services.Comments
{
    public interface IComment
    {
        Task<string> InsertComment(Comment comment);
        Task<string> DeleteComment(int commentId);
        Task<List<Comment>> GetComments(int? postId = 0);
    }
}
