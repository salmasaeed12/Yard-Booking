using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YardBooking.DAL.Data.Models;

namespace YardBooking.DAL.Repository
{
    public interface IUserRepo
    {
        // Basic CRUD Operations
        IEnumerable<User> GetAllUsers();
        User GetUserById(int userId);
        User GetUserByUsername(string username);

        User CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int userId);

        // Authentication Related
        User AuthenticateUser(string email, string password);
        bool ChangePassword(int userId, string currentPassword, string newPassword);
        bool ResetPassword(string email);

        // Role Management
        IQueryable<User> GetUsersByRole(string role);

        // Profile Management
        bool UpdateProfilePhoto(int userId, string photoUrl);

        //// Search & Filter
        //IQueryable<User> SearchUsers(string searchTerm);
        //IQueryable<User> FilterUsersByLocation(string location);

        //// Validation
        //bool IsEmailUnique(string email);
        //bool IsPhoneUnique(string phoneNumber);

        //// Statistics
        //int GetTotalUsersCount();
        //Dictionary<string, int> GetUserCountByRole();
    }
}
