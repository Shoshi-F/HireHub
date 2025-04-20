using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireHub.Core.Entities;

namespace HireHub.Core.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User> GetUserByEmailAsync(string email);
        public Task<User> LoginAsync(string email, string password);
        public Task<bool> UpdatePasswordAsync(int id, string password);
    }
}