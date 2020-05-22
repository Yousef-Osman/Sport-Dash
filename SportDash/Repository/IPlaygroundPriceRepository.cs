using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    interface IPlaygroundPriceRepository
    {
        public PlaygroundPrice GetOne(string playgroundId, TimeSpan start, TimeSpan end);
        public List<PlaygroundPrice> GetAPlaygroundPrices(string playgroundId);
        public List<PlaygroundPrice> GetAll();
        public bool AddPlaygroundPrice(PlaygroundPrice playgroundPrice);
        public bool UpdatePlaygroundPrice(PlaygroundPrice playgroundPrice, string id);
        public bool DeletePlaygroundPrice(string id);
    }
}
