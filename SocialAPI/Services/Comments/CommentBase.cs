
using Infra.Models;

namespace SocialAPI.Services.Comments
{
    public class CommentBase : IComment
    {
        private readonly AppDbContext _context;
        DateTime now;
        public CommentBase(AppDbContext ctx)
        {
            _context = ctx; 
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
            var res = await _context.SaveChangesAsync();
            return res == 1 ? "success" : "fail";
        }
        public async Task<string> DeleteComment(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if(comment == null)
            {
                return "empty comment";
            }

            _context.Comments.Remove(comment);
            var res = await _context.SaveChangesAsync();
            return res == 1 ? "success" : "fail";
        }

       
    }
}
