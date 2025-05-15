using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YardBooking.DAL.Data;
using YardBooking.DAL.Data.Models;
using YardBooking.DAL.Inerfaces;

namespace YardBooking.DAL.Repository
{
    public class YardRepository : IYardRepository
    {
        private readonly YardBookingContext _context;

        public YardRepository(YardBookingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Yard>> GetAllYardsAsync()
        {
            return await _context.Yards
                .Include(y => y.Owner)
                .ThenInclude(o => o.User)
                .ToListAsync();
        }

        public async Task<Yard> GetYardByIdAsync(int yardId)
        {
            return await _context.Yards
                .Include(y => y.Owner)
                .ThenInclude(o => o.User)
                .FirstOrDefaultAsync(y => y.YardID == yardId);
        }

        public async Task<IEnumerable<Yard>> GetYardsByOwnerIdAsync(string ownerId)
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

        public async Task<Yard> UpdateYardAsync(Yard yard)
        {
            _context.Entry(yard).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return yard;
        }

        public async Task<bool> DeleteYardAsync(int yardId)
        {
            var yard = await _context.Yards.FindAsync(yardId);
            if (yard == null)
                return false;

            _context.Yards.Remove(yard);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> YardExistsAsync(int yardId)
        {
            return await _context.Yards.AnyAsync(y => y.YardID == yardId);
        }

        public async Task<IEnumerable<Yard>> SearchYardsByLocationAsync(string location)
        {
            return await _context.Yards
                .Include(y => y.Owner)
                .ThenInclude(o => o.User)
                .Where(y => y.YardLocation.Contains(location))
                .ToListAsync();
        }

        public Task<IEnumerable<Yard>> GetYardsByOwnerIdAsync(int ownerId)
        {
            throw new NotImplementedException();
        }
    }
}