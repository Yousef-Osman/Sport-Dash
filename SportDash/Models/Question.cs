using SportDash.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Models
{
    public enum QuestionAbout
    {
        Club = 0,
        Playground = 1,
        gym = 2,
        Trainer = 3,
        TrainingProgram = 4,
        Others = 5
    }
    public class Question
    {
        [Key]
        public int Id { get; set; }
        //Ask about (Category ex..Clubs , Playgrounds , etc..)
        public QuestionAbout Category { get; set; }
        public string Body { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public List<Comment> Comments { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}