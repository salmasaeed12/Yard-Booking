using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardBooking.DAL.Data.Models
{
    public class YardOwner
    {
        public int YardID { get; set; }
        public int UserID { get; set; }
        public string YardName { get; set; }
        public string YardLocation { get; set; }
        public string YardArea { get; set; }
        public string YardPhotos { get; set; }
        public string Schedule { get; set; }
        public string ServicesOffered { get; set; }

        // Navigation properties
        public Yard Yard { get; set; }
        public User User { get; set; }
    }
}
