using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.BLL.Dtos.TeamMember;
using YardBooking.BLL.Dtos.user;
using YardBooking.DAL.Data.enums;

namespace YardBooking.BLL.Dtos.team
{
    public class TeamReadDto
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public int CaptainID { get; set; }

        // Include captain details
        public UserReadDto Captain { get; set; }
        // Include team members information
        public ICollection<TeamMemberReadDto> TeamMembers { get; set; }

    }
}
