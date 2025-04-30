using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardBooking.BLL.Dtos.AccountDto
{
    public class AuthResponseDto
    {
        public bool IsSuccessful { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public List<string> Roles { get; set; }
        public string Message { get; set; }
    }
}
