using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PosIntegration.Model;
using PosIntegration.Model.RedirectUrl;
using PosIntegration.Model.Refund;
using PosIntegration.Service.Adyen.Model;
using PosIntegration.Service.Adyen.Sofort;
using PosIntegration.Service.Tests.Utils;

namespace PosIntegration.Service.Tests.Adyen.Sofort
{
    public class SofortPosServiceTest
    {
        [Test]
        public async Task Refund_When_Successfully()
        {
            var request = new Mock<RefundRequest>();
            var adyenRefundResponse = new AdyenRefundResponse
            {
                Response = "[refund-received]",
                Message = "OK",
                PspReference = "1234",
                ErrorCode = ""
            };
            var postResponse = new PostResponse<AdyenRefundResponse>
            {
                Response = adyenRefundResponse
            };

            var clientFactoryMock =
                HttpClientFactoryFixture.SetupMockHttpClientFactoryWithPostResponse("adven", postResponse);

            var posService = new SofortPosService(clientFactoryMock.Object);

            var refundResponse = await posService.RefundAsync(request.Object);

            Assert.AreEqual(refundResponse.IsSuccess, adyenRefundResponse.IsSuccess());
            Assert.AreEqual(refundResponse.ResultMessage, adyenRefundResponse.Message);
        }

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

            var posService = new SofortPosService(clientFactoryMock.Object);

            var response = await posService.FetchRedirectionUrlAsync(request.Object);

            Assert.AreEqual(response.Url, redirectUrlResponse.Url);
            Assert.AreEqual(response.RawBody, redirectUrlResponse.RawBody);
        }
    }
}