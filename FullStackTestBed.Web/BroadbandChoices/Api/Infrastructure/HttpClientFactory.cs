using System.Net.Http;

namespace FullStackTestBed.Web.BroadbandChoices.Api.Infrastructure
{
    public class HttpClientFactory : IHttpClientFactory
    {
        public HttpClient GetClient()
        {
            return new HttpClient();
        }
    }
}