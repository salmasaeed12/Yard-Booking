using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.Data.Models;
using YardBooking.DAL.Data;
using YardBooking.DAL.Inerfaces;

namespace YardBooking.DAL.Repository
{
    public class YardRepo : IYardRepository
    {
        private readonly YardBookingContext _context;

        public YardRepo(YardBookingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Yard>> GetAllYardsAsync()
        {
            return await _context.Yards
                .Include(y => y.Owner)
                .ThenInclude(o => o.UserName)
                .ToListAsync();
        }

        public async Task<Yard> GetYardByIdAsync(int yardId)
        {
            return await _context.Yards
                .Include(y => y.Owner)
                .ThenInclude(o => o.UserName)
                .Include(y => y.Proximities)
                .Include(y => y.Offers)
                .Include(y => y.Bookings)
                .FirstOrDefaultAsync(y => y.YardId == yardId);
        }

        public async Task<IEnumerable<Yard>> GetYardsByOwnerIdAsync(int ownerId)
        {
            return await _context.Yards
                .Include(y => y.Owner)
                .Where(y => y.OwnerId == ownerId)
                .ToListAsync();
        }

        public async Task<Yard> CreateYardAsync(Yard yard)
        {
            _context.Yards.Add(yard);
            await _context.SaveChangesAsync();
            return yard;
        }

        public async Task UpdateYardAsync(Yard yard)
        {
            _context.Entry(yard).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteYardAsync(int yardId)
        {
            var yard = await _context.Yards.FindAsync(yardId);
            if (yard != null)
            {
                _context.Yards.Remove(yard);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Yard>> SearchYardsByLocationAsync(string location)
        {
            return await _context.Yards
                .Include(y => y.Owner)
                .ThenInclude(o => o.UserName)
                .Where(y => y.YardLocation.Contains(location) || y.YardArea.ToString().Contains(location))
                .ToListAsync();
        }

        public async Task<bool> YardExistsAsync(int yardId)
        {
            return await _context.Yards.AnyAsync(y => y.YardId == yardId);
        }
    }
}
