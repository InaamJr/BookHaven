using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.Data.Models;

namespace BookHaven.Data.Repository
{
    public interface IUserRepository
    {
        List<UserModel> GetAllUsers();
        UserModel GetUserByUsername(string username);
        void AddUser(UserModel user);
        bool ValidateUser(string username, string password);
        void UpdateUser(UserModel user);
        void DeleteUser(Guid userId);
        void ResetPassword(Guid userId, string newPasswordHash);
        void UnlockUser(Guid userId);
    }
}
