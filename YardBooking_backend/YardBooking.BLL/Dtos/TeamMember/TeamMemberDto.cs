using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardBooking.BLL.Dtos.TeamMember
{
    public class TeamMemberDto
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
