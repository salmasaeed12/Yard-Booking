using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.BLL.Dtos.Yard;

namespace YardBooking.BLL.IServices
{
    public interface IYardService
    {
        Task<IEnumerable<YardDto>> GetAllYardsAsync();
        Task<YardDto> GetYardByIdAsync(int yardId);
        Task<IEnumerable<YardDto>> GetYardsByOwnerIdAsync(int ownerId);
        Task<YardDto> CreateYardAsync(YardCreateDto yardCreateDto);
        Task<YardDto> UpdateYardAsync(int yardId, YardUpdateDto yardUpdateDto);
        Task<bool> DeleteYardAsync(int yardId);
        Task<IEnumerable<YardDto>> SearchYardsByLocationAsync(string location);
    }
}
