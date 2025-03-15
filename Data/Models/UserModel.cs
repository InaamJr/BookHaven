using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Data.Models
{
    public class UserModel
    {
        public Guid UserID { get; set; }  // Unique User ID
        public string Username { get; set; }  // Login Username
        public string PasswordHash { get; set; }  // Hashed Password
        public string Role { get; set; }  // User Role (Admin/SalesClerk)
        public string Email { get; set; }  // Email Address
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string IsActive { get; set; }  // 'active' or 'inactive'

        // Security Properties
        public int FailedAttempts { get; set; } = 0;  // Track failed logins
        public bool IsLocked { get; set; } = false;  // Account lock status
    }
}
