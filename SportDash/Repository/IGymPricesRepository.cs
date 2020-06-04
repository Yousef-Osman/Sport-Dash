using SportDash.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public interface IGymPricesRepository
    {
        Task AddOrEditPricePerPeriod(GymPrices gymPrices);
        //Task AddPerDayPrice(string gymId, GymPrices gymPrices);
        //Task AddPerMonthPrice(string gymId, GymPrices gymPrices);
        //Task AddPerWeekPrice(string gymId, GymPrices gymPrices);
        //Task AddPerYearPrice(string gymId, GymPrices gymPrices);
        Task<bool> Commit();
        Task<IEnumerable<GymPrices>> PricesOfAGym(string gymId);
    }
}