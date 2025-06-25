using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace YardBooking.DAL.temp
{
    public class TeamBooking
    {
        [Key]
        public int TeamBookingID { get; set; }

        [ForeignKey("Booking")]
        public int BookingID { get; set; }

        [ForeignKey("Team")]
        public int TeamID { get; set; }

        // Navigation Properties
        public Booking Booking { get; set; }
        public Team Team { get; set; }
    }
}