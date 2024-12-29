
using Infra.Models;
using Microsoft.EntityFrameworkCore;
using SocialAPI.Services.Posts;

namespace SocialAPI.Services.Likes
{
    public class LikeBase : ILike
    {
        private readonly AppDbContext _context;
        private readonly IPost _post;
        DateTime now;
        public LikeBase(AppDbContext ctx, IPost post)
        {
            _context = ctx;
            _post = post;
        }
        public async Task<string> ProcessLike(int userId = 0, int postId = 0)
        {
            if(userId == 0 || postId == 0)
            {
                return "empty user or post";
            }

            var existing = await _context.Likes
                .FirstOrDefaultAsync(a => a.UserID == userId && a.PostID == postId);

            if(existing == null) //do like
            {
                Like like = new Like
                {
                    PostID = postId,
                    UserID = userId,
                    CreatedTime = now,
                };
                await _context.Likes.AddAsync(like);
                var res = await _post.ProcessLikeCount(postId, true);
            }
            else //do unlike
            {
                _context.Likes.Remove(existing);
                var res = await _post.ProcessLikeCount(postId, false);
            }
            return "success";
        }
    }
}
