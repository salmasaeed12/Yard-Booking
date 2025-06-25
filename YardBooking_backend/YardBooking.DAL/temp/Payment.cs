using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace YardBooking.DAL.temp
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [ForeignKey("Booking")]
        public int BookingID { get; set; }

        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public string TransactionID { get; set; }

        // Navigation Properties
        public Booking Booking { get; set; }
    }
}