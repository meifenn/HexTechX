using Infra.Helpers.Paging;
using Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helpers.ApiRequestHelper.UserApiRequest
{
    public interface IUserApiRequest
    {
        Task<User?> GetByName(string? name);
        Task<string> Insert(User user);
        Task<string> Update(User user);
        Task<string> Delete(int id);
        Task<User> GetByID(int id);
        Task<string> Authenticate(string username, string password);
    }
}
