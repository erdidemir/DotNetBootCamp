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
using PosIntegration.Service.Est.Model;

namespace PosIntegration.Service.Est
{
    public class EstPosService : IPosService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EstPosService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<RefundResponse> RefundAsync(RefundRequest request)
        {
            try
            {
                var postResponse = await PostAsync<RefundRequest, EstRefundResponse>("refund", request);
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
                    $"Error occurred when refunding transaction, ReferenceId:{request.RefundReferenceNumber}. Message: {e.Message}", e);
            }
        }

        public async Task<AuthResponse> AuthAsync(AuthRequest request)
        {
            try
            {
                var postResponse = await PostAsync<AuthRequest, EstAuthResponse>("auth", request);
                var response = postResponse.Response;
                return new AuthResponse(
                    response.IsSuccess(),
                    response.ProcReturnCode,
                    response.ErrMsg,
                    response.TransactionId,
                    response.RawBody,
                    response.AuthCode,
                    response.HostRefNum
                );
            }
            catch (System.Exception e)
            {
                throw new PosException(
                    $"Error occurred when selling transaction, ReferenceId: {request.ReferenceNumber}. Message: {e.Message}", e);
            }
        }

        private async Task<PostResponse<TResponse>> PostAsync<TRequest, TResponse>(string url, TRequest request)
        {
            var body = JsonSerializer.Serialize(request);
            var httpClient = _httpClientFactory.CreateClient("est");
            var httpResponse = await httpClient.PostAsync(url, new StringContent(body, Encoding.UTF8, "application/json"));
            httpResponse.EnsureSuccessStatusCode();
            var responseData = await httpResponse.Content.ReadAsStringAsync();
            var postResponse = JsonSerializer.Deserialize<PostResponse<TResponse>>(responseData);
            return postResponse;
        }
    }
}