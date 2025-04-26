using HospitalSystem.BLL.Manager;
using Microsoft.AspNetCore.Mvc;
using YardBooking.BLL.Dtos.AccountDto;

namespace YardBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountManager _accountManager;

        public AccountsController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            var result = await _accountManager.Login(loginDto);
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(result);
        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            var result = await _accountManager.Register(registerDto);
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
