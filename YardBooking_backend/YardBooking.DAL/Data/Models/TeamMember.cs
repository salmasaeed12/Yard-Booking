using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YardBooking.DAL.Data.Models
{
    public class TeamMember
    {
        public string TeamId { get; set; }
        public string UserId { get; set; }
        public DateTime JoinDate { get; set; }

        // Navigation properties
        public virtual Team Team { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}