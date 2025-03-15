using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.Data.Models;

namespace BookHaven.Business.Interfaces
{
    public interface IUserService
    {
        List<UserModel> GetAllUsers();
        UserModel GetUserByUsername(string username);
        void AddUser(UserModel user);
        void UpdateUser(UserModel user);
        void DeleteUser(Guid userId);
        void ResetPassword(Guid userId, string newPasswordHash);
        string HashPassword(string password);
        void UnlockUser(Guid userId);
    }
}
