using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardBooking.BLL.Dtos.user
{
    public class UserUpdateDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string IDNumber { get; set; }
        public string IDphoto { get; set; }
        public string PersonPhoto { get; set; }
        public string PhoneNumber { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


    }
}
