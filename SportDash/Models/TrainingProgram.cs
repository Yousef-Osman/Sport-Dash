using SportDash.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Models
{
    public enum GamesCategory
    {
        FootBall = 0,
        BasketBall = 1,
        VolleyBall = 2,
        Tennis = 3,
        Others = 4
    }

    public class TrainingProgram
    {
        [Key]
        public int Id { get; set; }
        public GamesCategory Category { get; set; }
        public double Price { get; set; }

        public DateTime TrainingDate { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }


        [Required]
        public string Trainer_Name { get; set; }
        public bool ForLadies { get; set; }

        [ForeignKey(nameof(Club))]
        public int ClubId { get; set; }
        public ApplicationUser Club { get; set; }
    }

}
