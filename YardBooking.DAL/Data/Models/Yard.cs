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
        public int YardId { get; set; }
        public string YardName { get; set; }
        public string YardLocation { get; set; }
        public double YardArea { get; set; }
        public string ServicesOffered { get; set; }
        public string YardPhotos { get; set; }

        public int OwnerId { get; set; }
        public virtual User Owner { get; set; }  

        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<Proximity> Proximities { get; set; }

        public Yard()
        {
            Schedules = new HashSet<Schedule>();
            Bookings = new HashSet<Booking>();
            Offers = new HashSet<Offer>();
        }
    }

}
