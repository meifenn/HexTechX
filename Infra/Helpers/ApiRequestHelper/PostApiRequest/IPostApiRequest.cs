using Infra.Helpers.Paging;
using Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helpers.ApiRequestHelper.PostApiRequest
{
    public interface IPostApiRequest
    {
        Task<Post> GetByID(int id);
        Task<Paging<Post>> GetPaging(int page = 1, int pageSize = 10, string? searchString = null, int? userId = null, string? tag = null);
        Task<string> Insert(Post post);
        Task<string> Update(Post post);
        Task<string> Delete(int id);
    }
}
