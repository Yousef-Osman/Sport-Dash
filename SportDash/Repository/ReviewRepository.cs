using Microsoft.EntityFrameworkCore;
using SportDash.Data;
using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;    
        }


        // get specific Review 
        public Review GetReview(int Id)
        {
            return _context.Reviews.FirstOrDefault(r => r.Id == Id);
        }

        // get all reviews of this user ex: Trainer's Reviews
        public IEnumerable<Review> GetReviewsOfReviewee(string User_Id)
        {
            return _context.Reviews.Include(a=>a.Reviewer).Where(r => r.TargetId == User_Id ).ToList();
        }

        // get all reviews of all user
        public IEnumerable<Review> GetAllReviews(string)
        {
            return _context.Reviews.Include(a => a.Reviewer).ToList();
        }

        public Review PostReview(Review r)
        {
            _context.Reviews.Add(r);
            _context.SaveChanges();
            return r;
        }
    }
}
