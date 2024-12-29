using Microsoft.AspNetCore.Mvc;
using SocialAPI.Services.Comments;
using SocialAPI.Services.Friends;

namespace SocialAPI.Controllers
{
    [ApiController]
    [Route("api/friends")]
    public class FriendController : ControllerBase
    {
        private readonly IFriend _iFriend;
        public FriendController(IFriend iFriend)
        {
            _iFriend = iFriend;
        }
        [HttpGet("get")]
        public async Task<IActionResult> Get(int userId)
        {
            var res = await _iFriend.GetFriends(userId);
            return Ok(res); 
        }
        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveFriend(int userId= 0, int friendId =0)
        {
            var res = await _iFriend.RemoveFriend(userId, friendId);
            return Ok(res);
        }

    }
}
