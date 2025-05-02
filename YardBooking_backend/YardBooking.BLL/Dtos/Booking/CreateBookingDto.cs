using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardBooking.BLL.Dtos.Booking
{
    public class CreateBookingDto
    {
        public DateTime BookingDate { get; set; }
        public int YardID { get; set; }
        public int ScheduleID { get; set; }
    }
}
