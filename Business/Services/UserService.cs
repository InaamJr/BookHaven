using System.Text;
using BookHaven.Data.Models;
using BookHaven.Data.Repository;
using System.Security.Cryptography;
using BookHaven.Business.Interfaces;

namespace BookHaven.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool AuthenticateUser(string username, string password)
        {
            return _userRepository.ValidateUser(username, password);
        }

        public List<UserModel> GetAllUsers() => _userRepository.GetAllUsers();

        public UserModel GetUserByUsername(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }

        public string GetUserRole(string username)
        {
            UserModel user = _userRepository.GetUserByUsername(username);
            return user?.Role;
        }

        public void AddUser(UserModel user) => _userRepository.AddUser(user);
        public void UpdateUser(UserModel user) => _userRepository.UpdateUser(user);
        public void DeleteUser(Guid userId) => _userRepository.DeleteUser(userId);
        public void ResetPassword(Guid userId, string newPassword)
        {
            string hashedPassword = HashPassword(newPassword);  
            _userRepository.ResetPassword(userId, hashedPassword); 
        }


        public string HashPassword(string password)
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
            _userRepository.UnlockUser(userId);
        }
    }
}
