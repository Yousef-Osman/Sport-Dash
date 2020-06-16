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
        
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Playground))]
        public String PlaygroundId { get; set; }

        public Double Price { get; set; }

        public TimeSpan Start { get; set; }
        
        public TimeSpan End { get; set; }
        [JsonIgnore]
        public ApplicationUser Playground { get; set; }

    }
}
