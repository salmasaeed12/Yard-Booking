using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.BLL.Dtos.Yard;
using YardBooking.BLL.IServices;
using YardBooking.DAL.Data.Models;
using YardBooking.DAL.Inerfaces;

namespace YardBooking.BLL.Services
{
    public class YardService : IYardService
    {
        private readonly IYardRepository _yardRepository;
        private readonly IMapper _mapper;

        public YardService(IYardRepository yardRepository, IMapper mapper)
        {
            _yardRepository = yardRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<YardDto>> GetAllYardsAsync()
        {
            var yards = await _yardRepository.GetAllYardsAsync();
            return _mapper.Map<IEnumerable<YardDto>>(yards);
        }

        public async Task<YardDto> GetYardByIdAsync(int yardId)
        {
            var yard = await _yardRepository.GetYardByIdAsync(yardId);
            if (yard == null)
                return null;

            return _mapper.Map<YardDto>(yard);
        }

        public async Task<IEnumerable<YardDto>> GetYardsByOwnerIdAsync(int ownerId)
        {
            var yards = await _yardRepository.GetYardsByOwnerIdAsync(ownerId);
            return _mapper.Map<IEnumerable<YardDto>>(yards);
        }

        public async Task<YardDto> CreateYardAsync(YardCreateDto yardCreateDto)
        {
            var yard = _mapper.Map<Yard>(yardCreateDto);
            var createdYard = await _yardRepository.CreateYardAsync(yard);
            return _mapper.Map<YardDto>(createdYard);
        }

        public async Task<YardDto> UpdateYardAsync(int yardId, YardUpdateDto yardUpdateDto)
        {
            var existingYard = await _yardRepository.GetYardByIdAsync(yardId);
            if (existingYard == null)
                return null;

            _mapper.Map(yardUpdateDto, existingYard);
            var updatedYard = await _yardRepository.UpdateYardAsync(existingYard);
            return _mapper.Map<YardDto>(updatedYard);
        }

        public async Task<bool> DeleteYardAsync(int yardId)
        {
            return await _yardRepository.DeleteYardAsync(yardId);
        }

        public async Task<IEnumerable<YardDto>> SearchYardsByLocationAsync(string location)
        {
            var yards = await _yardRepository.SearchYardsByLocationAsync(location);
            return _mapper.Map<IEnumerable<YardDto>>(yards);
        }
    }
}
