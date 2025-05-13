using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.Data.Models;

namespace YardBooking.BLL.Dtos.TeamMember
{
    public class TeamMemberReadDto
    {
        // Navigation Properties
        public Team Team { get; set; }
        public User User { get; set; }
    }
}
