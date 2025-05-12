using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using YardBooking.BLL.Dtos.AccountDto;
using YardBooking.BLL.IServices;

namespace YardBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.RegisterAsync(registerDto);

            if (!result.IsSuccessful)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginDto loginDto)
        {
            var result =  _authService.LoginAsync(loginDto);
            if (!result.Result.IsSuccessful)
            {
                return Unauthorized(result);
            }

            return Ok(result);
        }

        //[HttpPost("refresh-token")]
        //public async Task<IActionResult> RefreshToken(RefreshTokenDto model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var result = await _authService.RefreshTokenAsync(model.Token);
        //    if (!result.IsSuccessful)
        //    {
        //        return BadRequest(result);
        //    }

        //    return Ok(result);
        //}

        //[Authorize]
        //[HttpPost("revoke-token")]
        //public async Task<IActionResult> RevokeToken(RefreshTokenDto model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var result = await _authService.RevokeTokenAsync(model.Token);
        //    if (!result)
        //    {
        //        return BadRequest(new { Message = "Invalid token" });
        //    }

        //    return Ok(new { Message = "Token revoked" });
        //}

        [Authorize] // تأكد إن المستخدم مسجل دخوله
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                return Unauthorized("User ID not found in token.");

            var result = await _authService.ChangePasswordAsync(userId, dto);

            if (!result.IsSuccessful)
                return BadRequest(result);

            return Ok(result);
        }

    }
}