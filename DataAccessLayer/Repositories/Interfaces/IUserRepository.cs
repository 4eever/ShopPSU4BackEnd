using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int userId);
        Task UpdateUser(User user);
        Task DeleteUser(int userId);
        Task<User> GetUserByLogin(string userLogin);
    }
}
