using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FullStackTestBed.Web.BroadbandChoices.Api.Infrastructure;
using FullStackTestBed.Web.BroadbandChoices.Api.Results;
using FullStackTestBed.Web.BroadbandChoices.Model;

namespace FullStackTestBed.Web.BroadbandChoices.Api
{
    public class BroadbandChoicesApiClient : IBroadbandChoicesApiClient
    {
        private readonly IApiConfiguration _apiConfiguration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IBundleResponseDeserializer _bundleResponseDeserializer;

        public BroadbandChoicesApiClient(IApiConfiguration apiConfiguration, IHttpClientFactory httpClientFactory, IBundleResponseDeserializer bundleResponseDeserializer)
        {
            _apiConfiguration = apiConfiguration;
            _httpClientFactory = httpClientFactory;
            _bundleResponseDeserializer = bundleResponseDeserializer;
        }
        public async Task<BundleApiResult> GetBundlesAsync()
        {
            var requestUri = $"{_apiConfiguration.BaseUrl}/api/v2/bestbuys?Authorization={_apiConfiguration.ApiKey}";
            IList<Bundle> resultBundles;
            try
            {
                using (var httpClient = _httpClientFactory.GetClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var httpResponseMessage = await httpClient.GetAsync(requestUri);
                    if (!httpResponseMessage.IsSuccessStatusCode || httpResponseMessage.Content == null)
                    {
                        return new BundleApiResult() { ResponseCode = ResponseCode.Error };
                    }
                    var responseContents = await httpResponseMessage.Content.ReadAsStringAsync();
                    resultBundles = _bundleResponseDeserializer.Deserialise(responseContents).bundleList;
                }

            }
            catch (Exception)
            {
                // Todo: Log
                return new BundleApiResult() { ResponseCode = ResponseCode.Error };
            }

            return new BundleApiResult() { ResponseCode = ResponseCode.Success, Bundles = resultBundles };
        }
    }
}