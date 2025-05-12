using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YardBooking.DAL.Data.enums;

namespace YardBooking.DAL.Data.Models
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string IDNumber { get; set; }
        public string IDPhoto { get; set; }
        public string PersonPhoto { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Location { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }

        public ICollection<TeamMember> TeamMembers { get; set; }
    }
}
