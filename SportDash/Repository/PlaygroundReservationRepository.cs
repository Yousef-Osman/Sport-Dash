using Microsoft.EntityFrameworkCore;
using SportDash.Data;
using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public class PlaygroundReservationRepository : IPlaygroundReservationRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PlaygroundReservationRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }

        public async Task<List<PlaygroundReservation>> GetByPlayground(string id)
        {
            return await _applicationDbContext.playgroundReservations.Where(
                playgroundRes => playgroundRes.PlaygroundId == id).ToListAsync();
        }
        public async Task<bool> AddPlaygroundReservation(PlaygroundReservation playgroundReservation)
        {
            PlaygroundReservation FoundplaygroundReservation = await _applicationDbContext.playgroundReservations.FindAsync(playgroundReservation.PlaygroundId);
            if (FoundplaygroundReservation == null)
            {
                await _applicationDbContext.playgroundReservations.AddAsync(playgroundReservation);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<PlaygroundReservation> GetOne(string id)
        {
            return await _applicationDbContext.playgroundReservations.FindAsync(id);
        }

        public async Task<List<PlaygroundReservation>> GetAll()
        {
            return await _applicationDbContext.playgroundReservations.ToListAsync();
        }


        public bool RemovePlaygroundReservation(string id)
        {
            PlaygroundReservation playgroundReservation = _applicationDbContext.playgroundReservations.Find(id);
            if (playgroundReservation != null)
            {
                _applicationDbContext.playgroundReservations.Remove(playgroundReservation);
                _applicationDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdatePlaygroundReservation(PlaygroundReservation NewplaygroundReservation, string id)
        {
            PlaygroundReservation foundplaygroundReservation = _applicationDbContext.playgroundReservations.Find(id);
            if (foundplaygroundReservation != null)
            {
                foundplaygroundReservation = NewplaygroundReservation;
                _applicationDbContext.playgroundReservations.Update(foundplaygroundReservation);
                _applicationDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
