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

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.AsNoTracking();
        }

        // Get user by ID
        public User GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == userId);
        }

        // Get user by email
        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        // Create a new user
        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        // Update an existing user
        public bool UpdateUser(User user)
        {
            var existingUser = _context.Users.Find(user.UserId);
            if (existingUser == null)
            {
                return false;
            }
            _context.Entry(existingUser).CurrentValues.SetValues(user);
            _context.SaveChanges();
            return true;
        }

        // Delete user
        public bool DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        // Authenticate user
        public User AuthenticateUser(string email, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
        // Change password
        public bool ChangePassword(int userId, string currentPassword, string newPassword)
        {
            var user = _context.Users.Find(userId);
            if (user == null || user.Password != currentPassword)
            {
                return false;
            }
            user.Password =  newPassword;
            _context.SaveChanges();
            return true;
        }
    }
}
