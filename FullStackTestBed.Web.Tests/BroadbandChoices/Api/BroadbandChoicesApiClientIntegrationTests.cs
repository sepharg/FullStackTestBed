using System.Threading.Tasks;
using FullStackTestBed.Web.BroadbandChoices.Api;
using FullStackTestBed.Web.BroadbandChoices.Api.Infrastructure;
using NUnit.Framework;

namespace FullStackTestBed.Web.Tests.BroadbandChoices.Api
{
    [TestFixture]
    public class BroadbandChoicesApiClientIntegrationTests
    {
        [Test]
        public async Task GivenCorrectApiKeyAndUrl_WhenApiIsCalled_ThenResultsAreReturned()
        {
            var sut = GetRealClient();

            var bundleApiResult = await sut.GetBundlesAsync();

            Assert.IsNotNull(bundleApiResult);
            Assert.AreEqual(ResponseCode.Success, bundleApiResult.ResponseCode);
            Assert.That(() => bundleApiResult.Bundles.Count > 0);
        }

        private IBroadbandChoicesApiClient GetRealClient()
        {
            var client = new BroadbandChoicesApiClient(new ApiConfiguration(), new HttpClientFactory(), new BundleResponseDeserializer());
            return client;
        }
    }
}
