using SportDash.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Models
{
    public class PlaygroundReservation
    {
        [Key]
        public String PlaygroundReservationId { get; set; }

        [ForeignKey(nameof(Playground))]
        public String PlaygroundId { get; set; }

        public String Name { get; set; }
        
        public DateTime Date { get; set; }

        public bool IsOccubied { get; set; }
        public ApplicationUser Playground { get; set; }


    }
}
