using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardBooking.DAL.Data.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public int YardID { get; set; }
        public int UserID { get; set; }
        public string Proximity { get; set; }
    }
}
