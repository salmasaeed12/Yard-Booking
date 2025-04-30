using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.Data;
using YardBooking.DAL.Data.Models;
using YardBooking.DAL.Inerfaces;

namespace YardBooking.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly YardBookingContext _context;
        public IGenericRepository<Yard> Yards { get; private set; }
        public IGenericRepository<Team> Teams { get; private set; }
        public IGenericRepository<TeamMember> TeamMembers { get; private set; }
        public IGenericRepository<Schedule> Schedules { get; private set; }
        public IGenericRepository<Booking> Bookings { get; private set; }
        public IGenericRepository<TeamBooking> TeamBookings { get; private set; }
        public IGenericRepository<Payment> Payments { get; private set; }
        public IGenericRepository<Offer> Offers { get; private set; }
        public IGenericRepository<RefreshToken> RefreshTokens { get; private set; }

        public UnitOfWork(YardBookingContext context)
        {
            _context = context;
            Yards = new GenericRepository<Yard>(_context);
            Teams = new GenericRepository<Team>(_context);
            TeamMembers = new GenericRepository<TeamMember>(_context);
            Schedules = new GenericRepository<Schedule>(_context);
            Bookings = new GenericRepository<Booking>(_context);
            TeamBookings = new GenericRepository<TeamBooking>(_context);
            Payments = new GenericRepository<Payment>(_context);
            Offers = new GenericRepository<Offer>(_context);
            RefreshTokens = new GenericRepository<RefreshToken>(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
