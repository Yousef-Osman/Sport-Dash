using Microsoft.AspNetCore.Identity;
using SportDash.Data;
using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.ViewModels
{
    public class ReviewViewModel
    {
        public IEnumerable<Review> Reviews { get; set; }
        public ApplicationUser User { get; set; }
        public Review Review { get; set; }
        public  string ControllerName { get; set; }
        public string CurrentUser { get; set; }
    }
}
