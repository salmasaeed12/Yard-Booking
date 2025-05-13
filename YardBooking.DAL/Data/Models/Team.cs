using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardBooking.DAL.Data.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }

        // Foreign key for captain
        public string CaptainId { get; set; }
        public virtual ApplicationUser Captain { get; set; }

        // Navigation properties
        public virtual ICollection<TeamMember> Members { get; set; }
        public virtual ICollection<TeamBooking> TeamBookings { get; set; }

        public Team()
        {
            Members = new HashSet<TeamMember>();
            TeamBookings = new HashSet<TeamBooking>();
        }
    }
}
