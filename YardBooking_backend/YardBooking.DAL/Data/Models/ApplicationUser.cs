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
        public string IDPhoto { get; set; }
        public string PersonPhoto { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Location { get; set; }
        public string Gender { get; set; }
        public UserRole Role { get; set; } = UserRole.User;

        // Navigation properties
        public virtual ICollection<TeamMember> TeamMemberships { get; set; }
        public virtual ICollection<Yard> OwnedYards { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }

        public ApplicationUser()
        {
            TeamMemberships = new HashSet<TeamMember>();
            OwnedYards = new HashSet<Yard>();
            RefreshTokens = new HashSet<RefreshToken>();
        }
    }
}
