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
        public int Id { get; set; }
        [Required]
        public Rating Rating { get; set; }
        public DateTime Review_Date { get; set; }
        public string Comment { get; set; }

        public string ReviewerId { get; set; }
        public string TargetId { get; set; }
        [InverseProperty("ReviewerReviews")]
        public ApplicationUser Reviewer { get; set; }
        public ApplicationUser Target { get; set; }
    }
}
