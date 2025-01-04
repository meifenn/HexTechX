using Infra.Models;
using Microsoft.AspNetCore.Mvc;
using SocialAPI.Services.Comments;

namespace SocialAPI.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentController : ControllerBase
    {
        private readonly IComment _iComment;
        public CommentController(IComment iComment)
        {
            _iComment = iComment;
        }
        [HttpPost("insert")]
        public async Task<IActionResult> InsertComment(Comment comment)
        {
            var res = await _iComment.InsertComment(comment);
            return Ok(res);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteComment(int commentId = 0)
        {
            var res = await _iComment.DeleteComment(commentId);
            return Ok(res);
        }
        [HttpGet("get")]
        public async Task<IActionResult> GetComments(int? postId = 0)
        {
            var res = await _iComment.GetComments(postId);
            return Ok(res);
        }
    }
}
