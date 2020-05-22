using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SportDash.Data;

namespace SportDash.Models
{
    public class PlaygroundPrice
    {
        //[Key, Column(Order = 0)]
        [ForeignKey(nameof(Playground))]
        public String PlaygroundId { get; set; }

        public Double Price { get; set; }

        //[Key, Column(Order = 1)]
        public TimeSpan Start { get; set; }
        
        //[Key, Column(Order = 2)]
        public TimeSpan End { get; set; }
        
        public ApplicationUser Playground { get; set; }

    }
}
