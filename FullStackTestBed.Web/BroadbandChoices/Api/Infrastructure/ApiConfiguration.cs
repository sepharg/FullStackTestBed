namespace FullStackTestBed.Web.BroadbandChoices.Api.Infrastructure
{
    public class ApiConfiguration : IApiConfiguration
    {
        public ApiConfiguration()
        {
            ApiKey = "eb45afb3-a7c2-4d6d-a62a-bb9a29a4fb2e";
            BaseUrl = "http://api.broadbandchoices.co.uk/";
        }

        public string ApiKey { get; set; }
        public string BaseUrl { get; set; }
    }
}