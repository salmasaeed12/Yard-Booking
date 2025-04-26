using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YardBooking.DAL.Data.Models;
namespace YardBooking.DAL.Data.Models
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