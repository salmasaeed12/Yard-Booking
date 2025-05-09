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
            if (!await IsYardAvailableAsync(booking.YardId, booking.ScheduleId, booking.BookingDate))
            {
                throw new InvalidOperationException("The yard is not available for the selected schedule and date.");
            }

            booking.Status = "Pending";
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking> UpdateBookingAsync(Booking booking)
        {
            var existingBooking = await _context.Bookings.FindAsync(booking.BookingID);
            if (existingBooking == null)
            {
                throw new KeyNotFoundException("Booking not found.");
            }

            if (existingBooking.Status == "Cancelled")
            {
                throw new InvalidOperationException("Cannot update a cancelled booking.");
            }

            if (!await IsYardAvailableAsync(booking.YardId, booking.ScheduleId, booking.BookingDate))
            {
                throw new InvalidOperationException("The yard is not available for the updated schedule and date.");
            }

            existingBooking.BookingDate = booking.BookingDate;
            existingBooking.YardId = booking.YardId;
            existingBooking.ScheduleId = booking.ScheduleId;
            existingBooking.Status = booking.Status;

            _context.Bookings.Update(existingBooking);
            await _context.SaveChangesAsync();
            return existingBooking;
        }

        public async Task<bool> DeleteBookingAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
                return false;

            if (booking.Status == "Cancelled")
            {
                throw new InvalidOperationException("Booking is already cancelled.");
            }

            booking.Status = "Cancelled";
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Booking>> GetBookingsByStatusAsync(string status)
        {
            return await _context.Bookings
                .Include(b => b.Yard)
                .Include(b => b.Schedule)
                .Where(b => b.Status.Equals(status, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByUserAsync(string userId)
        {
            return await _context.Bookings
                .Include(b => b.Yard)
                .Include(b => b.Schedule)
                .Where(b => b.Yard.OwnerId == userId)
                .ToListAsync();
        }

        public async Task<bool> ConfirmBookingAsync(int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking == null)
            {
                throw new KeyNotFoundException("Booking not found.");
            }

            if (booking.Status != "Pending")
            {
                throw new InvalidOperationException("Only pending bookings can be confirmed.");
            }

            booking.Status = "Confirmed";
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
