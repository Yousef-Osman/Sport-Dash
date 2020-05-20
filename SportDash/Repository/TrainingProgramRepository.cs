using Microsoft.EntityFrameworkCore;
using SportDash.Data;
using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public class TrainingProgramRepository : ITrainingProgramRepository
    {
        private readonly ApplicationDbContext _context;

        public TrainingProgramRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        #region CRUD Operations
        public Task Add(TrainingProgram trainingProgram)
        {            
            _context.TrainingPrograms.Add(trainingProgram);
            return Task.FromResult(0);
        }

        public async Task<IEnumerable<TrainingProgram>> GetAll()
        {
            return await _context.TrainingPrograms.ToListAsync();
        }

        public async Task<TrainingProgram> GetOne(int id)
        {
            return await _context.TrainingPrograms.FindAsync(id);
        }

        public async Task<bool> Commit()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public Task Delete(TrainingProgram trainingProgram)
        {
            _context.TrainingPrograms.Remove(trainingProgram);
            _context.Entry(trainingProgram).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            return Task.FromResult(0);
        }        

        public Task Edit(TrainingProgram trainingProgram)
        {
            _context.Attach(trainingProgram);
            _context.Entry(trainingProgram).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return Task.FromResult(0);
        }
        #endregion

        #region Filteration methods
        public async Task<IEnumerable<TrainingProgram>> FilterByCategory(GamesCategory category)
        {
            return await _context.TrainingPrograms.Where(tp => tp.Category == category).ToListAsync();
        }

        public async Task<IEnumerable<TrainingProgram>> FilterByForLadies(bool forLadies)
        {
            return await _context.TrainingPrograms.Where(tp => tp.ForLadies == forLadies).ToListAsync();
        }

        public async Task<IEnumerable<TrainingProgram>> FilterByPrice(double fromPrice, double toPrice)
        {
            return await _context.TrainingPrograms.Where(tp => tp.Price >= fromPrice && tp.Price <= toPrice).ToListAsync();
        }

        public async Task<IEnumerable<TrainingProgram>> FilterByTrainerName(string trainerName)
        {
            return await _context.TrainingPrograms.Where(tp => tp.Trainer_Name.Contains(trainerName)).ToListAsync();
        }
        #endregion        
    }
}
