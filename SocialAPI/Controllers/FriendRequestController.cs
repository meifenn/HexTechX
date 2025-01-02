using Infra.Models;
using Infra.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SocialAPI.Services.FriendRequests;

namespace SocialAPI.Controllers
{
    [ApiController]
    [Route("api/friendrequests")]
    public class FriendRequestController : ControllerBase
    {
        private readonly IFriendRequest _iFriendRequest;
        public FriendRequestController(IFriendRequest iFriendRequest)
        {
            _iFriendRequest = iFriendRequest;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendFriendRequest(FriendRequest req)
        {
            var res = await _iFriendRequest.SendFriendRequest(req);
            return Ok(res);
        }
        [HttpGet("get")]
        public async Task<IActionResult> GetFriendRequest(int userId)
        {
            var res = await _iFriendRequest.GetFriendRequest(userId);
            return Ok(res);
        }
        [HttpGet("getbyids")]
        public async Task<IActionResult> GetByIds(int fromUserId, int toUserId)
        {
            var res = await _iFriendRequest.GetByIds(fromUserId, toUserId);
            return Ok(res);
        }
        [HttpPost("respond")]
        public async Task<IActionResult> RespondFriendRequest(FriendRequestResponseViewModel response)
        {
            var res = await _iFriendRequest.RespondFriendRequest(response.Id ?? 0, response.IsAccepted);
            return Ok(res);
        }
    }
}
