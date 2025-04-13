using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardBooking.DAL.Data.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string IDno { get; set; }
        public string IDphoto { get; set; }
        public string PersonPhoto { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Location { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
    }
}
