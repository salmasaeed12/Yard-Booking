using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.Data.Models;

namespace YardBooking.DAL.Repository
{
    public interface IYardRepo
    {
        void AddYard(Yard yard);
        Task<IEnumerable<Yard>> GetAllYardsByOwnerIdAsync(int ownerId);
        Task<Yard> GetYardByIdAsync(int yardId);
        Task<Yard> CreateYardAsync(Yard yard);
        Task UpdateYardAsync(Yard yard);
        Task DeleteYardAsync(int yardId);
    }
}
