using System.Net.Http;

namespace FullStackTestBed.Web.BroadbandChoices.Api.Infrastructure
{
    public interface IHttpClientFactory
    {
        HttpClient GetClient();
    }
}