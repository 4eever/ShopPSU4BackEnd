using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly ApplicationContext _db;

        public UserRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task AddUser(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _db.Users.FindAsync(userId);
        }

        public async Task UpdateUser(User user)
        {
            var existingUser = await _db.Users.FindAsync(user.UserId);
            if (existingUser != null)
            {
                existingUser.UserLogin = user.UserLogin;
                existingUser.UserHashedPassword = user.UserHashedPassword;
                existingUser.UserName = user.UserName;
                existingUser.UserSurname = user.UserSurname;

                _db.Users.Update(existingUser);

                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(int userId)
        {
            var user = await _db.Users.FindAsync(userId);
            if (user != null)
            {
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<User> GetUserByLogin(string userLogin)
        {
            return await _db.Users.FirstOrDefaultAsync(user => user.UserLogin == userLogin);
        }
    }
}
