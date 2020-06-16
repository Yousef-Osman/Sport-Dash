using SportDash.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public interface IGymPricesRepository
    {
        Task AddOrEditPricePerPeriod(GymPrices gymPrices);

        Task<bool> Commit();
        Task<IEnumerable<GymPrices>> PricesOfAGym(string gymId);
    }
}