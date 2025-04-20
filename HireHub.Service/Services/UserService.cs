using AutoMapper;
using HireHub.Core.DTOs;
using HireHub.Core.Entities;
using HireHub.Core.IRepositories;
using HireHub.Core.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HireHub.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return false;
            }
            _userRepository.DeleteAsync(user);
            return true;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> LoginAsync(string email, string password)
        {
            var user = await _userRepository.LoginAsync(email, password);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> RegisterAsync(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            var createdUser = await _userRepository.AddAsync(user);
            return _mapper.Map<UserDTO>(createdUser);
        }

        public async Task<bool> UpdatePasswordAsync(int id, string password)
        {
            return await _userRepository.UpdatePasswordAsync(id, password);
        }
    }
}