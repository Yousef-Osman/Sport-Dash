using SportDash.Data;
using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.ViewModels
{
    public class DataViewModel
    {
        public ApplicationUser CurrentUser { get; set; }
        public ApplicationUser Entity { get; set; }
        public bool isCurrentUser { get; set; }
        public string ControllerName { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public IEnumerable<PlaygroundReservation> Reservations { get; set; }
        public IEnumerable<PlaygroundReservation> Requests { get; set; }
        public IEnumerable<PlaygroundReservation> AllReservations { get; set; }
    }
}
