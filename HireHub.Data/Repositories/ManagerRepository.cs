using HireHub.Core.IRepositories;
using HireHub.Data.Repositories;
using HireHub.Data;
using HireHub.Core.Entities;
using HireHub.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireHub.Data.Reposories
{
    public class RepositoryManager(
        DataContext context,
        IJobsRepository jobRepository,
        IUserRepository userRepository,
    IResumesRepository cvRepository,
        IRoleRepository roleRepository,
        IApplicationsRepository applicationRepository
    ) : IRepositoryManager
    {
        private readonly DataContext _context = context;
        public IJobsRepository Jobs => jobRepository;
        public IUserRepository Users => userRepository;
        public IResumesRepository Resumes => cvRepository;
        public IRoleRepository Roles => roleRepository;
        public IApplicationsRepository Applications => applicationRepository;

        //public IPermissionRepository Permissions => permissionRepository;


        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
