using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.Data.Models;

namespace YardBooking.DAL.Inerfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Yard> Yards { get; }
        IGenericRepository<Team> Teams { get; }
        IGenericRepository<TeamMember> TeamMembers { get; }
        IGenericRepository<Schedule> Schedules { get; }
        IGenericRepository<Booking> Bookings { get; }
        IGenericRepository<TeamBooking> TeamBookings { get; }
        IGenericRepository<Payment> Payments { get; }
        IGenericRepository<Offer> Offers { get; }
        IGenericRepository<RefreshToken> RefreshTokens { get; }

        Task<int> CompleteAsync();
    }
}
