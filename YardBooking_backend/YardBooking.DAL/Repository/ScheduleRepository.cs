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
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly YardBookingContext _context;

        public ScheduleRepository(YardBookingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Schedule>> GetAllSchedulesAsync()
        {
            return await _context.Schedules
                .Include(s => s.Yard)
                .ToListAsync();
        }

        public async Task<Schedule> GetScheduleByIdAsync(int id)
        {
            return await _context.Schedules
                .Include(s => s.Yard)
                .FirstOrDefaultAsync(s => s.ScheduleId == id);
        }

        public async Task<IEnumerable<Schedule>> GetSchedulesByYardIdAsync(int yardId)
        {
            return await _context.Schedules
                .Where(s => s.YardID_FK == yardId)
                .Include(s => s.Yard)
                .ToListAsync();
        }

        public async Task<Schedule> CreateScheduleAsync(Schedule schedule)
        {
            await _context.Schedules.AddAsync(schedule);
            await _context.SaveChangesAsync();
            return schedule;
        }

        public async Task<Schedule> UpdateScheduleAsync(Schedule schedule)
        {
            _context.Schedules.Update(schedule);
            await _context.SaveChangesAsync();
            return schedule;
        }

        public async Task<bool> DeleteScheduleAsync(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
                return false;

            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
