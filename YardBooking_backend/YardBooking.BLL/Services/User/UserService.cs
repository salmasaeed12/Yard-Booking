using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.BLL.AutoMapper;
using YardBooking.BLL.Dtos.user;
using YardBooking.DAL.Repository;

namespace YardBooking.BLL.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;

        public UserService(IUserRepo userRepo, IMapper mapper )
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }
        public bool ChangePassword(UserReadDto user,string oldPassword, string newPassword)
        {
            // Validate the old password
            var user = _userRepo.GetUserByUsername(user.username);
            if (user == null || !VerifyPassword(oldPassword, user.Password))
            {
                return false; // Invalid credentials
            }
            // Update the password
            user.Password = HashPassword(newPassword);
            return _userRepo.UpdateUser(user);
        }

        public bool DeleteAccount(UserReadDto user)
        {
            // Validate the user
            var existingUser = _userRepo.GetUserById(user.UserId);
            if (existingUser == null)
            {
                return false; // User not found
            }
            // Delete the user from the repository
            return _userRepo.DeleteUser(existingUser.UserId);
        }

        public IEnumerable<UserReadDto> GetAllUsers()
        {
            return _mapper.Map<IEnumerable<UserReadDto>>(_userRepo.GetAllUsers());
        }

        public IEnumerable<UserReadDto> GetUserDetails(string username)
        {
            return _mapper.Map<IEnumerable<UserReadDto>>(_userRepo.GetUserByUsername(username));
        }

        public bool ResetPassword(string email,)
        {

        }

        public bool UpdateProfile(UserUpdateDto user)
        {
            // Validate the user
            var existingUser = _userRepo.GetUserById(user.UserId);
            if (existingUser == null)
            {
                return false; // User not found
            }
            // Map the updated properties
            _mapper.Map(user, existingUser);
            // Update the user in the repository
            return _userRepo.UpdateUser(existingUser);
        }
    }
}
