using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using YardBooking.BLL.DTOs;
using YardBooking.BLL.Services;

namespace YardBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // This ensures only authenticated users can access these endpoints
    public class YardsController : ControllerBase
    {
        private readonly IYardService _yardService;

        public YardsController(IYardService yardService)
        {
            _yardService = yardService;
        }

        // GET: api/yards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YardDto>>> GetYards()
        {
            // Get the current user's ID from their claims
            var ownerId = GetCurrentUserId();

            var yards = await _yardService.GetYardsByOwnerIdAsync(ownerId);
            return Ok(yards);
        }

        // GET: api/yards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<YardDto>> GetYard(int id)
        {
            var yard = await _yardService.GetYardByIdAsync(id);

            if (yard == null)
            {
                return NotFound();
            }

            return yard;
        }

        // POST: api/yards
        [HttpPost]
        public async Task<ActionResult<YardDto>> CreateYard([FromForm] CreateYardDto createYardDto)
        {
            var ownerId = GetCurrentUserId();

            var createdYard = await _yardService.CreateYardAsync(ownerId, createYardDto);

            return CreatedAtAction(nameof(GetYard), new { id = createdYard.YardID }, createdYard);
        }

        // PUT: api/yards/5
        [HttpPut("{id}")]
        public async Task<ActionResult<YardDto>> UpdateYard(int id, [FromForm] UpdateYardDto updateYardDto)
        {
            var ownerId = GetCurrentUserId();

            var updatedYard = await _yardService.UpdateYardAsync(id, ownerId, updateYardDto);

            if (updatedYard == null)
            {
                return NotFound();
            }

            return updatedYard;
        }

        // DELETE: api/yards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYard(int id)
        {
            var ownerId = GetCurrentUserId();

            await _yardService.DeleteYardAsync(id, ownerId);

            return NoContent();
        }

        private int GetCurrentUserId()
        {
            // This gets the user's ID from their JWT token claims
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}