using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardBooking.DAL.Data.Models
{
    public class YardOwner
    {
        [Key]
        public int YardID { get; set; }

        [Required]
        public int OwnerID { get; set; }

        [Required]
        public int UserID { get; set; }

        [StringLength(100)]
        public string YardName { get; set; }

        [StringLength(200)]
        public string YardLocation { get; set; }

        public string YardArea { get; set; }

        public string ServicesOffered { get; set; }

        public string YardPhotos { get; set; }

        // Navigation properties
        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [ForeignKey("YardID")]
        public virtual Yard Yard { get; set; }
    }
}
