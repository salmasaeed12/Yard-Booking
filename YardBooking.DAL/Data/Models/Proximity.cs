using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardBooking.DAL.Data.Models
{
    public class Proximity
    {
        [Key]
        public int ProximityID { get; set; }

        [Required]
        public int YardID { get; set; }

        [Required]
        public int UserID { get; set; }

        public double Distance { get; set; }

        // Navigation properties
        [ForeignKey("YardID")]
        public virtual Yard Yard { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}
