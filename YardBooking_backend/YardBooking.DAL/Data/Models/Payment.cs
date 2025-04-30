using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YardBooking.DAL.Data.enums;
namespace YardBooking.DAL.Data.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int BookingId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
        public string TransactionId { get; set; }

        // Navigation property
        public virtual Booking Booking { get; set; }
    }
}