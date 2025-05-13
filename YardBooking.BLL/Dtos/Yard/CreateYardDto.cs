using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardBooking.BLL.Dtos.Yard
{
    public class CreateYardDto
    {
        public string YardName { get; set; }
        public string YardLocation { get; set; }
        public double YardArea { get; set; }
        public string ServicesOffered { get; set; }
        public string YardPhotos { get; set; }
    }
}
