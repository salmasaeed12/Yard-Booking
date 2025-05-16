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
        [Column(Order = 0)]
        public int YardID { get; set; }

        [Key]
        [Column(Order = 1)]
        public string UserID { get; set; }

        [Required]
        public double Distance { get; set; }

        // Navigation properties
        [ForeignKey("YardID")]
        public virtual Yard Yard { get; set; }

        [ForeignKey("UserID")]
        public virtual ApplicationUser User { get; set; }  // هنا التعديل
    }
}

