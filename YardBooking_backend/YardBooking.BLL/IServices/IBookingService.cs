using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.BLL.Dtos.Booking;

namespace YardBooking.BLL.IServices
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDto>> GetAllBookingsAsync();
        Task<BookingDto> GetBookingByIdAsync(int id);
        Task<IEnumerable<BookingDto>> GetBookingsByYardIdAsync(int yardId);
        Task<IEnumerable<BookingDto>> GetBookingsByDateAsync(DateTime date);
        Task<bool> IsYardAvailableAsync(int yardId, int scheduleId, DateTime date);
        Task<BookingDto> CreateBookingAsync(CreateBookingDto createBookingDto);
        Task<BookingDto> UpdateBookingAsync(int id, UpdateBookingDto updateBookingDto);
        Task<bool> DeleteBookingAsync(int id);
    }
}
