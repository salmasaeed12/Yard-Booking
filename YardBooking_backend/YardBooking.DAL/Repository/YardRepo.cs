//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace YardBooking.DAL.Repository
//{
//    public class YardRepo
//    {
//    }
//}
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YardBooking.DAL.Data;
using YardBooking.DAL.Models;

namespace YardBooking.DAL.Repositories
{
    public class YardRepository : IYardRepository
    {
        private readonly YardBookingContext _context;

        public YardRepository(YardBookingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Yard>> GetAllYardsByOwnerIdAsync(int ownerId)
        {
            return await _context.Yards
                .Where(y => y.OwnerID == ownerId)
                .ToListAsync();
        }

        public async Task<Yard> GetYardByIdAsync(int yardId)
        {
            return await _context.Yards.FindAsync(yardId);
        }

        public async Task<Yard> CreateYardAsync(Yard yard)
        {
            _context.Yards.Add(yard);
            await _context.SaveChangesAsync();
            return yard;
        }

        public async Task UpdateYardAsync(Yard yard)
        {
            _context.Yards.Update(yard);
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
    }
}