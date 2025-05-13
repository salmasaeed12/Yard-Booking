using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YardBooking.BLL.Dtos.Yard;
using YardBooking.BLL.IServices;
using YardBooking.DAL.Data.Models;

namespace YardBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YardsController : ControllerBase
    {
        private readonly IYardService _yardService;
        private readonly IMapper _mapper;

        public YardsController(IYardService yardService, IMapper mapper)
        {
            _yardService = yardService;
            _mapper = mapper;
        }

        // GET: api/Yards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YardDto>>> GetYards()
        {
            try
            {
                var yards = await _yardService.GetAllYardsAsync();
                var yardDtos = _mapper.Map<IEnumerable<YardDto>>(yards);
                return Ok(yardDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error retrieving yards: {ex.Message}");
            }
        }

        // GET: api/Yards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YardDto>> GetYard(int id)
        {
            try
            {
                var yard = await _yardService.GetYardByIdAsync(id);

                if (yard == null)
                {
                    return NotFound($"Yard with ID {id} not found");
                }

                var yardDto = _mapper.Map<YardDto>(yard);
                return Ok(yardDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error retrieving yard with ID {id}: {ex.Message}");
            }
        }

        // GET: api/Yards/owner/5
        [HttpGet("owner/{ownerId}")]
        public async Task<ActionResult<IEnumerable<YardDto>>> GetYardsByOwner(int ownerId)
        {
            try
            {
                var yards = await _yardService.GetYardsByOwnerIdAsync(ownerId);
                var yardDtos = _mapper.Map<IEnumerable<YardDto>>(yards);
                return Ok(yardDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error retrieving yards for owner {ownerId}: {ex.Message}");
            }
        }

        // POST: api/Yards
        [HttpPost]
        public async Task<ActionResult<YardDto>> CreateYard(CreateYardDto createYardDto)
        {
            try
            {
                var yard = _mapper.Map<Yard>(createYardDto);
                var createdYard = await _yardService.CreateYardAsync(yard);
                var yardDto = _mapper.Map<YardDto>(createdYard);

                return CreatedAtAction(nameof(GetYard), new { id = yardDto.YardId }, yardDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error creating yard: {ex.Message}");
            }
        }

        // PUT: api/Yards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateYard(int id, UpdateYardDto updateYardDto)
        {
            try
            {
                if (!await _yardService.YardExistsAsync(id))
                {
                    return NotFound($"Yard with ID {id} not found");
                }

                var existingYard = await _yardService.GetYardByIdAsync(id);
                _mapper.Map(updateYardDto, existingYard);

                await _yardService.UpdateYardAsync(existingYard);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error updating yard with ID {id}: {ex.Message}");
            }
        }

        // DELETE: api/Yards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYard(int id)
        {
            try
            {
                if (!await _yardService.YardExistsAsync(id))
                {
                    return NotFound($"Yard with ID {id} not found");
                }

                await _yardService.DeleteYardAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error deleting yard with ID {id}: {ex.Message}");
            }
        }

        // GET: api/Yards/search/location
        [HttpGet("search/{location}")]
        public async Task<ActionResult<IEnumerable<YardDto>>> SearchYardsByLocation(string location)
        {
            try
            {
                var yards = await _yardService.SearchYardsByLocationAsync(location);
                var yardDtos = _mapper.Map<IEnumerable<YardDto>>(yards);
                return Ok(yardDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error searching yards by location {location}: {ex.Message}");
            }
        }
    }
}
