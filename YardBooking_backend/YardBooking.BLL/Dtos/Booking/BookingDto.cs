using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.Data.enums;

namespace YardBooking.BLL.Dtos.Booking
{
    public class BookingDto
    {
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public int YardId { get; set; }
        public string YardName { get; set; }
        public int ScheduleId { get; set; }
        public BookingStatus Status { get; set; }
    }
}
