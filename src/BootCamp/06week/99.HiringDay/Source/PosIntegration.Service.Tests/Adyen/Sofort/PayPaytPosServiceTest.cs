using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PosIntegration.Model;
using PosIntegration.Model.RedirectUrl;
using PosIntegration.Model.Refund;
using PosIntegration.Service.Adyen.Model;
using PosIntegration.Service.Adyen.Paypal;
using PosIntegration.Service.Tests.Utils;

namespace PosIntegration.Service.Tests.Adyen.Paypal
{
    public class PaypalPosServiceTest
    {
        [Test]
        public async Task FetchRedirectionUrl_When_Successfully()
        {
            var request = new Mock<RedirectUrlRequest>();
            var redirectUrlResponse = new RedirectUrlResponse("google.com", "rawbody");
            var postResponse = new PostResponse<RedirectUrlResponse>()
            {
                Response = redirectUrlResponse
            };

            var clientFactoryMock =
                HttpClientFactoryFixture.SetupMockHttpClientFactoryWithPostResponse("adven", postResponse);

            var posService = new PaypalPosService(clientFactoryMock.Object);

            var response = await posService.FetchRedirectionUrlAsync(request.Object);

            Assert.AreEqual(response.Url, redirectUrlResponse.Url);
            Assert.AreEqual(response.RawBody, redirectUrlResponse.RawBody);
        }

    }
}