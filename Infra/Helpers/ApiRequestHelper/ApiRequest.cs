using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Infra.Helpers.ApiRequestHelper
{
    public class ApiRequest
    {
        private readonly HttpClient _httpClient;

        public ApiRequest(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromSeconds(60);
        }

        public async Task<T> GetAsync<T>(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<T>();
                
         
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"GET request to {url} failed: {ex.Message}");
            }
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest data)
        {
            try
            {
                //var response = await _httpClient.PostAsJsonAsync(url, data);
                //response.EnsureSuccessStatusCode();
                //return await response.Content.ReadFromJsonAsync<TResponse>();
                //_httpClient.Timeout = TimeSpan.FromSeconds(60); // Adjust timeout as needed
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    using (var content = new StringContent(JsonSerializer.Serialize(data), UTF8Encoding.UTF8, "application/json"))
                    {
                        using (var response = await client.PostAsync(url, content))
                        {
                            response.EnsureSuccessStatusCode();
                            if (response.IsSuccessStatusCode)
                            {
                                var responseContent = await response.Content.ReadAsStringAsync();

                                if (typeof(TResponse) == typeof(string))
                                {
                                    // Directly return the string content if TResponse is string
                                    return (TResponse)(object)responseContent;
                                }
                                else
                                {
                                    // Deserialize to the target type
                                    return JsonSerializer.Deserialize<TResponse>(responseContent);
                                }
                            }
                            else
                            {
                                return default(TResponse);
                            }
                        }
                    }
                }
              
                
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"POST request to {url} failed: {ex.Message}");
            }
        }

        public async Task<string> DeleteAsync(string url)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(url);
                
                response.EnsureSuccessStatusCode();
                if(response.IsSuccessStatusCode)
                {
                    return "success";
                }
                else
                {
                    return "fail";
                }
                
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"DELETE request to {url} failed: {ex.Message}");
            }
        }
    
    }
}
