using PosIntegration.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PosIntegration.Service.Common
{
    public class HttpService 
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HttpService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<PostResponse<TResponse>> PostAsync<TRequest, TResponse>(string url, TRequest request, string clientName)
        {
            var body = JsonSerializer.Serialize(request);
            var httpClient = _httpClientFactory.CreateClient(clientName);
            var httpResponse = await httpClient.PostAsync(url, new StringContent(body, Encoding.UTF8, "application/json"));
            httpResponse.EnsureSuccessStatusCode();
            var responseData = await httpResponse.Content.ReadAsStringAsync();
            var postResponse = JsonSerializer.Deserialize<PostResponse<TResponse>>(responseData);
            return postResponse;
        }
    }
}
