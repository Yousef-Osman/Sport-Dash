using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public interface IPlaygroundPriceRepository
    {
        //public PlaygroundPrice GetOne(string playgroundId, TimeSpan start, TimeSpan end);
        //public PlaygroundPrice GetOne(string Id);

        public List<PlaygroundPrice> GetAPlaygroundPrices(string playgroundId);
        public List<PlaygroundPrice> GetByPlayground(string playgroundId);
        public List<PlaygroundPrice> GetAll();
        public int AddPlaygroundPrice(PlaygroundPrice playgroundPrice);
        public bool UpdatePlaygroundPrice(int Id, PlaygroundPrice oldPlaygroundPrice);
        public bool DeletePlaygroundPrice(int id);
        public List<PlaygroundPrice> GetConflictedList(PlaygroundPrice playgroundPrice);
    }
}