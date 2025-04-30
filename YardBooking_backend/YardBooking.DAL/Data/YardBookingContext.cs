using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.Data.Models;

namespace YardBooking.DAL.Data
{
    public class YardBookingContext : IdentityDbContext<ApplicationUser>
    {
        public YardBookingContext(DbContextOptions<YardBookingContext> options) : base(options)
        {
        }

        public DbSet<Yard> Yards { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<TeamBooking> TeamBookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many relationships with composite keys
            modelBuilder.Entity<TeamMember>()
                 .HasKey(tm => new { tm.TeamId, tm.UserId });

            modelBuilder.Entity<TeamBooking>()
                .HasKey(tb => new { tb.TeamId, tb.BookingId });

            // Configure relationships
            modelBuilder.Entity<TeamMember>()
                .HasOne(tm => tm.Team)
                .WithMany(t => t.Members)
                .HasForeignKey(tm => tm.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TeamMember>()
                .HasOne(tm => tm.User)
                .WithMany(u => u.TeamMemberships)
                .HasForeignKey(tm => tm.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //--------------------------------
            // Configure UserId column length for TeamMembers to avoid exceeding index size
            modelBuilder.Entity<TeamMember>()
                .Property(tm => tm.UserId)
                .HasMaxLength(450); // Limit the size to stay under 900 bytes total key length
            //--------------------------------

            modelBuilder.Entity<TeamBooking>()
                .HasOne(tb => tb.Team)
                .WithMany(t => t.TeamBookings)
                .HasForeignKey(tb => tb.TeamId);

            modelBuilder.Entity<TeamBooking>()
                .HasOne(tb => tb.Booking)
                .WithMany(b => b.TeamBookings)
                .HasForeignKey(tb => tb.BookingId);

            modelBuilder.Entity<Yard>()
                .HasOne(y => y.Owner)
                .WithMany(u => u.OwnedYards)
                .HasForeignKey(y => y.OwnerId);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Captain)
                .WithMany()
                .HasForeignKey(t => t.CaptainId);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Yard)
                .WithMany(y => y.Schedules)
                .HasForeignKey(s => s.YardId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Yard)
                .WithMany(y => y.Bookings)
                .HasForeignKey(b => b.YardId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Schedule)
                .WithMany()
                .HasForeignKey(b => b.ScheduleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking>()
            .HasOne(b => b.Yard)
            .WithMany(y => y.Bookings)
            .HasForeignKey(b => b.YardId)
            .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Booking)
                .WithMany(b => b.Payments)
                .HasForeignKey(p => p.BookingId);

            modelBuilder.Entity<Offer>()
                .HasOne(o => o.Yard)
                .WithMany(y => y.Offers)
                .HasForeignKey(o => o.YardId);

            modelBuilder.Entity<RefreshToken>()
                .HasOne(rt => rt.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(rt => rt.UserId);
        }
    }
}

