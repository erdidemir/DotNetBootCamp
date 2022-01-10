using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using PosIntegration.Model;

namespace PosIntegration.Service.Tests.Utils
{
    public static class HttpClientFactoryFixture
    {
        public static Mock<IHttpClientFactory> SetupMockHttpClientFactoryWithPostResponse<T>(string namedService,
            PostResponse<T> response)
        {
            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonSerializer.Serialize(response))
            };
            return SetupMockHttpClientFactory(namedService, httpResponse);
        }

        public static Mock<IHttpClientFactory> SetupMockHttpClientFactory(string namedService,
            HttpResponseMessage responseMessage)
        {
            var clientHandlerMock = new Mock<DelegatingHandler>();
            clientHandlerMock.As<IDisposable>().Setup(s => s.Dispose());

            var httpClient = new HttpClient(clientHandlerMock.Object)
            {
                BaseAddress = new Uri("http://www.acme.org")
            };

            var clientFactoryMock = new Mock<IHttpClientFactory>(MockBehavior.Strict);
            clientFactoryMock.Setup(cf => cf.CreateClient(namedService)).Returns(httpClient).Verifiable();

            clientHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(responseMessage)
                .Verifiable();

            return clientFactoryMock;
        }
    }
}
