using System.Net.Http;
using FullStackTestBed.Web.BroadbandChoices.Api.Infrastructure;

namespace FullStackTestBed.Web.Tests.BroadbandChoices.Api
{
    public class FakeHttpClientFactory : IHttpClientFactory
    {
        private readonly HttpMessageHandler _httpMessageHandler;

        public FakeHttpClientFactory(HttpMessageHandler httpMessageHandler)
        {
            _httpMessageHandler = httpMessageHandler;
        }

        public HttpClient GetClient()
        {
            return new HttpClient(_httpMessageHandler);
        }
    }
}
