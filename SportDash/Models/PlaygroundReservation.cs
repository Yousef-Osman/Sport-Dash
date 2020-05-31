using SportDash.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Models
{
    public class PlaygroundReservation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        [ForeignKey(nameof(Playground))]
        public string PlaygroundId { get; set; }

        //Incase ClubManager Reserve outside the Website
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        //status will be {Accepted , Waiting}
        public string Status { get; set; } = "Waiting";

        [InverseProperty("Playgrounds")]
        public virtual ApplicationUser Playground { get; set; }

        [InverseProperty("UserReservations")]
        public virtual ApplicationUser User { get; set; }
    }
}
