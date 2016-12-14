using FullStackTestBed.Web.BroadbandChoices.Model;
using Newtonsoft.Json;

namespace FullStackTestBed.Web.BroadbandChoices.Api.Infrastructure
{
    public class BundleResponseDeserializer : IBundleResponseDeserializer
    {
        public BundleInformationResult Deserialise(string jsonResponse)
        {
            var bundleInformationResult = JsonConvert.DeserializeObject<BundleInformationResult>(jsonResponse);

            return bundleInformationResult;
        }
    }
}