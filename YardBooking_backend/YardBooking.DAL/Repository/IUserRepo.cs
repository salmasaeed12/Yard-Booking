using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.Data.Models;

namespace YardBooking.DAL.Repository
{
    public interface IUserRepo
    {
        // Basic CRUD Operations
        Task<IQueryable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int userId);

        // Authentication Related
        Task<User> AuthenticateUserAsync(string email, string password);
        Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword);
        Task<bool> ResetPasswordAsync(string email);

        // Role Management
        Task<IQueryable<User>> GetUsersByRoleAsync(string role);
        Task<bool> AssignRoleToUserAsync(int userId, string role);

        // Profile Management
        Task<bool> UpdateProfilePhotoAsync(int userId, string photoUrl);

        // Search & Filter
        Task<IQueryable<User>> SearchUsersAsync(string searchTerm);
        Task<IQueryable<User>> FilterUsersByLocationAsync(string location);

        // Validation
        Task<bool> IsEmailUniqueAsync(string email);
        Task<bool> IsPhoneUniqueAsync(string phoneNumber);

        // Statistics
        Task<int> GetTotalUsersCountAsync();
        Task<Dictionary<string, int>> GetUserCountByRoleAsync();
    }
}
