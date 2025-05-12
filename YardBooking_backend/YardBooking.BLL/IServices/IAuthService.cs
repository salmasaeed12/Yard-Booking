using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.BLL.Dtos.AccountDto;

namespace YardBooking.BLL.IServices
{
    public interface IAuthService
    {
        AuthResponseDto Register(RegisterDto model);
        AuthResponseDto Login(LoginDto model);
        bool ChangePassword(string userId, ChangePasswordDto model);
    }
}
