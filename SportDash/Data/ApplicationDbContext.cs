
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportDash.Models;

namespace SportDash.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {            
        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Image> Images { get; set; }        
        public DbSet<TrainingProgram> TrainingPrograms { get; set; }
        public DbSet<GymPrices> GymPrices { get; set; }
        public DbSet<PlaygroundPrice> playgroundPrices { get; set; }
        public DbSet<PlaygroundReservation> playgroundReservations { get; set; }
        public DbSet<ConnectedUser> ConnectedUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "ClubManager", NormalizedName = "CLUBMANAGER" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "PlaygroundManager", NormalizedName = "PLAYGROUNDMANAGER" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "GymManager", NormalizedName = "GYMMANAGER" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Coach", NormalizedName = "COACH" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "NormalUser", NormalizedName = "NORMALUSER" });
            //builder.Entity<ApplicationUser>().HasData(new ApplicationUser { });
            
        }
    }
}
