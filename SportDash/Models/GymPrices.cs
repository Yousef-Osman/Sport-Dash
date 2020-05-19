using SportDash.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Models
{
    public enum Subscribtion_type
    {
        Day = 0,
        Week = 1,
        Month = 2,
        Year = 3
    }

    public class GymPrices
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Gym))]
        public int GymId { get; set; }
        public double Subscribtion_Price { get; set; }
        public Subscribtion_type Subscribtion_Type { get; set; }
        public ApplicationUser Gym { get; set; }
    }

}
