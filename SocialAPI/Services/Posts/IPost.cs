using Infra.Helpers.Paging;
using Infra.Models;

namespace SocialAPI.Services.Posts
{
    public interface IPost
    {
        Task<Paging<Post>> GetPaging(int page = 1, int pageSize = 10, string? searchString = null, int? userId = null, string? tag = null);
        Task<string> Insert(Post post);
        Task<string> Update(Post post);
        Task<string> Delete(int id);
        Task<Post> GetByID(int id);
        Task<string> ProcessLikeCount(int postId = 0, bool isIncreasing = true);
        Task<string> ProcessCommentCount(int postId = 0, bool isIncreasing = true);

    }
}
