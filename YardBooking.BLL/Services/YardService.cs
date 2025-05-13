using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.BLL.IServices;
using YardBooking.DAL.Data.Models;
using YardBooking.DAL.Inerfaces;

namespace YardBooking.BLL.Services
{
    public class YardService : IYardService
    {
        private readonly IYardRepository _yardRepository;

        public YardService(IYardRepository yardRepository)
        {
            _yardRepository = yardRepository;
        }

        public async Task<IEnumerable<Yard>> GetAllYardsAsync()
        {
            return await _yardRepository.GetAllYardsAsync();
        }

        public async Task<Yard> GetYardByIdAsync(int yardId)
        {
            return await _yardRepository.GetYardByIdAsync(yardId);
        }

        public async Task<IEnumerable<Yard>> GetYardsByOwnerIdAsync(int ownerId)
        {
            return await _yardRepository.GetYardsByOwnerIdAsync(ownerId);
        }

        public async Task<Yard> CreateYardAsync(Yard yard)
        {
            return await _yardRepository.CreateYardAsync(yard);
        }

        public async Task UpdateYardAsync(Yard yard)
        {
            await _yardRepository.UpdateYardAsync(yard);
        }

        public async Task DeleteYardAsync(int yardId)
        {
            await _yardRepository.DeleteYardAsync(yardId);
        }

        public async Task<IEnumerable<Yard>> SearchYardsByLocationAsync(string location)
        {
            return await _yardRepository.SearchYardsByLocationAsync(location);
        }

        public async Task<bool> YardExistsAsync(int yardId)
        {
            return await _yardRepository.YardExistsAsync(yardId);
        }
    }
}
