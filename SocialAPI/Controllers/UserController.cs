using Infra.Models;
using Microsoft.AspNetCore.Mvc;
using SocialAPI.Services.Users;

namespace SocialAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUser _iUser;
        public UserController(IUser iUser)
        {
            _iUser = iUser;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetPaging(int page = 1, int pageSize = 10, string? searchString = null)
        {
            var res = await _iUser.GetPaging(page, pageSize, searchString);
            return Ok(res);
        }


        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _iUser.GetByID(id);
            return Ok(res);
        }
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile(int loggedInUserId, int viewingUserId)
        {
            var res = await _iUser.GetProfile(loggedInUserId, viewingUserId);
            return Ok(res);
        }
        [HttpGet("getbyname")]
        public async Task<IActionResult> GetByName(string? name = "")
        {
            var res = await _iUser.GetByName(name);
            return Ok(res);
        }

        [HttpPost("insert")]
        public async Task<IActionResult> Insert(User user)
        {
            var res = await _iUser.Insert(user);
            return Ok(res);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(User user)
        {
            var res = await _iUser.Update(user);
            return Ok(res);
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _iUser.Delete(id);
            return Ok(res);
        }
    }
}
