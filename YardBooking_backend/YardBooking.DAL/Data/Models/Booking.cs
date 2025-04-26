using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardBooking.DAL.Data.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int YardID { get; set; }
        public int UserID { get; set; }
        public int ScheduleID { get; set; }

        public DateOnly BookingDate { get; set; }


        // Navigation properties
        public Yard Yard { get; set; }
        public User User { get; set; }
        public Schedule Schedule { get; set; }
        public Payment Payment { get; set; }
        public ICollection<Team> Teams { get; set; }


    }
}
