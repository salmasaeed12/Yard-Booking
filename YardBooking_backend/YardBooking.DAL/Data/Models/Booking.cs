using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.Data.enums;

namespace YardBooking.DAL.Data.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public int YardId { get; set; }
        public int ScheduleId { get; set; }
        public BookingStatus Status { get; set; } = BookingStatus.Pending;

        // Navigation properties
        public virtual Yard Yard { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual ICollection<TeamBooking> TeamBookings { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }

        public Booking()
        {
            TeamBookings = new HashSet<TeamBooking>();
            Payments = new HashSet<Payment>();
        }
    }
}
