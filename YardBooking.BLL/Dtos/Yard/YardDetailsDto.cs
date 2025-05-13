using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.BLL.Dtos.Offer;
using YardBooking.BLL.Dtos.Schedule;

namespace YardBooking.BLL.Dtos.Yard
{
    public class YardDetailsDto : YardDto
    {
        public List<ScheduleDto> Schedules { get; set; }
        public List<OfferDto> Offers { get; set; }
    }
}
