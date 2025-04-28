using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.Data.Models;

namespace YardBooking.DAL.temp
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }

        public string TeamName { get; set; }

        [ForeignKey("Captain")]
        public int CaptainID { get; set; }

        public string Members { get; set; }

        // Navigation Properties
        public User Captain { get; set; }
        public Yard Yard { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<TeamMember> TeamMembers { get; set; }

    }
}
