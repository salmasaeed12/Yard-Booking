using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardBooking.BLL.Dtos.TeamBooking
{
    public class TeamBookingDto
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int BookingId { get; set; }
    }
}
