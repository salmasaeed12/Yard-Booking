using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
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

        // DbSets for all entities
        public DbSet<Yard> Yards { get; set; }
        public DbSet<YardOwner> YardOwners { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<TeamBooking> TeamBookings { get; set; }
        public DbSet<Proximity> Proximities { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Yard entity
            modelBuilder.Entity<Yard>(entity =>
            {
                entity.HasKey(e => e.YardID);
                entity.Property(e => e.YardName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.YardLocation).HasMaxLength(200);

                // Configure relationship with YardOwner
                entity.HasOne(e => e.Owner)
                    .WithMany(o => o.Yards)
                    .HasForeignKey(e => e.OwnerId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Convert YardPhotos from List<string> to comma-separated string in DB
                entity.Property(e => e.YardPhotos)
                    .HasConversion(
                        v => string.Join(',', v),
                        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
            });

            // Configure YardOwner entity
            modelBuilder.Entity<YardOwner>(entity =>
            {
                entity.HasKey(e => e.YardID);
                entity.Property(e => e.YardLocation).HasMaxLength(200);

                // Configure relationship with ApplicationUser
                entity.HasOne<ApplicationUser>()
                    .WithMany()
                    .HasForeignKey(e => e.OwnerID)
                    .OnDelete(DeleteBehavior.Restrict);

                // Convert YardPhotos from List<string> to comma-separated string in DB
                entity.Property(e => e.YardPhotos)
                    .HasConversion(
                        v => string.Join(',', v),
                        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
            });

            // Configure Schedule entity
            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => e.ScheduleId);
                entity.Property(e => e.DayOfWeek).HasMaxLength(10);
                entity.Property(e => e.StartTime).HasMaxLength(10);
                entity.Property(e => e.EndTime).HasMaxLength(10);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
            });

            // Configure Booking entity
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.BookingID);

                // Configure relationships
                entity.HasOne<Yard>()
                    .WithMany(y => y.Bookings)
                    .HasForeignKey(b => b.YardId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Schedule>()
                    .WithMany()
                    .HasForeignKey(b => b.ScheduleId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Offer entity
            modelBuilder.Entity<Offer>(entity =>
            {
                entity.HasKey(e => e.OfferId);
                entity.Property(e => e.ValidUntil).IsRequired();

                // Configure relationship with Yard
                entity.HasOne<Yard>()
                    .WithMany(y => y.Offers)
                    .HasForeignKey(o => o.OfferId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure Payment entity
            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PaymentId);
                entity.Property(e => e.Amount).IsRequired();
                entity.Property(e => e.PaymentDate).IsRequired();
                entity.Property(e => e.Status).HasMaxLength(20);

                // Configure relationship with Booking
                entity.HasOne<Booking>()
                    .WithMany()
                    .HasForeignKey(p => p.BookingId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Team entity
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.TeamId);
                entity.Property(e => e.TeamName).IsRequired().HasMaxLength(100);

                // Configure relationship with ApplicationUser (captain)
                entity.HasOne<ApplicationUser>()
                    .WithMany()
                    .HasForeignKey(t => t.CaptainId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure TeamMember entity
            modelBuilder.Entity<TeamMember>(entity =>
            {
                entity.HasKey(e => new { e.TeamId, e.UserId });
                entity.Property(e => e.JoinDate).IsRequired();

                // Configure relationships
                entity.HasOne<Team>()
                    .WithMany(t => t.Members)
                    .HasForeignKey(tm => tm.TeamId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<ApplicationUser>()
                    .WithMany()
                    .HasForeignKey(tm => tm.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure TeamBooking entity
            modelBuilder.Entity<TeamBooking>(entity =>
            {
                entity.HasKey(e => new { e.BookingId, e.TeamId });

                // Configure relationships
                entity.HasOne<Booking>()
                    .WithMany()
                    .HasForeignKey(tb => tb.BookingId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<Team>()
                    .WithMany()
                    .HasForeignKey(tb => tb.TeamId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Proximity entity
            modelBuilder.Entity<Proximity>(entity =>
            {
                entity.HasKey(e => new { e.YardID, e.UserID });
                entity.Property(e => e.Distance).IsRequired();

                // Configure relationships
                entity.HasOne<Yard>()
                    .WithMany(y => y.Proximities)
                    .HasForeignKey(p => p.YardID)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<ApplicationUser>()
                    .WithMany()
                    .HasForeignKey(p => p.UserID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}


