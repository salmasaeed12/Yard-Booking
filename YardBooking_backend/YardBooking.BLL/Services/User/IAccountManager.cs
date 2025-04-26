using YardBooking.BLL.Dtos.AccountDto;

namespace HospitalSystem.BLL.Manager
{
    public interface IAccountManager
    {
        Task<string> LoginOwner(LoginDto loginDto);
        Task<string> RegisterOwner(RegisterDto   registerDto);
        Task<string> LoginPlayer(LoginDto loginDto);
        Task<string> RegisterPlayer(RegisterDto registerDto);

    }
}
