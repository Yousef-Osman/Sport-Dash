using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SportDash.Data;

namespace SportDash.Models
{
    public class PlaygroundPrice
    {
        
        //[Key, Column(Order = 0)]
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Playground))]
        public String PlaygroundId { get; set; }

        public Double Price { get; set; }

        //[Key, Column(Order = 1)]
        public TimeSpan Start { get; set; }
        
        //[Key, Column(Order = 2)]
        public TimeSpan End { get; set; }
        [JsonIgnore]
        public ApplicationUser Playground { get; set; }

    }
}
