using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardBooking.DAL.Data.Models
{
    public class Offer
    {
        public int OfferID { get; set; }
        public int YardID { get; set; }
        public string OfferDetails { get; set; }
        public DateTime ValidUntil { get; set; }
    }
}
