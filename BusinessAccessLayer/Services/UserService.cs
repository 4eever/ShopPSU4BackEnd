using AutoMapper;
using BusinessAccessLayer.DTOs;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> AddUser(UserDTO userDTO)
        {
            var userEntity = _mapper.Map<UserDTO, User>(userDTO);
            await _userRepository.AddUser(userEntity);

            User user = await _userRepository.GetUserByLogin(userEntity.UserLogin);
            var userDTOResult = _mapper.Map<User, UserDTO>(user);

            return userDTOResult;
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();

            //сделай спискок usersDTO через LINQ и automapper
            var usersDTO = (from u in users
                            select _mapper.Map<User, UserDTO>(u)
                            ).ToList();

            return usersDTO;
        }

        public async Task<UserDTO> GetUserById(int userId)
        {
            var user = await _userRepository.GetUserById(userId);
            var userDTO = _mapper.Map<User, UserDTO>(user);

            return userDTO;
        }

        public async Task DeleteUser(int userId)
        {
            await _userRepository.DeleteUser(userId);
        }

        public async Task<UserDTO> UpdateUser(UserDTO userDTO)
        {
            var userEntity = _mapper.Map<UserDTO, User>(userDTO);
            await _userRepository.UpdateUser(userEntity);

            User user = await _userRepository.GetUserByLogin(userEntity.UserLogin);
            var userDTOResult = _mapper.Map<User, UserDTO>(user);

            return userDTOResult;
        }
    }
}
