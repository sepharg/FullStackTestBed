using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FullStackTestBed.Web.BroadbandChoices.Api;
using FullStackTestBed.Web.BroadbandChoices.Api.Infrastructure;
using FullStackTestBed.Web.BroadbandChoices.Model;
using Moq;
using NUnit.Framework;

namespace FullStackTestBed.Web.Tests.BroadbandChoices.Api
{
    [TestFixture]
    public class BroadbandChoicesApiClientTests
    {
        private Mock<IApiConfiguration> _apiConfigurationMock;
        private Mock<IBundleResponseDeserializer> _bundleResponseDeserializerMock;
        private FakeHttpMessageHandler _fakeHttpMessageHandler;
        private FakeHttpClientFactory _fakeHttpClientFactory;

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            _apiConfigurationMock = new Mock<IApiConfiguration>();
            _apiConfigurationMock.SetupGet(x => x.BaseUrl).Returns("http://fakeaddress.com");
            _bundleResponseDeserializerMock = new Mock<IBundleResponseDeserializer>();
        }

        [Test]
        public async Task GivenNonSuccessStatusCode_ThenReturnsErrorResponseCode()
        {
            var client = GetClient(HttpStatusCode.InternalServerError);

            var result = await client.GetBundlesAsync();

            Assert.AreEqual(ResponseCode.Error, result.ResponseCode);
            Assert.IsNull(result.Bundles);
        }

        [Test]
        public async Task GivenInvalidApiKey_ThenReturnsErrorResponseCode()
        {
            var client = GetClient(HttpStatusCode.BadRequest);

            var result = await client.GetBundlesAsync();

            Assert.AreEqual(ResponseCode.Error, result.ResponseCode);
            Assert.IsNull(result.Bundles);
        }

        [Test]
        public async Task GivenSuccessStatusCode_ThenReturnsSuccessResponseCode_AndExpectedBundles()
        {
            _bundleResponseDeserializerMock.Setup(x => x.Deserialise(It.IsAny<string>()))
                                           .Returns(new BundleInformationResult() { bundleList  = new List<Bundle>() {new Bundle(), new Bundle(), new Bundle()}});
            var client = GetClient(HttpStatusCode.OK);

            var result = await client.GetBundlesAsync();

            Assert.AreEqual(ResponseCode.Success, result.ResponseCode);
            Assert.AreEqual(3, result.Bundles.Count);
        }

        [Test]
        public async Task GivenRealApiIsUsed_WhenCorrectApiKeyIsUsed_ThenReturnsSuccessResponseCode_AndBundleList()
        {
            _bundleResponseDeserializerMock.Setup(x => x.Deserialise(It.IsAny<string>()))
                                           .Returns(new BundleInformationResult() { bundleList = new List<Bundle>() { new Bundle(), new Bundle(), new Bundle() } });
            var client = GetClient(HttpStatusCode.OK);

            var result = await client.GetBundlesAsync();

            Assert.AreEqual(ResponseCode.Success, result.ResponseCode);
            Assert.AreEqual(3, result.Bundles.Count);
        }

        private IBroadbandChoicesApiClient GetClient(HttpStatusCode returnStatusCode)
        {
            _fakeHttpMessageHandler = new FakeHttpMessageHandler(returnStatusCode);
            _fakeHttpClientFactory = new FakeHttpClientFactory(_fakeHttpMessageHandler);

            var client = new BroadbandChoicesApiClient(_apiConfigurationMock.Object, _fakeHttpClientFactory, _bundleResponseDeserializerMock.Object);
            return client;
        }
    }
}
