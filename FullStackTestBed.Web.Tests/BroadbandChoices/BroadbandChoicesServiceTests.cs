using System.Collections.Generic;
using System.Threading.Tasks;
using FullStackTestBed.Web.BroadbandChoices;
using FullStackTestBed.Web.BroadbandChoices.Api;
using FullStackTestBed.Web.BroadbandChoices.Api.Results;
using FullStackTestBed.Web.BroadbandChoices.Model;
using Moq;
using NUnit.Framework;

namespace FullStackTestBed.Web.Tests.BroadbandChoices
{
    [TestFixture]
    public class BroadbandChoicesServiceTests
    {
        private Mock<IBroadbandChoicesApiClient> _broadbandChoicesApiClientMock;

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            _broadbandChoicesApiClientMock = new Mock<IBroadbandChoicesApiClient>();
        }

        [Test]
        public async Task GivenSeveralBundlesAreReturnedFromApi_FirstOneIsDisplayed()
        {
            _broadbandChoicesApiClientMock.Setup(x => x.GetBundlesAsync())
                .Returns(Task.FromResult(new BundleApiResult()
                {
                    Bundles = new List<Bundle>()
                    {
                        new Bundle() {bundleId = 4},
                        new Bundle() {bundleId = 11}
                    }
                }));

            var sut = GetService();

            var purchasedDeal = await sut.GetPurchasedDealAsync(0);

            Assert.AreEqual(4, purchasedDeal.bundleId);
        }

        private IBroadbandChoicesService GetService()
        {
            return new BroadbandChoicesService(_broadbandChoicesApiClientMock.Object);
        }
    }
}
