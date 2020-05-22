using SportDash.Data;
using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public class PlaygroundPriceRepository : IPlaygroundPriceRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PlaygroundPriceRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }

        public bool AddPlaygroundPrice(PlaygroundPrice NewplaygroundPrice)
        {
            PlaygroundPrice FoundplaygroundPrice = _applicationDbContext.playgroundPrices.Where(playgroundprice => playgroundprice.PlaygroundId == NewplaygroundPrice.PlaygroundId && playgroundprice.Start == NewplaygroundPrice.Start && playgroundprice.End == NewplaygroundPrice.End).FirstOrDefault();
            if (FoundplaygroundPrice == null)
            {
                _applicationDbContext.playgroundPrices.Add(NewplaygroundPrice);
                _applicationDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public PlaygroundPrice GetOne(string playgroundId, TimeSpan start, TimeSpan end)
        {
            PlaygroundPrice playgroundPrice = _applicationDbContext.playgroundPrices.Where(playgroundprice => playgroundprice.PlaygroundId == playgroundId && playgroundprice.Start == start && playgroundprice.End == end).FirstOrDefault();
            return playgroundPrice;
        }
        public List<PlaygroundPrice> GetAPlaygroundPrices(string playgroundId)
        {
            List<PlaygroundPrice> playground_Prices = _applicationDbContext.playgroundPrices.Where(playgroundprice => playgroundprice.PlaygroundId == playgroundId).ToList();
            return playground_Prices;
        }

        public List<PlaygroundPrice> GetAll()
        {
            return _applicationDbContext.playgroundPrices.ToList();
        }

        public bool DeletePlaygroundPrice(string id)
        {
            PlaygroundPrice FoundplaygroundPrice = _applicationDbContext.playgroundPrices.Find(id);

            if (FoundplaygroundPrice != null)
            {
                _applicationDbContext.playgroundPrices.Remove(FoundplaygroundPrice);
                _applicationDbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public bool UpdatePlaygroundPrice(PlaygroundPrice playgroundPrice, string id)
        {
            PlaygroundPrice FoundplaygroundPrice = _applicationDbContext.playgroundPrices.Find(id);

            if (FoundplaygroundPrice != null)
            {
                FoundplaygroundPrice = playgroundPrice;
                _applicationDbContext.playgroundPrices.Update(FoundplaygroundPrice);
                _applicationDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
