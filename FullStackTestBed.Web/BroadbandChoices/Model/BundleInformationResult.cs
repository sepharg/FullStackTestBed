using System.Collections.Generic;

namespace FullStackTestBed.Web.BroadbandChoices.Model
{
    public class BundleInformationResult
    {
        public string timeStamp { get; set; }
        public int errorCode { get; set; }
        public string postcode { get; set; }
        public int totalBundles { get; set; }
        public List<Bundle> bundleList { get; set; }
    }
}