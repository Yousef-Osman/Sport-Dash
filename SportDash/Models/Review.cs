using SportDash.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Models
{
    public enum Rating
    {
        Bad = 0,
        Nice = 1,
        Good = 2,
        VeryGood = 3,
        Excellent = 4,
        Perfect = 5     
    }
    public class Review
    {
        [Key]
        public int Review_Id { get; set; }

        [ForeignKey(nameof(User))]
        public String Reviewer_Id { get; set; }
        [ForeignKey(nameof(Target))]
        public String Reviewee_Id { get; set; }

        public Rating Rating { get; set; }

        public DateTime Review_Date { get; set; }
        public string Comment { get; set; }
        public ApplicationUser User { get; set; }
        public ApplicationUser Target { get; set; }
    }
}
