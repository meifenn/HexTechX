using Infra.Helpers.Paging;
using Infra.Models;
using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helpers.ApiRequestHelper.UserApiRequest
{
    public class UserApiRequestBase : IUserApiRequest
    {
        private readonly ApiRequest _apiRequest;
        public UserApiRequestBase(ApiRequest apiRequest)
        {
            _apiRequest = apiRequest;
        }

        public async Task<string> Authenticate(string username, string password)
        {
            AuthViewModel auth = new AuthViewModel
            {
                UserName = username,
                Password = password
            };
            string url = $@"{ApiUrl.Url}api/auth/login";
            var model = await _apiRequest.PostAsync<AuthViewModel, string>(url, auth);
            return model;
        }

        public async Task<string> Delete(int id)
        {
            string url = $@"{ApiUrl.Url}api/users/delete?id={id}";
            var model = await _apiRequest.DeleteAsync(url);
            return model;
        }

        public async Task<User> GetByID(int id)
        {
            string url = $@"{ApiUrl.Url}api/users/getbyid?id={id}";
            var model = await _apiRequest.GetAsync<User>(url);
            return model;
        }

        public async Task<User?> GetByName(string? name)
        {
            string url = $@"{ApiUrl.Url}api/users/getbyname?name={name}";
            var model = await _apiRequest.GetAsync<User?>(url);
            return model;
        }

        public async Task<string> Insert(User user)
        {
            string url = $@"{ApiUrl.Url}api/users/insert";
            var model = await _apiRequest.PostAsync<User, string>(url, user);
            return model;
        }

        public async Task<string> Update(User user)
        {
            string url = $@"{ApiUrl.Url}api/users/update";
            var model = await _apiRequest.PostAsync<User, string>(url, user);
            return model;
        }
    }
}
