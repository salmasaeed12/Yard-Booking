using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace YardBooking.DAL.Data.Models
{
    public class Offer
    {
        public int OfferId { get; set; }
        public int YardId { get; set; }
        public string OfferDetails { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
        public decimal DiscountPercentage { get; set; }

        // Navigation property
        public virtual Yard Yard { get; set; }
    }
}