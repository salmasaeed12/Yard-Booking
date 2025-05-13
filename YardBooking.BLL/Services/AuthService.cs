using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
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
using YardBooking.DAL.Repository;

namespace YardBooking.Application.Services
{
    public class AuthService : IAuthService
    {

        private readonly IUserRepo _userRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration; 

        public AuthService(IUserRepo userRepo, IMapper mapper,IConfiguration configuration, UserManager<ApplicationUser> userManager )
        {
            _userManager = userManager;
            _userRepo = userRepo;
            _mapper = mapper;
            _configuration = configuration;
        }

        public  async Task<AuthResponseDto> RegisterAsync(RegisterDto RegisterDto)
        {
            ApplicationUser applicationUser = new ApplicationUser();
            applicationUser.Email = RegisterDto.Email;
            applicationUser.UserName = RegisterDto.Name;
            applicationUser.address= RegisterDto.address;
            applicationUser.PhoneNumber = RegisterDto.PhoneNumber;
            applicationUser.Gender = RegisterDto.Gender;
            applicationUser.Role = RegisterDto.Role;

            var identityResult = await _userManager.CreateAsync(applicationUser, RegisterDto.Password);
            if (identityResult.Succeeded)
            {
                List<Claim> Claims = new List<Claim>();
                Claims.Add(new Claim(ClaimTypes.Email, applicationUser.Email));
                Claims.Add(new Claim(ClaimTypes.Role, applicationUser.Role));
                Claims.Add(new Claim(ClaimTypes.StreetAddress, applicationUser.Id));
                Claims.Add(new Claim("name", applicationUser.UserName));
                string token = GenerateJwtToken(Claims);
                return new AuthResponseDto
                {
                    IsSuccessful = true,
                    Message = "User Register successfully!",
                    Token = token
                };
            }
            else
            {
                return new AuthResponseDto
                {
                    IsSuccessful = false,
                    Message = "User Register failed!",
                    Token = null
                };
            }   
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
        {
            ApplicationUser applicationUser = new ApplicationUser();
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
           if(user == null)
            {
                return new AuthResponseDto
                {
                    IsSuccessful = false,
                    Message = "Invalid Email or Password Try Again!",
                    Token = null
                };
            }
            bool result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!result)
            {
                return new AuthResponseDto
                {
                    IsSuccessful = false,
                    Message = "Invalid Email or Password Try Again!",
                    Token = null
                };
            }

            var claims = _userManager.GetClaimsAsync(user).Result.ToList();
            string tokenString = GenerateJwtToken(claims);
            return new AuthResponseDto
            {
                IsSuccessful = true,
                Message = "User Login successfully!",
                Token = tokenString
            };
        }


        public async Task<AuthResponseDto> ChangePasswordAsync(string userId, ChangePasswordDto dto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new AuthResponseDto
                {
                    IsSuccessful = false,
                    Message = "User not found"
                };
            }

            var result = await _userManager.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword);

            if (!result.Succeeded)
            {
                return new AuthResponseDto
                {
                    IsSuccessful = false,
                    Message = string.Join("; ", result.Errors.Select(e => e.Description))
                };
            }

            return new AuthResponseDto
            {
                IsSuccessful = true,
                Message = "Password changed successfully"
            };
        }



        private string GenerateJwtToken(List<Claim> claims)
        {
            string key = _configuration.GetSection("Jwt:Key").Value;
            SecurityKey secKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            SigningCredentials creds = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256);
            var expireDate = DateTime.UtcNow.AddDays(1);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("Jwt:Issuer"),
                audience: _configuration.GetValue<string>("Jwt:Audience"),
                claims: claims,
                expires: expireDate,
                signingCredentials: creds
            );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }


    }
}
