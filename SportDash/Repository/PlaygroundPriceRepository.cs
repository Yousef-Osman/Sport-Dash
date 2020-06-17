using Microsoft.EntityFrameworkCore;
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

        public int AddPlaygroundPrice(PlaygroundPrice NewPlaygroundPrice)
        {
            //PlaygroundPrice FoundplaygroundPrice = SearchPlaygroundPrice(NewPlaygroundPrice);
            //if (FoundplaygroundPrice == null)
            //{
            //try
            //{
                _applicationDbContext.playgroundPrices.Add(NewPlaygroundPrice);
                _applicationDbContext.SaveChanges();
                return NewPlaygroundPrice.Id;

            //}
            //catch (Exception)
            //{
            //    return false;
            //}
            

            //}
            //else
            //{
            //    return false;
            //}
        }

        private PlaygroundPrice SearchPlaygroundPrice(int Id)
        {
            return _applicationDbContext.playgroundPrices.Where(playgroundprice => playgroundprice.Id == Id).FirstOrDefault();
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

        public bool DeletePlaygroundPrice(int id)
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

        public bool UpdatePlaygroundPrice(int Id, PlaygroundPrice newPlaygroundPrice)
        {
            PlaygroundPrice FoundplaygroundPrice = SearchPlaygroundPrice(Id);
            if (FoundplaygroundPrice != null)
            {
                FoundplaygroundPrice.Price = newPlaygroundPrice.Price;
                FoundplaygroundPrice.Start = newPlaygroundPrice.Start;
                FoundplaygroundPrice.End = newPlaygroundPrice.End;

                _applicationDbContext.Entry(FoundplaygroundPrice).State = EntityState.Modified;
                _applicationDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<PlaygroundPrice> GetByPlayground(string playgroundId)
        {
            return _applicationDbContext.playgroundPrices.Where(
                playgroundprice => playgroundprice.PlaygroundId == playgroundId).ToList();
        }

        public List<PlaygroundPrice> GetConflictedList(PlaygroundPrice newPlaygroundPrice)
        {
            List<PlaygroundPrice> prices = _applicationDbContext.playgroundPrices.Where(playgroundPrice =>
            ((((playgroundPrice.Start < newPlaygroundPrice.Start) && (playgroundPrice.End > newPlaygroundPrice.Start)) ||
             ((playgroundPrice.Start < newPlaygroundPrice.End) && (playgroundPrice.End > newPlaygroundPrice.End)) ||
             ((playgroundPrice.Start >= newPlaygroundPrice.Start) && (playgroundPrice.End <= newPlaygroundPrice.End))
            ) && (playgroundPrice.PlaygroundId == newPlaygroundPrice.PlaygroundId))).ToList();
            return prices;
        }
    }
}
