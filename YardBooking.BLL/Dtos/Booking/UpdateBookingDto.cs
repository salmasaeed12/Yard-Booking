using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.Data.enums;

namespace YardBooking.BLL.Dtos.Booking
{
    public class UpdateBookingDto
    {
        public DateTime BookingDate { get; set; }
        public int YardID { get; set; }
        public int ScheduleID { get; set; }
        public string Status { get; set; }
    }
}
