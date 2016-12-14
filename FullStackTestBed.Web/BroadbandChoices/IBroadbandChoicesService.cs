using System.Threading.Tasks;
using FullStackTestBed.Web.BroadbandChoices.Model;

namespace FullStackTestBed.Web.BroadbandChoices
{
    public interface IBroadbandChoicesService
    {
        /// <summary>
        /// The service should return a presentation DTO called i.e. "Deal" and let an injected dependency do the mapping between Bundle and Deal.
        /// Due to time constraints the Bundle class will be uses throughout.
        /// </summary>
        /// <param name="userId">In a full solution the user id would be used to filter the available bundles and return the only the one purchased by him/her.</param>
        /// <returns></returns>
        Task<Bundle> GetPurchasedDealAsync(int userId);
    }
}