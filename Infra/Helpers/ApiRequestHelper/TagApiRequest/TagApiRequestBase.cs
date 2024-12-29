using Infra.Models;
using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helpers.ApiRequestHelper.TagApiRequest
{
    public class TagApiRequestBase : ITagApiRequest
    {
        private readonly ApiRequest _apiRequest;
        public TagApiRequestBase(ApiRequest apiRequest)
        {
            _apiRequest = apiRequest;
        }
        public async Task<List<Tag>> Get()
        {
            string url = $@"{ApiUrl.Url}api/tags/get";
            var model = await _apiRequest.GetAsync<List<Tag>>(url);
            return model;
        }
    }
}
