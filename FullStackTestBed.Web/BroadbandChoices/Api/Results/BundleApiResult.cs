using System.Collections.Generic;
using FullStackTestBed.Web.BroadbandChoices.Model;

namespace FullStackTestBed.Web.BroadbandChoices.Api.Results
{
    public class BundleApiResult : ApiResult
    {
        public IList<Bundle> Bundles { get; set; }
    }
}