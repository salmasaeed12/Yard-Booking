using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.Data.enums;

namespace YardBooking.DAL.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime DateOfBirth { get; set; }
        public string ? address { get; set; }
        public string Gender { get; set; }
        public  ICollection<TeamMember> TeamMemberships { get; set; }
        public  ICollection<Yard> OwnedYards { get; set; }

    }
}
