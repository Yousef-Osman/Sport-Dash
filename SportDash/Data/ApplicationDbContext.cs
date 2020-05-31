
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
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<PlaygroundPrice>()
                .HasKey(p => new { p.PlaygroundId, p.Start, p.End });            
            
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "ClubManager", NormalizedName = "CLUBMANAGER" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "PlaygroundManager", NormalizedName = "PLAYGROUNDMANAGER" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "GymManager", NormalizedName = "GYMMANAGER" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Coach", NormalizedName = "COACH" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "NormalUser", NormalizedName = "NORMALUSER" });

            builder.Entity<PlaygroundReservation>().HasData(
                    new PlaygroundReservation
                    {
                        Id = 1,
                        UserId = "d209032e-026f-4d77-88eb-e8013acfc073",
                        PlaygroundId = "1dc196be-3c4b-435a-8eb5-fffb05ad8a66",
                        Name = "userA",
                        Date = new DateTime(2020, 05, 27),
                        StartTime = new TimeSpan(6, 0, 0),
                        EndTime = new TimeSpan(8, 0, 0),
                        Status = "Waiting"
                    }
                );

            builder.Entity<PlaygroundReservation>().HasData(
                    new PlaygroundReservation
                    {
                        Id = 2,
                        UserId = "d6c31671-bbab-493f-98ed-e79ace5fd968",
                        PlaygroundId = "1dc196be-3c4b-435a-8eb5-fffb05ad8a66",
                        Name = "userB",
                        Date = new DateTime(2020, 05, 27),
                        StartTime = new TimeSpan(8, 0, 0),
                        EndTime = new TimeSpan(10, 0, 0),
                        Status = "Waiting"
                    }
                );

            builder.Entity<PlaygroundReservation>().HasData(
                    new PlaygroundReservation
                    {
                        Id = 3,
                        UserId = "9419da5f-5e00-40bc-8c52-7f591822794f",
                        PlaygroundId = "1dc196be-3c4b-435a-8eb5-fffb05ad8a66",
                        Name = "userC",
                        Date = new DateTime(2020, 05, 29),
                        StartTime = new TimeSpan(8, 0, 0),
                        EndTime = new TimeSpan(10, 0, 0),
                        Status = "Waiting"
                    }
                );
        }
    }
}
