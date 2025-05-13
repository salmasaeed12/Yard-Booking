using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.Data.Models;

namespace YardBooking.BLL.IServices
{
    public interface IYardService
    {
        Task<IEnumerable<Yard>> GetAllYardsAsync();
        Task<Yard> GetYardByIdAsync(int yardId);
        Task<IEnumerable<Yard>> GetYardsByOwnerIdAsync(int ownerId);
        Task<Yard> CreateYardAsync(Yard yard);
        Task UpdateYardAsync(Yard yard);
        Task DeleteYardAsync(int yardId);
        Task<IEnumerable<Yard>> SearchYardsByLocationAsync(string location);
        Task<bool> YardExistsAsync(int yardId);
    }
}
