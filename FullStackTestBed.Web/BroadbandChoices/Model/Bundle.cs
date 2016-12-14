using System.Collections.Generic;

namespace FullStackTestBed.Web.BroadbandChoices.Model
{
    public class Bundle
    {
        public string bundleType { get; set; }
        public int bundleId { get; set; }
        public int providerId { get; set; }
        public string providerName { get; set; }
        public string providerLogoUrl { get; set; }
        public double customerSatisfactionRating { get; set; }
        public int customerSatisfactionNumberOfReviews { get; set; }
        public string name { get; set; }
        public int contractLength { get; set; }
        public string contractLengthDisplay { get; set; }
        public int downloadLimit { get; set; }
        public string downloadLimitDisplay { get; set; }
        public int downloadSpeed { get; set; }
        public string downloadSpeedDisplay { get; set; }
        public int channelCount { get; set; }
        public int calls { get; set; }
        public string callsDisplay { get; set; }
        public string offerImage { get; set; }
        public string offerExpiryDate { get; set; }
        public string offerEndNote { get; set; }
        public string telephoneNumber { get; set; }
        public string linkTrackerUrl { get; set; }
        public string linkTrackerId { get; set; }
        public string displaySpeed { get; set; }
        public string offerTypeImage { get; set; }
        public CostsWithoutLineRental costsWithoutLineRental { get; set; }
        public CostsWithLineRental costsWithLineRental { get; set; }
        public string unlimitedCalls { get; set; }
        public string extras { get; set; }
        public string includesFreeCallsToLandlines { get; set; }
        public string includesFreeCallsToMobiles { get; set; }
        public List<string> dealTypes { get; set; }
    }
}