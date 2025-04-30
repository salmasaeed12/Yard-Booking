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
        Task<AuthResponseDto> RegisterAsync(RegisterDto model);
        Task<AuthResponseDto> LoginAsync(LoginDto model);
        Task<AuthResponseDto> RefreshTokenAsync(string token);
        Task<bool> RevokeTokenAsync(string token);
        Task<bool> ChangePasswordAsync(string userId, ChangePasswordDto model);
    }
}
