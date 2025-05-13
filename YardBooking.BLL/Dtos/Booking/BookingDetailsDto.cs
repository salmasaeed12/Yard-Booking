using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.BLL.Dtos.Schedule;
using YardBooking.BLL.Dtos.team;
using YardBooking.BLL.Dtos.Payment;

namespace YardBooking.BLL.Dtos.Booking
{
    public class BookingDetailsDto : BookingDto
    {
        public ScheduleDto Schedule { get; set; }
        public TeamDto Team { get; set; }
        public PaymentDto Payment { get; set; }
    }
}
