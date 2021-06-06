using DemoCQRSvsSevrice.Models;
using System.Collections.Generic;

namespace DemoCQRSvsSevrice.Services
{
    public interface IUserService
    {
        IList<User> GetAllUsers();
        User GetUserById(int id);
        void InsertUser(User entity);
        void UpdateUser(User entity);
        void DeleteUser(User entity);
    }
}