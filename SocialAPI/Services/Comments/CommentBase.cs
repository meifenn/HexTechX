
using Infra.Models;
using Microsoft.EntityFrameworkCore;
using SocialAPI.Services.Posts;

namespace SocialAPI.Services.Comments
{
    public class CommentBase : IComment
    {
        private readonly AppDbContext _context;
        private readonly IPost _post;
        DateTime now;
        public CommentBase(AppDbContext ctx, IPost post)
        {
            _context = ctx;
            _post = post;
            now = DateTime.Now;
        }
        public async Task<string> InsertComment(Comment comment)
        {
            comment.CreatedTime = now;
            if(comment.UserID != null && comment.UserID !=0)
            {
                var user = await _context.Users.FindAsync(comment.UserID);
                if(user != null)
                {
                    comment.UserName = user.UserName;   
                }
            }
            await _context.Comments.AddAsync(comment);
            var res = await _post.ProcessCommentCount(comment.PostID ??0, true);
            
            return res;
        }
        public async Task<string> DeleteComment(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if(comment == null)
            {
                return "empty comment";
            }

            _context.Comments.Remove(comment);
            var res = await _post.ProcessCommentCount(comment.PostID ?? 0, false);

            return res;
        }

        public async Task<List<Comment>> GetComments(int? postId = 0)
        {
            if(postId == 0)
            {
                return new List<Comment>();
            }
            var query = _context.Comments
                .AsNoTracking()
                .Where(a => a.PostID == postId);

            var res = await query.ToListAsync();
            return res;
        }
    }
}
