using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YardBooking.BLL.DTOs
{
    // DTO for creating a new yard
    public class CreateYardDto
    {
        [Required]
        public string YardName { get; set; }

        [Required]
        public string YardLocation { get; set; }

        public decimal YardArea { get; set; }

        public string ServicesOffered { get; set; }

        // This won't be stored directly in the database
        // We'll process these files and store their paths
        public List<IFormFile> YardPhotos { get; set; }
    }

    // DTO for returning yard data
    public class YardDto
    {
        public int YardID { get; set; }
        public string YardName { get; set; }
        public string YardLocation { get; set; }
        public decimal YardArea { get; set; }
        public string ServicesOffered { get; set; }
        public List<string> YardPhotos { get; set; }
    }

    // DTO for updating a yard
    public class UpdateYardDto
    {
        public string YardName { get; set; }
        public string YardLocation { get; set; }
        public decimal YardArea { get; set; }
        public string ServicesOffered { get; set; }
        public List<IFormFile> NewYardPhotos { get; set; }
        public List<string> ExistingPhotoUrls { get; set; }
    }
}