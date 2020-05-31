using Microsoft.AspNetCore.Mvc.Rendering;
using SportDash.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.ViewModels
{
    public class SearchViewModel
    {
        public List<ApplicationUser> Gyms { get; set; }
        public List<ApplicationUser> Playgrounds { get; set; }
        public List<ApplicationUser> Trainers { get; set; }
        //public List<ApplicationUser> Clubs { get; set; }
        public List<SelectListItem> Category { get; set; }
        public List<SelectListItem> Price { get; set; }
        public SelectList Location { get; set; }
        public List<SelectListItem> SportType { get; set; }
        public string SearchString { get; set; }
        public string CategoryString { get; set; }
        public string PriceString { get; set; }
        public string LocationString { get; set; }
        public string SportTypeString { get; set; }

    }
}
