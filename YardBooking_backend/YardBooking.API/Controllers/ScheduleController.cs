using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YardBooking.BLL.Dtos.Schedule;
using YardBooking.BLL.IServices;

namespace YardBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleDto>>> GetAllSchedules()
        {
            var schedules = await _scheduleService.GetAllSchedulesAsync();
            return Ok(schedules);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleDto>> GetScheduleById(int id)
        {
            var schedule = await _scheduleService.GetScheduleByIdAsync(id);
            if (schedule == null)
                return NotFound();

            return Ok(schedule);
        }

        [HttpGet("yard/{yardId}")]
        public async Task<ActionResult<IEnumerable<ScheduleDto>>> GetSchedulesByYardId(int yardId)
        {
            var schedules = await _scheduleService.GetSchedulesByYardIdAsync(yardId);
            return Ok(schedules);
        }

        [HttpPost]
        public async Task<ActionResult<ScheduleDto>> CreateSchedule(CreateScheduleDto scheduleDto)
        {
            var createdSchedule = await _scheduleService.CreateScheduleAsync(scheduleDto);
            return CreatedAtAction(nameof(GetScheduleById), new { id = createdSchedule.ScheduleId }, createdSchedule);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ScheduleDto>> UpdateSchedule(int id, UpdateScheduleDto scheduleDto)
        {
            var updatedSchedule = await _scheduleService.UpdateScheduleAsync(id, scheduleDto);
            if (updatedSchedule == null)
                return NotFound();

            return Ok(updatedSchedule);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSchedule(int id)
        {
            var result = await _scheduleService.DeleteScheduleAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
