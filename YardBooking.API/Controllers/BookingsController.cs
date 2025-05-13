using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YardBooking.BLL.Dtos.Booking;
using YardBooking.BLL.IServices;

namespace YardBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDto>>> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            if (!bookings.Any())
                return NoContent();

            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDto>> GetBookingById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid booking ID.");

            var booking = await _bookingService.GetBookingByIdAsync(id);

            if (booking == null)
                return NotFound($"Booking with ID {id} not found.");

            return Ok(booking);
        }

        [HttpGet("yard/{yardId}")]
        public async Task<ActionResult<IEnumerable<BookingDto>>> GetBookingsByYardId(int yardId)
        {
            if (yardId <= 0)
                return BadRequest("Invalid yard ID.");

            var bookings = await _bookingService.GetBookingsByYardIdAsync(yardId);

            if (!bookings.Any())
                return NoContent();

            return Ok(bookings);
        }

        [HttpGet("date")]
        public async Task<ActionResult<IEnumerable<BookingDto>>> GetBookingsByDate([FromQuery] DateTime date)
        {
            if (date == default)
                return BadRequest("Invalid date.");

            var bookings = await _bookingService.GetBookingsByDateAsync(date);

            if (!bookings.Any())
                return NoContent();

            return Ok(bookings);
        }

        [HttpGet("availability")]
        public async Task<ActionResult<bool>> CheckYardAvailability([FromQuery] int yardId, [FromQuery] int scheduleId, [FromQuery] DateTime date)
        {
            if (yardId <= 0 || scheduleId <= 0 || date == default)
                return BadRequest("Invalid parameters for checking availability.");

            var isAvailable = await _bookingService.IsYardAvailableAsync(yardId, scheduleId, date);
            return Ok(isAvailable);
        }

        [HttpPost]
        public async Task<ActionResult<BookingDto>> CreateBooking([FromBody] CreateBookingDto createBookingDto)
        {
            if (createBookingDto == null)
                return BadRequest("Booking data is required.");

            try
            {
                var booking = await _bookingService.CreateBookingAsync(createBookingDto);
                return CreatedAtAction(nameof(GetBookingById), new { id = booking.BookingID }, booking);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "A database error occurred. Please try again later.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookingDto>> UpdateBooking(int id, [FromBody] UpdateBookingDto updateBookingDto)
        {
            if (id <= 0)
                return BadRequest("Invalid booking ID.");

            if (updateBookingDto == null)
                return BadRequest("Booking data is required.");

            try
            {
                var booking = await _bookingService.UpdateBookingAsync(id, updateBookingDto);
                return Ok(booking);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Booking with ID {id} not found.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBooking(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid booking ID.");

            var result = await _bookingService.DeleteBookingAsync(id);

            if (!result)
                return NotFound($"Booking with ID {id} not found.");

            return NoContent();
        }
    }
}
