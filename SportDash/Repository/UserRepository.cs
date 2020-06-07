using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public ApplicationUser GetApplicationUser(string id)
        {
            var user = _context.Users.SingleOrDefault(i => i.Id == id);
            return user;
        }

        public ApplicationUser GetUserById(string id)
        {
            return _context.Users.Find(id);
        }

        public void ChangeMsgsStatus(ApplicationUser reciever, bool value)
        {
            reciever.HasNewMsgs = value;
            _context.Entry(reciever).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
