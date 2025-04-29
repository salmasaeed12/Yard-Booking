using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace YardBooking.BLL.Services
{
    public interface IFileService
    {
        Task<List<string>> SaveFilesAsync(List<IFormFile> files, string folderName);
        void DeleteFile(string filePath);
    }
}