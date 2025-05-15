using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardBooking.DAL.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Yard
    {
        [Key]
        public int YardID { get; set; }

        [Required]
        [StringLength(100)]
        public string YardName { get; set; }

        [StringLength(200)]
        public string YardLocation { get; set; }

        public double? YardArea { get; set; }

        public bool? ServicesOffered { get; set; }

        public List<string> YardPhotos { get; set; } = new List<string>();

        
        [Required]
        public string OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual YardOwner Owner { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<Proximity> Proximities { get; set; }
    }

}

