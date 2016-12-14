using System.Threading.Tasks;
using System.Web.Http;
using FullStackTestBed.Web.BroadbandChoices;
using FullStackTestBed.Web.BroadbandChoices.Api;
using FullStackTestBed.Web.BroadbandChoices.Api.Infrastructure;
using FullStackTestBed.Web.BroadbandChoices.Model;

namespace FullStackTestBed.Web.Controllers
{
    public class BroadbandChoicesController : ApiController
    {
        // ToDo: use an IoC container to construct and build this automatically. Unity, Structuremap, etc
        private readonly IBroadbandChoicesService _broadbandChoicesService = new BroadbandChoicesService(new BroadbandChoicesApiClient(new ApiConfiguration(), new HttpClientFactory(), new BundleResponseDeserializer()));

        /*public BroadbandChoicesController(IBroadbandChoicesService broadbandChoicesService)
        {
            _broadbandChoicesService = broadbandChoicesService;
        }*/

        [HttpGet]
        [Route("api/BroadbandChoices/GetBundleAsync/{userId}")]
        // GET /api/BroadbandChoices/GetBundleAsync/55
        public async Task<Bundle> GetBundleAsync(int userId)
        {
            return await _broadbandChoicesService.GetPurchasedDealAsync(userId);
        }
    }
}
