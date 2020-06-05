using Microsoft.EntityFrameworkCore;
using SportDash.Data;
using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public class ConnectedUsersRepository : IConnectedUsersRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ConnectedUsersRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ConnectedUser GetConnectionIdOfUser(string userId)
        {
            return _dbContext.ConnectedUsers.FirstOrDefault(c => c.UserId == userId);
        }
    }
}
