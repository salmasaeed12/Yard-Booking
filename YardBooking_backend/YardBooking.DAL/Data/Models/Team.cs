using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardBooking.DAL.Data.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public int CaptainID { get; set; }
        public string YardArea { get; set; }
        public string YardLocation { get; set; }
        public ICollection<User> Members { get; set; }
    }
}
