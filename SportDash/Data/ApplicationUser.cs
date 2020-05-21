using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Data
{
    public class ApplicationUser : IdentityUser
    {
        public List<Question> Questions { get; set; }
        public List<Comment> Comments { get; set; }
        [PersonalData]
        public string FullName { get; set; }
    }
}
