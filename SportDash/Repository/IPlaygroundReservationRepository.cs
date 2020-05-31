using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public interface IPlaygroundReservationRepository
    {
        public Task<bool> AddPlaygroundReservation(PlaygroundReservation playgroundReservation);
        public Task<PlaygroundReservation> GetOne(string id);
        public Task<List<PlaygroundReservation>> GetByPlayground(string id);
        public Task<List<PlaygroundReservation>> GetAll();
        public bool RemovePlaygroundReservation(string id);
        public bool UpdatePlaygroundReservation(PlaygroundReservation playgroundReservation,string id);
    }
}
