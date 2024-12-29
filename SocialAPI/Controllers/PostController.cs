using Infra.Models;
using Microsoft.AspNetCore.Mvc;
using SocialAPI.Services.Posts;

namespace SocialAPI.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostController : ControllerBase
    {
        private readonly IPost _iPost;
        public PostController(IPost iPost)
        {
            _iPost = iPost;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(int page = 1, int pageSize = 10, string? searchString = null, int? userId = null, string? tag = null)
        {
            var res = await _iPost.GetPaging(page,pageSize,searchString,userId,tag);  
            return Ok(res);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _iPost.GetByID(id);
            return Ok(res);
        }

        [HttpPost("insert")]
        public async Task<IActionResult> Insert(Post post)
        {
            var res = await _iPost.Insert(post);
            return Ok(res);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(Post post)
        {
            var res = await _iPost.Update(post);
            return Ok(res);
        }

     

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _iPost.Delete(id);
            return Ok(res);
        }

    }
}
