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
        public string Name { get; set; }
        public string IDNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Location { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }

        // Navigation properties
        public  ICollection<TeamMember> TeamMemberships { get; set; }
        public  ICollection<Yard> OwnedYards { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; }

    }
}
