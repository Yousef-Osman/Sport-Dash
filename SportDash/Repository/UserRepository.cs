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

        public ApplicationUser EditApplicationUser(ApplicationUser user, ApplicationUser infoData)
        {
            user.biography = infoData.biography ?? user.biography;
            user.Location = infoData.Location ?? user.Location;
            user.BallRenting = infoData.BallRenting ?? user.BallRenting;
            user.LockerRoom = infoData.LockerRoom ?? user.LockerRoom;
            user.Toilet = infoData.Toilet ?? user.Toilet;
            user.ForLadies = infoData.ForLadies ?? user.ForLadies;

            _context.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}
