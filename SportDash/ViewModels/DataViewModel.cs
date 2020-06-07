using Microsoft.AspNetCore.Mvc.Rendering;
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
        public bool IsAdmin { get; set; }
        public string ControllerName { get; set; }
        public Review Review { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public IEnumerable<PlaygroundReservation> Reservations { get; set; }
        public IEnumerable<PlaygroundReservation> Requests { get; set; }
        public IEnumerable<PlaygroundReservation> AllReservations { get; set; }
        public IEnumerable<PlaygroundPrice> PlaygroundPrices { get; set; }
    }
}
