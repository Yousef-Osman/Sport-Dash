using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportDash.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Data
{    
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string FullName { get; set; }        
        public GamesCategory? SportType { get; set; }     
        public string Category { get; set; }
        public string Address { get; set; }

        public List<Question> Questions { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Message> SenderMessages { get; set; }
        public List<Message> ReceiverMessages { get; set; }
        public List<Review> ReviewerReviews { get; set; }
        public List<Review> TargetReviews { get; set; }
        public List<TrainingProgram> TrainingPrograms { get; set; }
        public List<GymPrices> GymPrices { get; set; }
        public List<Image> Images { get; set; }        
        public List<PlaygroundPrice> PlaygroundPrices { get; set; }
    }
}
