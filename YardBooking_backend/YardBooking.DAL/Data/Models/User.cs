using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YardBooking.DAL.Data.enums;

namespace YardBooking.DAL.Data.Models
{
    public class User : IdentityUser
    {
        [Key]
        public int UserId { get; set; }
        public string username { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public string IDNumber { get; set; }
        public string IDphoto { get; set; }
        public string PersonPhoto { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public DateOnly DateOfBirth { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        public UserRole Role { get; set; }

        public string Location { get; set; }
        public string Gender { get; set; }


        public ICollection<Yard> Yards { get; set; }
        public ICollection<Booking> Bookings { get; set; }


    }
}
