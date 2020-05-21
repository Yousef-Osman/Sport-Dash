using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public interface ITrainingProgramRepository
    {
        // get all training programs of a specific club
        Task<IEnumerable<TrainingProgram>> GetAll();

        // called when viewing the details of a specific Training Program
        Task<TrainingProgram> GetOne(int id);

        // filtering by <filter> when searching for a training program
        Task<IEnumerable<TrainingProgram>> FilterByCategory(GamesCategory category);
        Task<IEnumerable<TrainingProgram>> FilterByPrice(double fromPrice, double toPrice);
        Task<IEnumerable<TrainingProgram>> FilterByTrainerName(string trainerName);
        Task<IEnumerable<TrainingProgram>> FilterByForLadies(bool forLadies);

        // CRUD Operations
        Task Add(TrainingProgram trainingProgram);

        // saving the data to database and returning if any rows were affected or not
        Task<bool> Commit();
        Task Delete(TrainingProgram trainingProgram);
        Task Edit(TrainingProgram trainingProgram);
    }
}
