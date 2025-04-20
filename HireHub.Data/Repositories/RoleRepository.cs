using HireHub.Core.Entities;
using Microsoft.EntityFrameworkCore;
using HireHub.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HireHub.Data.Repositories.RoleRepository;

namespace HireHub.Data.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(DataContext context) : base(context)
        {
        }

        public Task<bool> AddPermissionForRoleAsync(string roleName, Permission permission)
        {
            throw new NotImplementedException();
        }

        
        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            var result = await _context.Roles.Where(role => role.RoleName == roleName).FirstOrDefaultAsync();
            return result;
        }

        public Task<bool> IsRoleHasPermissionAsync(string roleName, string permissionName)
        {
            throw new NotImplementedException();
        }

        
    }
}