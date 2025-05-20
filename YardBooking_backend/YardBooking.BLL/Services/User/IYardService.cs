using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using YardBooking.BLL.DTOs;

namespace YardBooking.BLL.Services
{
    public interface IYardService
    {
        Task<IEnumerable<YardDto>> GetYardsByOwnerIdAsync(int ownerId);
        Task<YardDto> GetYardByIdAsync(int yardId);
        Task<YardDto> CreateYardAsync(int ownerId, CreateYardDto createYardDto);
        Task<YardDto> UpdateYardAsync(int yardId, int ownerId, UpdateYardDto updateYardDto);
        Task DeleteYardAsync(int yardId, int ownerId);
    }
}