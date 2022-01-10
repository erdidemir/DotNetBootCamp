using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PosIntegration.Exception;
using PosIntegration.Model;
using PosIntegration.Model.Auth;
using PosIntegration.Model.RedirectUrl;
using PosIntegration.Model.Refund;
using PosIntegration.Service.Common;

namespace PosIntegration.Service.Adyen.Paypal
{
    public class PaypalPosService : IFetchRedirectionUrlPostService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PaypalPosService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<RedirectUrlResponse> FetchRedirectionUrlAsync(RedirectUrlRequest request)
        {
            try
            {
                var postResponse = await PostAsync<RedirectUrlRequest, RedirectUrlResponse>("sofort/redirection/url", request);
                return new RedirectUrlResponse(postResponse.Response.Url,
                    postResponse.Response.RawBody);
            }
            catch (System.Exception e)
            {
                throw new PosException(
                    $"Error occurred when getting payment redirect url for sofort, ReferenceId:{request.ReferenceNumber}. Message: {e.Message}",
                    e);
            }
        }

        private async Task<PostResponse<TResponse>> PostAsync<TRequest, TResponse>(string url, TRequest request)
        {
            var body = JsonSerializer.Serialize(request);
            var httpClient = _httpClientFactory.CreateClient("adven");
            var httpResponse =
                await httpClient.PostAsync(url, new StringContent(body, Encoding.UTF8, "application/json"));
            httpResponse.EnsureSuccessStatusCode();
            var responseData = await httpResponse.Content.ReadAsStringAsync();
            var postResponse = JsonSerializer.Deserialize<PostResponse<TResponse>>(responseData);
            return postResponse;
        }

    }
}
