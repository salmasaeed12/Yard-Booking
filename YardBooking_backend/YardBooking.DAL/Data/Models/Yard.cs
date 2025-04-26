using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardBooking.DAL.Data.Models
{
    public class Yard
    {
        [Key]
        public int YardID { get; set; }

        [ForeignKey("User")]
        public int OwnerID { get; set; }
        // latitude
        public string YardLatitude { get; set; }
        // longitude
        public string YardLongitude { get; set; }
        public string YardName { get; set; }
        public string YardArea { get; set; }
        public string ServicesOffered { get; set; }
        public string YardPhotos { get; set; }

        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }


        // Navigation Properties
        public User Owner { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Offer> Offers { get; set; }
        public ICollection<Booking> Bookings { get; set; }

    }
}
