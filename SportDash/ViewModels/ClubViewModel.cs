using Microsoft.AspNetCore.Mvc.Rendering;
using SportDash.Data;
using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.ViewModels
{
    public class ClubViewModel
    {        
        public string EntityName { get; set; }
        public string EntityId { get; set; }
        public IEnumerable<Image> Images { get; set; }
        //public IEnumerable<PlaygroundReservation> Reservations { get; set; }
        //public IEnumerable<PlaygroundReservation> Requests { get; set; }
        //public IEnumerable<PlaygroundReservation> AllReservations { get; set; }
        public Image Image { get; set; }
        public string ControllerName { get; set; }
    }
}
