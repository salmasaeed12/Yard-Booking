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
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration; 

        public AuthService(IUserRepo userRepo, IMapper mapper,IConfiguration configuration )
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _configuration = configuration;
        }

        public  AuthResponseDto Register(RegisterDto model)
        {
            var userExists =  _userRepo.GetUserByEmail(model.Email);
            if (userExists != null)
            {
                return new AuthResponseDto
                {
                    IsSuccessful = false,
                    Message = "User already exists!"
                };
            }
            // hash password
            var passwordHash = new PasswordHasher<ApplicationUser>().HashPassword();
            // use automapper to map the model to the user entity
            var user = _mapper.Map<ApplicationUser>(model);
            user.PasswordHash = passwordHash;
            return new AuthResponseDto
            {
                IsSuccessful = true,
                Message = "User created successfully!",
                Token = 
            };
        }

        public AuthResponseDto Login(LoginDto model)
        {
            var user =  _userRepo.GetUserByEmail(model.Email);
            if (user == null)
            {
                return new AuthResponseDto
                {
                    IsSuccessful = false,
                    Message = "Invalid credentials"
                };
            }

            var isPasswordValid =  _userRepo.VerifyPassword(user, model.Password);
            if (!isPasswordValid)
            {
                return new AuthResponseDto
                {
                    IsSuccessful = false,
                    Message = "Invalid credentials"
                };
            }
            List <Claim> Claims = new List<Claim>();
            Claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            Claims.Add(new Claim(ClaimTypes.Email, user.Email));
            Claims.Add(new Claim(ClaimTypes.Role, user.Role));
            Claims.Add(new Claim("name", user.Name));

            string key = _configuration.GetValue<string>("Jwt:Key");
            SecurityKey secKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            SigningCredentials creds = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256);
            
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("Jwt:Issuer"),
                audience: _configuration.GetValue<string>("Jwt:Audience"),
                claims: Claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new AuthResponseDto
            {
                IsSuccessful = true,
                Message = "User Login successfully!",
                Token = tokenString
            }
                ;
        }   
        public bool ChangePassword(string userId, ChangePasswordDto model)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            return result.Succeeded;
        }




        public string GenerateJwtToken(RegisterDto model)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, model.Email), // user Email
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // unique JWT identifier
                new Claim(ClaimTypes.Role, model.Role) // user Role
            };

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "your-app",
                audience: "your-app",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
