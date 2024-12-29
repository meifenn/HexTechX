using Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace SocialAPI.Services.Tags
{
    public class TagBase : ITag
    {
        private readonly AppDbContext _context;
        DateTime current;
        public TagBase(AppDbContext context)
        {
            _context = context;

            current = DateTime.Now;
        }
        public async Task<List<Tag>> Get()
        {
            var tags = await _context.Tags.AsNoTracking().ToListAsync();
            return tags ?? new List<Tag>();
        }
    }
}
