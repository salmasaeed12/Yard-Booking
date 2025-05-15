using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.Data.Models;

namespace YardBooking.DAL.Inerfaces
{
    public interface IYardRepository
    {
        Task<IEnumerable<Yard>> GetAllYardsAsync();
        Task<Yard> GetYardByIdAsync(int yardId);
        Task<IEnumerable<Yard>> GetYardsByOwnerIdAsync(int ownerId);
        Task<Yard> CreateYardAsync(Yard yard);
        Task<Yard> UpdateYardAsync(Yard yard);
        Task<bool> DeleteYardAsync(int yardId);
        Task<bool> YardExistsAsync(int yardId);
        Task<IEnumerable<Yard>> SearchYardsByLocationAsync(string location);
    }
}
