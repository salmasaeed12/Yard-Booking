using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.Data.Models;
using YardBooking.DAL.Data;
using YardBooking.DAL.Inerfaces;
using Microsoft.EntityFrameworkCore;

namespace YardBooking.DAL.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly YardBookingContext _context;

        public BookingRepository(YardBookingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _context.Bookings
                .Include(b => b.Yard)
                .Include(b => b.Schedule)
                .ToListAsync();
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _context.Bookings
                .Include(b => b.Yard)
                .Include(b => b.Schedule)
                .FirstOrDefaultAsync(b => b.BookingID == id);
        }

        public async Task<IEnumerable<Booking>> GetBookingsByYardIdAsync(int yardId)
        {
            return await _context.Bookings
                .Include(b => b.Schedule)
                .Where(b => b.YardId == yardId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByDateAsync(DateTime date)
        {
            return await _context.Bookings
                .Include(b => b.Yard)
                .Include(b => b.Schedule)
                .Where(b => b.BookingDate.Date == date.Date)
                .ToListAsync();
        }

        public async Task<bool> IsYardAvailableAsync(int yardId, int scheduleId, DateTime date)
        {
            var existingBooking = await _context.Bookings
                .AnyAsync(b => b.YardId == yardId &&
                               b.ScheduleId == scheduleId &&
                               b.BookingDate.Date == date.Date &&
                               b.Status != "Cancelled");

            return !existingBooking;
        }

        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking> UpdateBookingAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<bool> DeleteBookingAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
                return false;

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
