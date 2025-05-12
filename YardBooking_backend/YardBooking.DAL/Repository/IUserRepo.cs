using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YardBooking.DAL.Data.Models;

namespace YardBooking.DAL.Repository
{
    public interface IUserRepo
    {
        void CreateUser(ApplicationUser user);
        // find user by email
        ApplicationUser GetUserByEmail(string email);
        bool DeleteUser(int userId);
        bool ChangePassword(int userId, string currentPassword, string newPassword);
        bool ResetPassword(string email,string newPassword);
    }
}
