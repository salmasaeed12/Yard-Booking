using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardBooking.BLL.Dtos.AccountDto
{
    public class AuthResponseDto
    {
        public bool IsSuccessful { get; set; }
        public string ?Token { get; set; }
        public string Role { get; set; }
        public string Message { get; set; }
    }
}
