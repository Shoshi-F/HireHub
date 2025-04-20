using HireHub.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HireHub.Core.IServices
{
    public interface IUserService
    {
        //get
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UserDTO> GetUserByEmailAsync(string email);
        //put
        Task<UserDTO> RegisterAsync(UserDTO userDTO);
        //post
        Task<UserDTO> LoginAsync(string email, string password);
        Task<bool> UpdatePasswordAsync(int id, string password);
        //delete
        Task<bool> DeleteUserAsync(int id);
    }
}