using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.BLL.Dtos.Schedule;
using YardBooking.BLL.IServices;
using YardBooking.DAL.Data.Models;
using YardBooking.DAL.Inerfaces;

namespace YardBooking.BLL.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;

        public ScheduleService(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ScheduleDto>> GetAllSchedulesAsync()
        {
            var schedules = await _scheduleRepository.GetAllSchedulesAsync();
            return _mapper.Map<IEnumerable<ScheduleDto>>(schedules);
        }

        public async Task<ScheduleDto> GetScheduleByIdAsync(int id)
        {
            var schedule = await _scheduleRepository.GetScheduleByIdAsync(id);
            return _mapper.Map<ScheduleDto>(schedule);
        }

        public async Task<IEnumerable<ScheduleDto>> GetSchedulesByYardIdAsync(int yardId)
        {
            var schedules = await _scheduleRepository.GetSchedulesByYardIdAsync(yardId);
            return _mapper.Map<IEnumerable<ScheduleDto>>(schedules);
        }

        public async Task<ScheduleDto> CreateScheduleAsync(CreateScheduleDto scheduleDto)
        {
            var schedule = _mapper.Map<Schedule>(scheduleDto);
            var createdSchedule = await _scheduleRepository.CreateScheduleAsync(schedule);
            return _mapper.Map<ScheduleDto>(createdSchedule);
        }

        public async Task<ScheduleDto> UpdateScheduleAsync(int id, UpdateScheduleDto scheduleDto)
        {
            var existingSchedule = await _scheduleRepository.GetScheduleByIdAsync(id);
            if (existingSchedule == null)
                return null;

            _mapper.Map(scheduleDto, existingSchedule);
            var updatedSchedule = await _scheduleRepository.UpdateScheduleAsync(existingSchedule);
            return _mapper.Map<ScheduleDto>(updatedSchedule);
        }

        public async Task<bool> DeleteScheduleAsync(int id)
        {
            return await _scheduleRepository.DeleteScheduleAsync(id);
        }
    }
}
