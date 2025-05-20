using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.Data.Models;
using YardBooking.DAL.temp;

namespace YardBooking.DAL.Data
{
    public class YardBookingContext : DbContext
    {
        public YardBookingContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .OwnsOne(u => u.Location);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Yards)
                .WithOne(y => y.User)
                .HasForeignKey(y => y.YardID)
                .OnDelete(DeleteBehavior.Cascade);
            // Existing configurations
            base.OnModelCreating(modelBuilder);

            // Add your new configurations
            modelBuilder.Entity<Yard>()
                .HasKey(y => y.YardID);

            // If you need to store YardPhotos as JSON
            modelBuilder.Entity<Yard>()
                .Property(y => y.YardPhotos)
                .HasConversion(
                    v => System.Text.Json.JsonSerializer.Serialize(v, null),
                    v => string.IsNullOrEmpty(v) ? new List<string>() :
                         System.Text.Json.JsonSerializer.Deserialize<List<string>>(v, null)

            //// yard and schedule
            //modelBuilder.Entity<Yard>()
            //    .HasMany(y => y.Schedules)
            //    .WithOne(s => s.Yard)
            //    .HasForeignKey(s => s.YardID)
            //    .OnDelete(DeleteBehavior.Cascade);

                    //// yard and booking
                    //modelBuilder.Entity<Yard>()
                    //    .HasMany(y => y.Bookings)
                    //    .WithOne(b => b.Yard)
                    //    .HasForeignKey(b => b.YardID)
                    //    .OnDelete(DeleteBehavior.Cascade);

                    //// user and booking
                    //modelBuilder.Entity<User>()
                    //    .HasMany(u => u.Bookings)
                    //    .WithOne(b => b.User)
                    //    .HasForeignKey(b => b.UserID)
                    //    .OnDelete(DeleteBehavior.Cascade);

                    //// teammembers and team
                    //modelBuilder.Entity<Team>()
                    //    .HasMany(t => t.TeamMember)
                    //    .WithOne(tm => tm.Team)
                    //    .HasForeignKey(tm => tm.TeamID)
                    //    .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Yard> Yards { get; set; }
        //public DbSet<Booking> Bookings { get; set; }
        //public DbSet<Payment> Payments { get; set; }
        //public DbSet<Schedule> Schedules { get; set; }
        //public DbSet<Team> Teams { get; set; }
        //public DbSet<TeamMember> TeamMembers { get; set; }
        //public DbSet<TeamBooking> TeamBookings { get; set; }
        //public DbSet<Offer> Offers { get; set; }
    }
}
