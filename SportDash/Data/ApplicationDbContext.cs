
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
        public DbSet<TrainingProgram> TrainingPrograms { get; set; }
        public DbSet<GymPrices> GymPrices { get; set; }

         public DbSet<Message> Messages { get; set; }
         public DbSet<Review> Reviews { get; set; }

        public DbSet<PlaygroundPrice> playgroundPrices { get; set; }
        public DbSet<PlaygroundReservation> playgroundReservations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PlaygroundPrice>()
                .HasKey(p => new { p.PlaygroundId, p.Start, p.End });
        }
    }
}
