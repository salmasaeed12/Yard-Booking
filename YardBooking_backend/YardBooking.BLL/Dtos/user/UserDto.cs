using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.Data.enums;

namespace YardBooking.BLL.Dtos.user
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string IDNumber { get; set; }
        public string IDPhoto { get; set; }
        public string PersonPhoto { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Location { get; set; }
        public string Gender { get; set; }
        public UserRole Role { get; set; }
    }
}
