using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.BLL.Dtos.TeamMember;
using YardBooking.DAL.Data.enums;

namespace YardBooking.BLL.Dtos.team
{
    public class CreateTeamDto
    {
        public string TeamName { get; set; }
    }
}
