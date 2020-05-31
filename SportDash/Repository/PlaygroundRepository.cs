using Microsoft.EntityFrameworkCore;
using SportDash.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public class PlaygroundRepository : IPlaygroundRepository
    {
        private readonly ApplicationDbContext dbContext;

        public PlaygroundRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ApplicationUser> GetPlayground(string id)
        {
            return await dbContext.Users.FindAsync(id);
        }

        #region Old Code
        //public IEnumerable<ApplicationUser> GetAll()
        //{
        //    return dbContext.Users.Where(u => u.ClubId == null && u.RoleName == "PlaygroundManager").ToList();
        //}

        //public IEnumerable<ApplicationUser> GetPlaygroundsOfClub(string clubId)
        //{
        //    return dbContext.Users.Where(u => u.ClubId == clubId).ToList();
        //}

        //public void Commit()
        //{
        //    dbContext.SaveChanges();
        //}

        //public async Task AssignPlaygroundToClub(string playgroundId, string clubId)
        //{
        //    var playground = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == playgroundId);
        //    playground.ClubId = clubId;
        //    dbContext.Entry(playground).State = EntityState.Modified;
        //    await dbContext.SaveChangesAsync();
        //}

        //public async Task RemovePlaygroundFromClub(string playgroundId)
        //{
        //    var playground = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == playgroundId);
        //    playground.ClubId = null;
        //    dbContext.Entry(playground).State = EntityState.Modified;
        //    await dbContext.SaveChangesAsync();
        //}
        #endregion
    }
}
