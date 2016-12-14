using System.Collections.Generic;

namespace FullStackTestBed.Web.BroadbandChoices.Model
{
    public class CostsWithoutLineRental
    {
        public List<MonthlyCostBreakdown> monthlyCostBreakdown { get; set; }
        public double monthlyCost { get; set; }
        public string monthlyCostDisplay { get; set; }
        public string monthlyCostNote { get; set; }
        public double firstYearCost { get; set; }
        public string firstYearCostDisplay { get; set; }
        public double lineRental { get; set; }
        public object lineRentalDisplay { get; set; }
        public List<CostBreakdown> costBreakdown { get; set; }
        public double upfrontCostAfterOffer { get; set; }
        public string upfrontCostAfterOfferDisplay { get; set; }
        public double monthlyHardwardCost { get; set; }
        public object monthlyHardwardCostDisplay { get; set; }
        public double hardwareCost { get; set; }
        public string hardwareCostDisplay { get; set; }
        public double installationCost { get; set; }
        public string installationCostDisplay { get; set; }
        public double deliveryCost { get; set; }
        public string deliveryCostDisplay { get; set; }
        public double totalContractCost { get; set; }
        public string totalContractCostDisplay { get; set; }
        public double averageMonthlyCost { get; set; }
        public string averageMonthlyCostDisplay { get; set; }
    }
}