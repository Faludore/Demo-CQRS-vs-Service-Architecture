using DemoCQRSvsSevrice.Models;
using DemoCQRSvsSevrice.Repositories;
using System.Collections.Generic;

namespace DemoCQRSvsSevrice.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IList<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void InsertUser(User entity)
        {
            _userRepository.Create(entity);
        }

        public void UpdateUser(User entity)
        {
            _userRepository.Update(entity);
        }

        public void DeleteUser(User entity)
        {
            _userRepository.Delete(entity);
        }
    }
}
