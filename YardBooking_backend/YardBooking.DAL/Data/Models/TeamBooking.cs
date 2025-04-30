using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardBooking.DAL.Data.Models
{
    public class TeamBooking
    {
        public int BookingId { get; set; }
        public int TeamId { get; set; }

        // Navigation properties
        public virtual Booking Booking { get; set; }
        public virtual Team Team { get; set; }
    }
}
