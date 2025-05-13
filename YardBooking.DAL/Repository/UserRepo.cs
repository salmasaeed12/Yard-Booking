using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using YardBooking.DAL.Data;
using YardBooking.DAL.Data.Models;

namespace YardBooking.DAL.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly YardBookingContext _context;

        public UserRepo(YardBookingContext context)
        {
            _context = context;
        }
        // Get user by ID
        public ApplicationUser GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        // Create a new user
        public void CreateUser(ApplicationUser user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        // Delete user
        public bool DeleteUser(int userId)
        {
            var user = _context.ApplicationUsers.Find(userId);
            if (user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }
        // Change password
        public bool ChangePassword(int userId, string currentPassword, string newPassword)
        {
            var user = _context.ApplicationUsers.Find(userId);
            if (user == null)
            {
                return false;
            }
            user.PasswordHash = newPassword;
            _context.SaveChanges();
            return true;
        }

        public bool ResetPassword(string email, string newPassword)
        {
            var user = _context.ApplicationUsers.Find(email);
            if (user == null)
            {
                return false;
            }
            user.PasswordHash = newPassword;
            _context.SaveChanges();
            return true;
        }

        public ApplicationUser GetUserByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}
