using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.BLL.Dtos.Schedule;

namespace YardBooking.BLL.IServices
{
    public interface IScheduleService
    {
        Task<IEnumerable<ScheduleDto>> GetAllSchedulesAsync();
        Task<ScheduleDto> GetScheduleByIdAsync(int id);
        Task<IEnumerable<ScheduleDto>> GetSchedulesByYardIdAsync(int yardId);
        Task<ScheduleDto> CreateScheduleAsync(CreateScheduleDto scheduleDto);
        Task<ScheduleDto> UpdateScheduleAsync(int id, UpdateScheduleDto scheduleDto);
        Task<bool> DeleteScheduleAsync(int id);
    }
}
