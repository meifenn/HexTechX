using Infra.Helpers.Paging;
using Infra.Models;
using Infra.ViewModels;

namespace SocialAPI.Services.Users
{
    public interface IUser
    {
        Task<User?> GetByName(string? name);
        Task<string> Insert(User user);
        Task<string> Update(User user);
        Task<string> Delete(int id);
        Task<User> GetByID(int id);
        Task<UserProfile> GetProfile(int loggedInUserId, int viewingUserId);
        Task<Paging<User>> GetPaging(int page = 1, int pageSize =10, string? searchString = "");
    }
}
