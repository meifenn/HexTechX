using Infra.Models;
using Infra.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SocialAPI.Services.Likes;

namespace SocialAPI.Controllers
{
    [ApiController]
    [Route("api/likes")]
    public class LikeController : ControllerBase
    {
        private readonly ILike _iLike;
        public LikeController(ILike iLike)
        {
            _iLike = iLike;
        }
        [HttpPost("processlike")]
        public async Task<IActionResult> ProcessLike(LikeViewModel vm)
        {
            var res = await _iLike.ProcessLike(vm.userId, vm.postId);
            return Ok(res);
        }
    }
}
