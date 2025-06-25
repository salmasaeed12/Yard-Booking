using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YardBooking.DAL.Data.Models;

namespace YardBooking.DAL.temp
{
    public class TeamMember
    {
        [Key]
        public int TeamMemberID { get; set; }

        [ForeignKey("Team")]
        public int TeamID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public DateTime JoinDate { get; set; }

        // Navigation Properties
        public Team Team { get; set; }
        public User User { get; set; }
    }
}