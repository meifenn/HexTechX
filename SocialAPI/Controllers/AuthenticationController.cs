using Infra.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SocialAPI.Services.Auth;

namespace SocialAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication _iAuth;
        public AuthenticationController(IAuthentication iAuth)
        {
            _iAuth = iAuth;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate(AuthViewModel auth)
        {
            var result = await _iAuth.Authenticate(auth.UserName, auth.Password);
            return Ok(result);
        }
    }
}
