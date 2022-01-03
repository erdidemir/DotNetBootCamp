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
        private readonly HttpService _httpService;

        public PaypalPosService(HttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<RedirectUrlResponse> FetchRedirectionUrlAsync(RedirectUrlRequest request)
        {
            try
            {
                var postResponse = await _httpService.PostAsync<RedirectUrlRequest, RedirectUrlResponse>("redirection/url", request, "adven");
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

    }
}
