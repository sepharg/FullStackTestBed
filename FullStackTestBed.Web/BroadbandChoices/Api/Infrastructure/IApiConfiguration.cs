namespace FullStackTestBed.Web.BroadbandChoices.Api.Infrastructure
{
    public interface IApiConfiguration
    {
        string ApiKey { get; set; }

        string BaseUrl { get; set; }
    }
}