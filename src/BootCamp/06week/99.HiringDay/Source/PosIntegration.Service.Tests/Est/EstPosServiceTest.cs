using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PosIntegration.Model;
using PosIntegration.Model.Auth;
using PosIntegration.Model.Refund;
using PosIntegration.Service.Est;
using PosIntegration.Service.Est.Model;
using PosIntegration.Service.Tests.Utils;

namespace PosIntegration.Service.Tests.Est
{
    public class EstPosServiceTest
    {
        [Test]
        public async Task Refund_When_Successfully()
        {
            var request = new Mock<RefundRequest>();
            var estRefundResponse = new EstRefundResponse
            {
                Response = "[refund-ok]",
                Message = "OK",
                ErrorCode = ""
            };
            var postResponse = new PostResponse<EstRefundResponse>
            {
                Response = estRefundResponse
            };
            var clientFactoryMock =
                HttpClientFactoryFixture.SetupMockHttpClientFactoryWithPostResponse("est", postResponse);

            var posService = new EstPosService(clientFactoryMock.Object);

            var refundResponse = await posService.RefundAsync(request.Object);

            Assert.AreEqual(refundResponse.IsSuccess, estRefundResponse.IsSuccess());
            Assert.AreEqual(refundResponse.ResultMessage, estRefundResponse.Message);
        }

        [Test]
        public async Task Auth_When_Successfully()
        {
            var request = new Mock<AuthRequest>();
            var estAuthResponse = new EstAuthResponse
            {
                Response = "Approved",
                AuthCode = "00",
                OrderId = "123"
            };
            var postResponse = new PostResponse<EstAuthResponse>
            {
                Response = estAuthResponse
            };

            var clientFactoryMock =
                HttpClientFactoryFixture.SetupMockHttpClientFactoryWithPostResponse("est", postResponse);

            var posService = new EstPosService(clientFactoryMock.Object);

            var response = await posService.AuthAsync(request.Object);

            Assert.IsTrue(response.IsSuccess);
            Assert.AreEqual(response.AuthCode, estAuthResponse.AuthCode);
        }
    }
}