using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YardBooking.DAL.Data.Models;
namespace YardBooking.DAL.Data.Models
{
    public class Offer
    {
        [Key]
        public int OfferID { get; set; }

        [ForeignKey("Yard")]
        public int YardID { get; set; }

        public string OfferDetails { get; set; }
        public DateTime ValidUntil { get; set; }
        public DateTime ValidFrom { get; set; }
        public decimal DiscountPercentage { get; set; }

        // Navigation Properties
        public Yard Yard { get; set; }
    }
}