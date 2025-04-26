using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YardBooking.BLL.Dtos.AccountDto;
using YardBooking.DAL.Data.Models;

namespace HospitalSystem.BLL.Manager
{
    public class AccountManager: IAccountManager
    {
        private readonly UserManager<ApplcationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AccountManager(UserManager<ApplcationUser> userManager , IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> LoginOwner(LoginDto loginDto)
        {
           var user = await _userManager.FindByNameAsync(loginDto.Name);
           if (user == null)
            {
                return null;
            }

            var check =await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (check == null)
            {
                return null;
            }

            var claims= await _userManager.GetClaimsAsync(user);
            return GenerateToken(claims);
        }

        public async Task<string> RegisterOnwer(RegisterDto registerDto)
        {
            ApplcationUser user = new ApplcationUser();
            user.Email = registerDto.Email;
            user.UserName = registerDto.Name;


            var result =  await   _userManager.CreateAsync(user, registerDto.Password);

            if(result.Succeeded)
            {
                //create token
                List<Claim> claims = new List<Claim>();

                claims.Add(new Claim("Role", "Onwer"));
                claims.Add(new Claim("Name", registerDto.Name));

                await _userManager.AddClaimsAsync(user,claims);
                
                return  GenerateToken(claims);
            }
            return null;
        }


        //player
        public async Task<string> LoginPlayer(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Name);
            if (user == null)
            {
                return null;
            }

            var check = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (check == null)
            {
                return null;
            }

            var claims = await _userManager.GetClaimsAsync(user);
            return GenerateToken(claims);
        }

        public async Task<string> RegisterPlayer(RegisterDto registerDto)
        {
            ApplcationUser user = new ApplcationUser();
            user.Email = registerDto.Email;
            user.UserName = registerDto.Name;


            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                //create token
                List<Claim> claims = new List<Claim>();

                claims.Add(new Claim("Role", "Player"));
                claims.Add(new Claim("Name", registerDto.Name));

                await _userManager.AddClaimsAsync(user, claims);

                return GenerateToken(claims);
            }
            return null;
        }

        private string GenerateToken(IList<Claim> claims)
        {
            var securitykeystring = _configuration.GetSection("SecretKey").Value;
            var securtykeyByte = Encoding.ASCII.GetBytes(securitykeystring);
            SecurityKey securityKey = new SymmetricSecurityKey(securtykeyByte);
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var expire = DateTime.UtcNow.AddDays(2);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(claims: claims, expires: expire, signingCredentials: signingCredentials);


            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            string token = handler.WriteToken(jwtSecurityToken);

            return token;
        }
    }
}
