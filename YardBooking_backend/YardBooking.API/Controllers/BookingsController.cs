using Microsoft.AspNetCore.Mvc;
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
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDto>> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);

            if (booking == null)
                return NotFound();

            return Ok(booking);
        }

        [HttpGet("yard/{yardId}")]
        public async Task<ActionResult<IEnumerable<BookingDto>>> GetBookingsByYardId(int yardId)
        {
            var bookings = await _bookingService.GetBookingsByYardIdAsync(yardId);
            return Ok(bookings);
        }

        [HttpGet("date")]
        public async Task<ActionResult<IEnumerable<BookingDto>>> GetBookingsByDate([FromQuery] DateTime date)
        {
            var bookings = await _bookingService.GetBookingsByDateAsync(date);
            return Ok(bookings);
        }

        [HttpGet("availability")]
        public async Task<ActionResult<bool>> CheckYardAvailability([FromQuery] int yardId, [FromQuery] int scheduleId, [FromQuery] DateTime date)
        {
            var isAvailable = await _bookingService.IsYardAvailableAsync(yardId, scheduleId, date);
            return Ok(isAvailable);
        }

        [HttpPost]
        public async Task<ActionResult<BookingDto>> CreateBooking([FromBody] CreateBookingDto createBookingDto)
        {
            try
            {
                var booking = await _bookingService.CreateBookingAsync(createBookingDto);
                return CreatedAtAction(nameof(GetBookingById), new { id = booking.BookingID }, booking);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookingDto>> UpdateBooking(int id, [FromBody] UpdateBookingDto updateBookingDto)
        {
            try
            {
                var booking = await _bookingService.UpdateBookingAsync(id, updateBookingDto);
                return Ok(booking);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBooking(int id)
        {
            var result = await _bookingService.DeleteBookingAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
