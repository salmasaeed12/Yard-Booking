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
        public string YardID { get; set; }

        public string OwnerID { get; set; }  

        [ForeignKey("OwnerID")]
        public virtual ApplicationUser User { get; set; }

        [StringLength(200)]
        public string YardLocation { get; set; }

        public string YardArea { get; set; }

        public bool? ServicesOffered { get; set; }

        public List<string> YardPhotos { get; set; } = new List<string>();

        // Navigation properties
        public virtual ICollection<Yard> Yards { get; set; }
    }
}
