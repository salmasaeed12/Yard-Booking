using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.temp;

namespace YardBooking.DAL.Data.Models
{
    public class Yard
    {
        [Key]
        public int YardID { get; set; }
        // latitude
        public string YardLatitude { get; set; }
        // longitude
        public string YardLongitude { get; set; }
        public string YardName { get; set; }
        public string YardArea { get; set; }
        public string ServicesOffered { get; set; }
        public string YardPhotos { get; set; }
        // Foreign Key
        [ForeignKey("User")]
        public int UserId { get; set; }
        // Navigation Properties
        public User User { get; set; }


        //public ICollection<Schedule> Schedules { get; set; }
        //public ICollection<Offer> Offers { get; set; }
        //public ICollection<Booking> Bookings { get; set; }

    }
}
