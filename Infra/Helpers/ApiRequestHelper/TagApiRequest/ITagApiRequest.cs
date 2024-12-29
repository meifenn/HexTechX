using Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helpers.ApiRequestHelper.TagApiRequest
{
    public interface ITagApiRequest
    {
        Task<List<Tag>> Get();

    }
}
