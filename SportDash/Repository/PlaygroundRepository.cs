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
    }
}
