using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YardBooking.DAL.Data.enums;

namespace YardBooking.DAL.Data.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        public string IDNumber { get; set; }
        public string IDphoto { get; set; }
        public string PersonPhoto { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public UserRole Role { get; set; }

        public string Location { get; set; }
        public string Gender { get; set; }

        [NotMapped]
        public int Age =>
            DateTime.Today.Year - DateOfBirth.Year
            - (DateOfBirth.Date > DateTime.Today.AddYears(-(DateTime.Today.Year - DateOfBirth.Year)) ? 1 : 0);

        public ICollection<Yard> Yards { get; set; }
        public ICollection<Booking> Bookings { get; set; }


    }
}
