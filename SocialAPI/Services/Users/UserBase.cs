using Infra.Helpers.Paging;
using Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace SocialAPI.Services.Users
{
    public class UserBase : IUser
    {
        private readonly AppDbContext _context;
        DateTime now;
        public UserBase(AppDbContext context)
        { 
            _context = context; 
            now = DateTime.Now; 

        }
        public async Task<string> Delete(int id)
        {
            var user = await GetByID(id);
            if (user.ID == 0)
            {
                return "empty user";
            }

            _context.Users.Remove(user);
            var res = await _context.SaveChangesAsync();
            return res == 1 ? "success" : "fail";
        }

        public async Task<User> GetByID(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user ?? new User();
        }

        public async Task<User?> GetByName(string? name)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(a => a.UserName == name);
            return user;
        }
        public async Task<Paging<User>> GetPaging(int page = 1, int pageSize = 10, string? searchString = "")
        {
            var query = _context.Users.AsNoTracking();
            
            if (query is null)
            {
                return new Paging<User>();
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(a => a.UserName.Contains(searchString));
            }

            var pagedList = await query.Skip(pageSize * (page - 1)).Take(pageSize).ToListAsync();
            Paging<User> data = new Paging<User>();
            data.TotalEntities = query.Count();
            data.TotalPages = (int)Math.Ceiling((double)data.TotalEntities / pageSize);
            data.PageSize = pageSize;
            data.PageNumber = page;
            data.Results = pagedList;
            return data;
        }

        public async Task<string> Insert(User user)
        {
            var usernameCheck = await GetByName(user.UserName);
            if(usernameCheck != null)
            {
                return "username already exist";
            }
            user.CreatedTime = now;
            await _context.Users.AddAsync(user);
            var res = await _context.SaveChangesAsync();
            return res == 1 ? "success" : "fail";
        }

        public async Task<string> Update(User user)
        {
            var usernameCheck = await _context.Users.AsNoTracking()
                .Where(a => a.UserName == user.UserName && a.ID != user.ID).AnyAsync();

            if(usernameCheck == true)
            {
                return "username already exist";
            }
            user.ModifiedTime = now;
            await _context.Users.AddAsync(user);
            var res = await _context.SaveChangesAsync();
            return res == 1 ? "success" : "fail";
        }
    }
}
