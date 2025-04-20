using HireHub.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireHub.Core.IRepositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        public Task<bool> IsRoleHasPermissionAsync(string roleName, string permissionName);
        public Task<Role> GetRoleByNameAsync(string roleName);
        public Task<bool> AddPermissionForRoleAsync(string roleName, Permission permission);
    }
}
