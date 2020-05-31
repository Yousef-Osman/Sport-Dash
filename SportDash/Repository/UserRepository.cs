using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportDash.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public string GetFullName(string id)
        {
            var user = _context.Users.SingleOrDefault(i => i.Id == id);
            string fullName = user.FullName;
            return fullName;
        }

        public void EditFullName(string id, string newName)
        {
            var user = _context.Users.SingleOrDefault(i => i.Id == id);
            user.FullName = newName;
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}
