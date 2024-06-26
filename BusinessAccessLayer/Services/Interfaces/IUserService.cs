using BusinessAccessLayer.DTOs;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> SignUp(UserDTO userDTO);
        Task<UserDTO> LogIn(UserDTO userDTO);
        Task<List<UserDTO>> GetAllUsers();
        Task<UserDTO> GetUserById(int userId);
        Task<UserDTO> UpdateUser(UserDTO user);
        Task DeleteUser(int userId);
    }
}
