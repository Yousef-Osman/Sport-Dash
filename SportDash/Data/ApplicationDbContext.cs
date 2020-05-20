using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportDash.Models;

namespace SportDash.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
         public DbSet<Message> Messages { get; set; }
         public DbSet<Review> Reviews { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
