using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.Data.enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YardBooking.DAL.Data.Models;

namespace YardBooking.DAL.Data.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        public DateTime BookingDate { get; set; }

        [ForeignKey("Yard")]
        public int YardId { get; set; }
        public virtual Yard Yard { get; set; }

        [ForeignKey("Schedule")]
        public int ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }

        public string Status { get; set; } = "Pending"; // Pending, Confirmed, Cancelled

        // Navigation properties
        public virtual ICollection<TeamBooking> TeamBookings { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
