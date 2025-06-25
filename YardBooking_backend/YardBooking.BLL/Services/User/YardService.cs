using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using YardBooking.BLL.DTOs;
using YardBooking.DAL.Models;
using YardBooking.DAL.Repositories;

namespace YardBooking.BLL.Services
{
    public class YardService : IYardService
    {
        private readonly IYardRepository _yardRepository;
        private readonly IFileService _fileService;

        public YardService(IYardRepository yardRepository, IFileService fileService)
        {
            _yardRepository = yardRepository;
            _fileService = fileService;
        }

        public async Task<IEnumerable<YardDto>> GetYardsByOwnerIdAsync(int ownerId)
        {
            var yards = await _yardRepository.GetAllYardsByOwnerIdAsync(ownerId);

            return yards.Select(y => new YardDto
            {
                YardID = y.YardID,
                YardName = y.YardName,
                YardLocation = y.YardLocation,
                YardArea = y.YardArea,
                ServicesOffered = y.ServicesOffered,
                YardPhotos = string.IsNullOrEmpty(y.YardPhotos)
                    ? new List<string>()
                    : JsonSerializer.Deserialize<List<string>>(y.YardPhotos)
            });
        }

        public async Task<YardDto> GetYardByIdAsync(int yardId)
        {
            var yard = await _yardRepository.GetYardByIdAsync(yardId);

            if (yard == null)
                return null;

            return new YardDto
            {
                YardID = yard.YardID,
                YardName = yard.YardName,
                YardLocation = yard.YardLocation,
                YardArea = yard.YardArea,
                ServicesOffered = yard.ServicesOffered,
                YardPhotos = string.IsNullOrEmpty(yard.YardPhotos)
                    ? new List<string>()
                    : JsonSerializer.Deserialize<List<string>>(yard.YardPhotos)
            };
        }

        public async Task<YardDto> CreateYardAsync(int ownerId, CreateYardDto createYardDto)
        {
            // Save the photos
            var photoUrls = await _fileService.SaveFilesAsync(createYardDto.YardPhotos, "yards");

            // Create the yard
            var yard = new Yard
            {
                OwnerID = ownerId,
                YardName = createYardDto.YardName,
                YardLocation = createYardDto.YardLocation,
                YardArea = createYardDto.YardArea,
                ServicesOffered = createYardDto.ServicesOffered,
                YardPhotos = JsonSerializer.Serialize(photoUrls)
            };

            var createdYard = await _yardRepository.CreateYardAsync(yard);

            return new YardDto
            {
                YardID = createdYard.YardID,
                YardName = createdYard.YardName,
                YardLocation = createdYard.YardLocation,
                YardArea = createdYard.YardArea,
                ServicesOffered = createdYard.ServicesOffered,
                YardPhotos = photoUrls
            };
        }

        public async Task<YardDto> UpdateYardAsync(int yardId, int ownerId, UpdateYardDto updateYardDto)
        {
            // Get the existing yard
            var yard = await _yardRepository.GetYardByIdAsync(yardId);

            if (yard == null || yard.OwnerID != ownerId)
                return null;

            // Update the yard properties
            yard.YardName = updateYardDto.YardName ?? yard.YardName;
            yard.YardLocation = updateYardDto.YardLocation ?? yard.YardLocation;
            yard.YardArea = updateYardDto.YardArea > 0 ? updateYardDto.YardArea : yard.YardArea;
            yard.ServicesOffered = updateYardDto.ServicesOffered ?? yard.ServicesOffered;

            // Handle the photos
            var currentPhotos = string.IsNullOrEmpty(yard.YardPhotos)
                ? new List<string>()
                : JsonSerializer.Deserialize<List<string>>(yard.YardPhotos);

            // Keep only the existing photos that were not removed
            if (updateYardDto.ExistingPhotoUrls != null)
            {
                var photosToRemove = currentPhotos.Except(updateYardDto.ExistingPhotoUrls).ToList();

                foreach (var photoUrl in photosToRemove)
                {
                    _fileService.DeleteFile(photoUrl);
                }

                currentPhotos = updateYardDto.ExistingPhotoUrls;
            }

            // Add new photos
            if (updateYardDto.NewYardPhotos != null && updateYardDto.NewYardPhotos.Count > 0)
            {
                var newPhotoUrls = await _fileService.SaveFilesAsync(updateYardDto.NewYardPhotos, "yards");
                currentPhotos.AddRange(newPhotoUrls);
            }

            // Update the yard photos
            yard.YardPhotos = JsonSerializer.Serialize(currentPhotos);

            // Save the changes
            await _yardRepository.UpdateYardAsync(yard);

            return new YardDto
            {
                YardID = yard.YardID,
                YardName = yard.YardName,
                YardLocation = yard.YardLocation,
                YardArea = yard.YardArea,
                ServicesOffered = yard.ServicesOffered,
                YardPhotos = currentPhotos
            };
        }

        public async Task DeleteYardAsync(int yardId, int ownerId)
        {
            var yard = await _yardRepository.GetYardByIdAsync(yardId);

            if (yard == null || yard.OwnerID != ownerId)
                return;

            // Delete the yard photos
            if (!string.IsNullOrEmpty(yard.YardPhotos))
            {
                var photoUrls = JsonSerializer.Deserialize<List<string>>(yard.YardPhotos);

                foreach (var photoUrl in photoUrls)
                {
                    _fileService.DeleteFile(photoUrl);
                }
            }

            // Delete the yard
            await _yardRepository.DeleteYardAsync(yardId);
        }
    }
}