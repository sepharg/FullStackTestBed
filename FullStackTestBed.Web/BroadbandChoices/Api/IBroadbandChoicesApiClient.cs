using System.Threading.Tasks;
using FullStackTestBed.Web.BroadbandChoices.Api.Results;

namespace FullStackTestBed.Web.BroadbandChoices.Api
{
    public interface IBroadbandChoicesApiClient
    {
        Task<BundleApiResult> GetBundlesAsync();
    }
}