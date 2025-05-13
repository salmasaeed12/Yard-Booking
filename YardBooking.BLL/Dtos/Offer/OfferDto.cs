using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardBooking.BLL.Dtos.Offer
{
    public class OfferDto
    {
        public int OfferId { get; set; }
        public int YardId { get; set; }
        public string OfferDetails { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
        public decimal DiscountPercentage { get; set; }
    }
}
