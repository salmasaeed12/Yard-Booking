using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using YardBooking.BLL.Dtos.AccountDto;
using YardBooking.BLL.IServices;
using YardBooking.DAL.Data.Models;
using YardBooking.DAL.Inerfaces;

namespace YardBooking.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _userManager = userManager;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
            {
                return new AuthResponseDto
                {
                    IsSuccessful = false,
                    Message = "User already exists!"
                };
            }

            // Use AutoMapper to map RegisterDto to ApplicationUser
            var user = _mapper.Map<ApplicationUser>(model);
            user.UserName = model.Email; // Ensure username is set to email
            user.SecurityStamp = Guid.NewGuid().ToString();

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return new AuthResponseDto
                {
                    IsSuccessful = false,
                    Message = string.Join(", ", result.Errors.Select(e => e.Description))
                };
            }

            await _userManager.AddToRoleAsync(user, model.Role.ToString());

            return await GenerateJwtToken(user);
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new AuthResponseDto
                {
                    IsSuccessful = false,
                    Message = "Invalid credentials"
                };
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!isPasswordValid)
            {
                return new AuthResponseDto
                {
                    IsSuccessful = false,
                    Message = "Invalid credentials"
                };
            }

            return await GenerateJwtToken(user);
        }

        public async Task<AuthResponseDto> RefreshTokenAsync(string token)
        {
            var refreshToken = await _unitOfWork.RefreshTokens.SingleOrDefaultAsync(r => r.Token == token);
            if (refreshToken == null || !refreshToken.IsActive)
            {
                return new AuthResponseDto
                {
                    IsSuccessful = false,
                    Message = "Invalid refresh token"
                };
            }

            var user = await _userManager.FindByIdAsync(refreshToken.UserId);
            if (user == null)
            {
                return new AuthResponseDto
                {
                    IsSuccessful = false,
                    Message = "User not found"
                };
            }

            // Generate new tokens
            var newTokenResponse = await GenerateJwtToken(user);

            // Revoke current refresh token
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.ReplacedByToken = newTokenResponse.RefreshToken;

            // Save changes
            await _unitOfWork.CompleteAsync();

            return newTokenResponse;
        }

        public async Task<bool> RevokeTokenAsync(string token)
        {
            var refreshToken = await _unitOfWork.RefreshTokens.SingleOrDefaultAsync(r => r.Token == token);
            if (refreshToken == null || !refreshToken.IsActive)
            {
                return false;
            }

            // Revoke token
            refreshToken.Revoked = DateTime.UtcNow;
            await _unitOfWork.CompleteAsync();

            return true;
        }

        public async Task<bool> ChangePasswordAsync(string userId, ChangePasswordDto model)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            return result.Succeeded;
        }

        private async Task<AuthResponseDto> GenerateJwtToken(ApplicationUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var tokenValidityInMinutes = Convert.ToInt32(_configuration["JWT:ValidityInMinutes"]);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(authClaims),
                Expires = DateTime.UtcNow.AddMinutes(tokenValidityInMinutes),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var refreshToken = GenerateRefreshToken();

            // Save the refresh token
            user.RefreshTokens.Add(new RefreshToken
            {
                Token = refreshToken,
                UserId = user.Id,
                Created = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays(7),
                CreatedByIp = "127.0.0.1" // In a real app, get the IP from the request
            });

            await _unitOfWork.CompleteAsync();

            return new AuthResponseDto
            {
                IsSuccessful = true,
                Token = tokenHandler.WriteToken(token),
                RefreshToken = refreshToken,
                Expiration = tokenDescriptor.Expires.Value,
                UserId = user.Id,
                Email = user.Email,
                Name = user.Name,
                Roles = userRoles.ToList(),
                Message = "Authentication successful"
            };
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
