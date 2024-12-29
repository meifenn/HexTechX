
using Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace SocialAPI.Services.Auth
{
    public class Authentication : IAuthentication
    {
        private readonly AppDbContext _context;
        public Authentication(AppDbContext ctx)
        {
            _context = ctx;
        }
        public async Task<string> Authenticate(string? userName = null, string? password = null)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            if(user is null)
            {
                return "user name does not exist";
            }
            if(user.Password != password)
            {
                return "incorrect password";
            }
            return "success";
        }
    }
}
