using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YardBooking.DAL.Data.enums;
using YardBooking.DAL.temp;

namespace YardBooking.DAL.Data.Models
{
    public class User : IdentityUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string IDNumber { get; set; }
        public string IDphoto { get; set; }
        public string PersonPhoto { get; set; }

        public string PhoneNumber { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        public Location Location { get; set; }
        public string Gender { get; set; }
        public ICollection<Yard> Yards { get; set; }
        //public ICollection<Booking> Bookings { get; set; }


    }
}
