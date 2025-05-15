using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YardBooking.BLL.Dtos.Yard;
using YardBooking.BLL.IServices;

namespace YardBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YardsController : ControllerBase
    {
        private readonly IYardService _yardService;

        public YardsController(IYardService yardService)
        {
            _yardService = yardService;
        }

        // GET: api/Yards
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<YardDto>>> GetYards()
        {
            var yards = await _yardService.GetAllYardsAsync();
            return Ok(yards);
        }

        // GET: api/Yards/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<YardDto>> GetYard(int id)
        {
            var yard = await _yardService.GetYardByIdAsync(id);

            if (yard == null)
                return NotFound();

            return Ok(yard);
        }

        // GET: api/Yards/owner/5
        [HttpGet("owner/{ownerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<YardDto>>> GetYardsByOwner(int ownerId)
        {
            var yards = await _yardService.GetYardsByOwnerIdAsync(ownerId);
            return Ok(yards);
        }

        // GET: api/Yards/search?location=cairo
        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<YardDto>>> SearchYards([FromQuery] string location)
        {
            var yards = await _yardService.SearchYardsByLocationAsync(location);
            return Ok(yards);
        }

        // POST: api/Yards
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<YardDto>> CreateYard(YardCreateDto yardCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdYard = await _yardService.CreateYardAsync(yardCreateDto);

            return CreatedAtAction(nameof(GetYard), new { id = createdYard.YardID }, createdYard);
        }

        // PUT: api/Yards/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateYard(int id, YardUpdateDto yardUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedYard = await _yardService.UpdateYardAsync(id, yardUpdateDto);

            if (updatedYard == null)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/Yards/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteYard(int id)
        {
            var result = await _yardService.DeleteYardAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
