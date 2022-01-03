using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PosIntegration.Exception;
using PosIntegration.Model;
using PosIntegration.Model.Auth;
using PosIntegration.Model.RedirectUrl;
using PosIntegration.Model.Refund;
using PosIntegration.Service.Adyen.Model;

namespace PosIntegration.Service.Adyen.Sofort
{
    public class SofortPosService : IPosService, IFetchRedirectionUrlPostService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SofortPosService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<RefundResponse> RefundAsync(RefundRequest request)
        {
            try
            {
                var postResponse = await PostAsync<RefundRequest, AdyenRefundResponse>("refund", request);
                var response = postResponse.Response;
                return new RefundResponse(
                    response.IsSuccess(),
                    response.ErrorCode,
                    response.Message,
                    null,
                    response.RawBody
                );
            }
            catch (System.Exception e)
            {
                throw new PosException(
                    $"Error occurred when refunding transaction, ReferenceId:{request.RefundReferenceNumber}. Message: {e.Message}",
                    e);
            }
        }

        //Dummy Coding
        public Task<AuthResponse> AuthAsync(AuthRequest request)
        {
            throw new NotSupportedException("Unsupported auth operation for Adyen Sofort Pos");
        }

        public async Task<RedirectUrlResponse> FetchRedirectionUrlAsync(RedirectUrlRequest request)
        {
            try
            {
                var postResponse = await PostAsync<RedirectUrlRequest, RedirectUrlResponse>("redirection/url", request);
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
