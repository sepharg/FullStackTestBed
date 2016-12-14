using System.Linq;
using System.Threading.Tasks;
using FullStackTestBed.Web.BroadbandChoices.Api;
using FullStackTestBed.Web.BroadbandChoices.Model;

namespace FullStackTestBed.Web.BroadbandChoices
{
    public class BroadbandChoicesService : IBroadbandChoicesService
    {
        private readonly IBroadbandChoicesApiClient _broadbandChoicesApiClient;
        public BroadbandChoicesService(IBroadbandChoicesApiClient broadbandChoicesApiClient)
        {
            _broadbandChoicesApiClient = broadbandChoicesApiClient;
        }

        public async Task<Bundle> GetPurchasedDealAsync(int userId)
        {
            var bundleApiResult = await _broadbandChoicesApiClient.GetBundlesAsync();
            if (bundleApiResult.ResponseCode != ResponseCode.Success)
            {
                // Todo : Error
            }
            return bundleApiResult.Bundles.First();
        }
    }
}