using AutoMapper;
using BusinessAccessLayer.DTOs;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BusinessAccessLayer.Services.Interfaces;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessAccessLayer.Services.Implemertaions
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> SignUp(UserDTO userDTO)
        {
            //добавить авторизацию и аунтефикацию
            userDTO.UserPassword = HashPassword(userDTO.UserPassword);

            var userEntity = _mapper.Map<UserDTO, User>(userDTO);
            await _userRepository.AddUser(userEntity);

            var user = await _userRepository.GetUserByLogin(userEntity.UserLogin);
            var userDTOResult = _mapper.Map<User, UserDTO>(user);

            return userDTOResult;
        }

        public async Task<UserDTO> LogIn(UserDTO userDTO)
        {
            //добавить авторизацию и аунтефикацию
            var user = await _userRepository.GetUserByLogin(userDTO.UserLogin);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            var userDTOResult = _mapper.Map<User, UserDTO>(user);

            return userDTOResult;
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();

            var usersDTO = (from u in users
                            select _mapper.Map<User, UserDTO>(u)
                            ).ToList();

            return usersDTO;
        }

        public async Task<UserDTO> GetUserById(int userId)
        {
            var user = await _userRepository.GetUserById(userId);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            var userDTO = _mapper.Map<User, UserDTO>(user);

            return userDTO;
        }

        public async Task DeleteUser(int userId)
        {
            var user = await _userRepository.GetUserById(userId);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            await _userRepository.DeleteUser(userId);
        }

        public async Task<UserDTO> UpdateUser(UserDTO userDTO)
        {

            var userEntity = _mapper.Map<UserDTO, User>(userDTO);

            var userChehck = await _userRepository.GetUserById(userEntity.UserId);

            if (userChehck == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            await _userRepository.UpdateUser(userEntity);

            var user = await _userRepository.GetUserByLogin(userEntity.UserLogin);
            var userDTOResult = _mapper.Map<User, UserDTO>(user);

            return userDTOResult;
        }

        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
