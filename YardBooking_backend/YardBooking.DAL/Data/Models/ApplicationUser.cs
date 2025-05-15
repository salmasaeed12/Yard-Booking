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
        public string PhoneNumber { get; set; } 
        public string ProfilePhoto { get; set; }
        public string DateOfBirth { get; set; }
        public string PersonalNumber { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; } 
        public string Role { get; set; } 
        public string Location { get; set; }
        public string Gender { get; set; }
        public string Schedule { get; set; }
    }
}
