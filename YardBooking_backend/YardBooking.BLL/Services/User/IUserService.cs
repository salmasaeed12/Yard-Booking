using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.BLL.Dtos.user;
namespace YardBooking.BLL.Services.User
{
    interface IUserService
    {
        bool UpdateProfile(UserUpdateDto user);
        bool ChangePassword(UserUpdateDto user , string oldPassword,string newPassword);
        bool ResetPassword(UserUpdateDto User,string newPassword);
        bool DeleteAccount(UserReadDto user);
        IEnumerable<UserReadDto> GetUserDetails(string username);
        IQueryable<UserReadDto> GetAllUsers();
    }
}
