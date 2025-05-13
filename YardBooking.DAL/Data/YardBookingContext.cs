using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using YardBooking.DAL.Data.Models;

namespace YardBooking.DAL.Data
{
    public class YardBookingContext : IdentityDbContext<ApplicationUser>
    {
        public YardBookingContext(DbContextOptions<YardBookingContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .ConfigureWarnings(warnings =>
                    warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Yard> Yards { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<TeamBooking> TeamBookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<YardOwner> YardOwners { get; set; }
        public DbSet<Proximity> Proximities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // TeamMember: many-to-many
            modelBuilder.Entity<TeamMember>()
                .HasKey(tm => new { tm.TeamId, tm.UserId });

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

            modelBuilder.Entity<TeamMember>()
                .Property(tm => tm.UserId)
                .HasMaxLength(450);

            // TeamBooking: many-to-many
            modelBuilder.Entity<TeamBooking>()
                .HasKey(tb => new { tb.TeamId, tb.BookingId });

            modelBuilder.Entity<TeamBooking>()
                .HasOne(tb => tb.Team)
                .WithMany(t => t.TeamBookings)
                .HasForeignKey(tb => tb.TeamId);

            modelBuilder.Entity<TeamBooking>()
                .HasOne(tb => tb.Booking)
                .WithMany(b => b.TeamBookings)
                .HasForeignKey(tb => tb.BookingId);

            // Yard & Owner
            modelBuilder.Entity<Yard>()
                .HasOne(y => y.Owner)
                .WithMany(u => u.OwnedYards)
                .HasForeignKey(y => y.OwnerId)
                .OnDelete(DeleteBehavior.Restrict); 

            // Team & Captain
            modelBuilder.Entity<Team>()
                .HasOne(t => t.Captain)
                .WithMany()
                .HasForeignKey(t => t.CaptainId);

            // Schedule
            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Yard)
                .WithMany(y => y.Schedules)
                .HasForeignKey(s => s.YardID_FK)
                .OnDelete(DeleteBehavior.Cascade);

            // Booking
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

            // Payment
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Booking)
                .WithMany(b => b.Payments)
                .HasForeignKey(p => p.BookingId);

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(10, 2);

            // Offer
            modelBuilder.Entity<Offer>()
                .HasOne(o => o.Yard)
                .WithMany(y => y.Offers)
                .HasForeignKey(o => o.YardId);

            modelBuilder.Entity<Offer>()
                .Property(o => o.DiscountPercentage)
                .HasPrecision(5, 2);

            // Proximity
            modelBuilder.Entity<Proximity>()
                .HasOne(p => p.Yard)
                .WithMany(y => y.Proximities)
                .HasForeignKey(p => p.YardID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Proximity>()
                .HasOne(p => p.User)
                .WithMany(u => u.Proximities)
                .HasForeignKey(p => p.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            // YardOwner
            modelBuilder.Entity<YardOwner>()
                .HasOne(yo => yo.User)
                .WithMany()
                .HasForeignKey(yo => yo.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<YardOwner>()
                .HasOne(yo => yo.Yard)
                .WithMany()
                .HasForeignKey(yo => yo.YardID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}



