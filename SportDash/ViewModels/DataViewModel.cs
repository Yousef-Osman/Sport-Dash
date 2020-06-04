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
        public ApplicationUser CurrentUser { get; set; } // +R
        public ApplicationUser Entity { get; set; }
        public bool isCurrentUser { get; set; }
        public string ControllerName { get; set; } // +R
        public IEnumerable<Image> Images { get; set; }

        // Review View Model Properity
        public IEnumerable<Review> Reviews { get; set; } // +R
        public Review Review { get; set; } // +R

        // Search View Model
        public List<ApplicationUser> Gyms { get; set; }  
        public List<ApplicationUser> Playgrounds { get; set; }
        public List<ApplicationUser> Trainers { get; set; }
        public List<SelectListItem> Category { get; set; }
        public List<SelectListItem> Price { get; set; }
        public List<SelectListItem> Location { get; set; }
        public List<SelectListItem> SportType { get; set; }
        public string SearchString { get; set; }
        public string CategoryString { get; set; }
        public string PriceString { get; set; }
        public string LocationString { get; set; }
        public string SportTypeString { get; set; }

        public IEnumerable<PlaygroundReservation> Reservations { get; set; }
        public IEnumerable<PlaygroundReservation> Requests { get; set; }
        public IEnumerable<PlaygroundReservation> AllReservations { get; set; }
        public IEnumerable<PlaygroundPrice> PlaygroundPrices { get; set; }
    }
}
