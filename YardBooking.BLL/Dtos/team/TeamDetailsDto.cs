using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.BLL.Dtos.Booking;
using YardBooking.BLL.Dtos.TeamMember;

namespace YardBooking.BLL.Dtos.team
{
    public class TeamDetailsDto : TeamDto
    {
        public List<TeamMemberDto> Members { get; set; }
        public List<BookingDto> Bookings { get; set; }
    }
}
