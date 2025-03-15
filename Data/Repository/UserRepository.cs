using System;
using Microsoft.Data.SqlClient;
using BookHaven.Data.Models;
using System.Security.Cryptography;
using System.Text;

namespace BookHaven.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString = "Server=DESKTOP-KVP3P8D\\MSSQLSERVER2022;Database=BookHaven;Integrated Security=True;TrustServerCertificate=True;"; // Set your DB connection

        public List<UserModel> GetAllUsers()
        {
            List<UserModel> users = new List<UserModel>();
            string query = "SELECT UserID, Username, Email, Role, CreatedDate, IsActive FROM [User]";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new UserModel
                        {
                            UserID = reader.GetGuid(0),
                            Username = reader.GetString(1),
                            Email = reader.GetString(2),
                            Role = reader.GetString(3),
                            CreatedDate = reader.GetDateTime(4),
                            IsActive = reader.GetString(5)
                        });
                    }
                }
            }
            return users;
        }

        // Fetch user by username
        public UserModel? GetUserByUsername(string username)
        {
            UserModel? user = null;
            string query = "SELECT * FROM [User] WHERE Username = @Username";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel
                        {
                            UserID = reader.GetGuid(0),
                            Username = reader.GetString(1),
                            PasswordHash = reader.GetString(2),
                            Role = reader.GetString(3), // Check if this returns correct role
                            Email = reader.GetString(4),
                            CreatedDate = reader.GetDateTime(5),
                            IsActive = reader.GetString(6)
                        };

                        // Debugging
                        Console.WriteLine($"DEBUG: Retrieved Role from DB = {user.Role}");
                    }
                }
            }
            return user;
        }

        // Add new user
        public void AddUser(UserModel user)
        {
            string query = "INSERT INTO [User] (UserID, Username, Password, Role, Email, CreatedDate, IsActive) VALUES (@UserID, @Username, @Password, @Role, @Email, @CreatedDate, @IsActive)";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", user.UserID);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", HashPassword(user.PasswordHash)); // Hashing password
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@CreatedDate", user.CreatedDate);
                cmd.Parameters.AddWithValue("@IsActive", user.IsActive);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Validate user credentials
        public bool ValidateUser(string username, string password)
        {
            UserModel user = GetUserByUsername(username);

            if (user == null)
            {
                MessageBox.Show("User not found!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if account is locked
            if (user.IsLocked)
            {
                MessageBox.Show("Your account is locked due to multiple failed attempts. Contact an admin.", "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string hashedInputPassword = HashPassword(password);

            if (user.PasswordHash == hashedInputPassword)
            {
                // Login success, reset failed attempts
                ResetFailedAttempts(user.UserID);
                return true;
            }
            else
            {
                // Increment failed attempts and lock if necessary
                IncrementFailedAttempts(user.UserID);
                return false;
            }
        }

        private void IncrementFailedAttempts(Guid userId)
        {
            string query = @"
                UPDATE [User] 
                SET FailedAttempts = FailedAttempts + 1, 
                    IsLocked = CASE WHEN FailedAttempts + 1 >= 3 THEN 1 ELSE 0 END 
                WHERE UserID = @UserID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void ResetFailedAttempts(Guid userId)
        {
            string query = "UPDATE [User] SET FailedAttempts = 0, IsLocked = 0 WHERE UserID = @UserID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateUser(UserModel user)
        {
            string query = "UPDATE [User] SET Username = @Username, Email = @Email, Role = @Role, IsActive = @IsActive WHERE UserID = @UserID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", user.UserID);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.Parameters.AddWithValue("@IsActive", user.IsActive);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteUser(Guid userId)
        {
            string query = "DELETE FROM [User] WHERE UserID = @UserID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ResetPassword(Guid userId, string hashedPassword)
        {
            string query = "UPDATE [User] SET Password = @PasswordHash WHERE UserID = @UserID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword); 

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Hash Password using SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public void UnlockUser(Guid userId)
        {
            string query = "UPDATE [User] SET FailedAttempts = 0, IsLocked = 0 WHERE UserID = @UserID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", userId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
