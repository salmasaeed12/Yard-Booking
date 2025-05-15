using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardBooking.BLL.Dtos.Yard
{
    public class YardUpdateDto
    {
        [Required]
        [StringLength(100)]
        public string YardName { get; set; }

        [StringLength(200)]
        public string YardLocation { get; set; }

        public double? YardArea { get; set; }

        public bool? ServicesOffered { get; set; }

        public List<string> YardPhotos { get; set; } = new List<string>();
    }
}
