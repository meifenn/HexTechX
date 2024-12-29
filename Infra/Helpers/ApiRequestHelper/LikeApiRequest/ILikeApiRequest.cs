using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helpers.ApiRequestHelper.LikeApiRequest
{
    public interface ILikeApiRequest
    {
        Task<string> ProcessLike(int userId = 0, int postId = 0);

    }
}
