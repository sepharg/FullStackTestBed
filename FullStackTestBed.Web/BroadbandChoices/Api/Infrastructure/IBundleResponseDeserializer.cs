using FullStackTestBed.Web.BroadbandChoices.Model;

namespace FullStackTestBed.Web.BroadbandChoices.Api.Infrastructure
{
    public interface IBundleResponseDeserializer
    {
        BundleInformationResult Deserialise(string jsonResponse);
    }
}
