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
        public DateOnly BookingDate { get; set; }
        public TimeOnly BookingTime { get; set; }
        public decimal AmountPaid { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentMethod { get; set; }

        // Navigation properties
        public Yard Yard { get; set; }
        public User User { get; set; }


    }
}
