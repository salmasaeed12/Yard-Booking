using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.Data.Models;

namespace YardBooking.DAL.Inerfaces
{
    public interface IBookingRepository
    {
       
        Task<IEnumerable<Booking>> GetAllBookingsAsync();

        Task<Booking> GetBookingByIdAsync(int id);

     
        Task<IEnumerable<Booking>> GetBookingsByYardIdAsync(int yardId);

       
        Task<IEnumerable<Booking>> GetBookingsByDateAsync(DateTime date);

        Task<bool> IsYardAvailableAsync(int yardId, int scheduleId, DateTime date);

        Task<Booking> CreateBookingAsync(Booking booking);

        Task<Booking> UpdateBookingAsync(Booking booking);

        Task<bool> DeleteBookingAsync(int id);

       
    }
}
