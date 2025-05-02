using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.BLL.Dtos.Booking;
using YardBooking.BLL.IServices;
using YardBooking.DAL.Data.Models;
using YardBooking.DAL.Inerfaces;

namespace YardBooking.BLL.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookingDto>> GetAllBookingsAsync()
        {
            var bookings = await _bookingRepository.GetAllBookingsAsync();
            return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }

        public async Task<BookingDto> GetBookingByIdAsync(int id)
        {
            var booking = await _bookingRepository.GetBookingByIdAsync(id);
            return _mapper.Map<BookingDto>(booking);
        }

        public async Task<IEnumerable<BookingDto>> GetBookingsByYardIdAsync(int yardId)
        {
            var bookings = await _bookingRepository.GetBookingsByYardIdAsync(yardId);
            return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }

        public async Task<IEnumerable<BookingDto>> GetBookingsByDateAsync(DateTime date)
        {
            var bookings = await _bookingRepository.GetBookingsByDateAsync(date);
            return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }

        public async Task<bool> IsYardAvailableAsync(int yardId, int scheduleId, DateTime date)
        {
            return await _bookingRepository.IsYardAvailableAsync(yardId, scheduleId, date);
        }

        public async Task<BookingDto> CreateBookingAsync(CreateBookingDto createBookingDto)
        {
            // Check if yard is available
            bool isAvailable = await _bookingRepository.IsYardAvailableAsync(
                createBookingDto.YardID,
                createBookingDto.ScheduleID,
                createBookingDto.BookingDate);

            if (!isAvailable)
            {
                throw new InvalidOperationException("The yard is already booked for this time and date.");
            }

            var booking = _mapper.Map<Booking>(createBookingDto);
            booking = await _bookingRepository.CreateBookingAsync(booking);
            return _mapper.Map<BookingDto>(booking);
        }

        public async Task<BookingDto> UpdateBookingAsync(int id, UpdateBookingDto updateBookingDto)
        {
            var existingBooking = await _bookingRepository.GetBookingByIdAsync(id);

            if (existingBooking == null)
            {
                throw new KeyNotFoundException($"Booking with ID {id} not found.");
            }

            // Check availability only if yard or schedule or date is changed
            if (existingBooking.YardId != updateBookingDto.YardID ||
                existingBooking.ScheduleId != updateBookingDto.ScheduleID ||
                existingBooking.BookingDate.Date != updateBookingDto.BookingDate.Date)
            {
                bool isAvailable = await _bookingRepository.IsYardAvailableAsync(
                    updateBookingDto.YardID,
                    updateBookingDto.ScheduleID,
                    updateBookingDto.BookingDate);

                if (!isAvailable)
                {
                    throw new InvalidOperationException("The yard is already booked for this time and date.");
                }
            }

            _mapper.Map(updateBookingDto, existingBooking);
            var updatedBooking = await _bookingRepository.UpdateBookingAsync(existingBooking);
            return _mapper.Map<BookingDto>(updatedBooking);
        }

        public async Task<bool> DeleteBookingAsync(int id)
        {
            return await _bookingRepository.DeleteBookingAsync(id);
        }
    }
}
