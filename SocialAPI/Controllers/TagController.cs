using Microsoft.AspNetCore.Mvc;
using SocialAPI.Services.Posts;
using SocialAPI.Services.Tags;

namespace SocialAPI.Controllers
{
    [ApiController]
    [Route("api/tags")]
    public class TagController : ControllerBase
    {
        private readonly ITag _iTag;
        public TagController(ITag iTag)
        {
            _iTag = iTag;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            var res = await _iTag.Get();
            return Ok(res);
        }
    }
}
