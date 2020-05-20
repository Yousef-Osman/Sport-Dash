using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Repository
{
   public interface IReview
    {
        public IEnumerable<Review> GetReviewsOfReviewee(String User_Id);
        public Review GetReview(int id);
        public Review PostReview(Review r);
        //public Review PutReview(int id);
        //public void DeleteMessage(int id);
    }
}
