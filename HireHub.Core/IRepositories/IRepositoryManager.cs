using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireHub.Core.IRepositories;
using HireHub.Core.Entities;

namespace HireHub.Core.IRepositories
{
    public interface IRepositoryManager
    {
        public IJobsRepository Jobs { get; }
        public IUserRepository Users { get; }
        public IResumesRepository Resumes { get; }
        public IRoleRepository Roles { get; }
        //public IPermissionRepository Permissions { get; }
        public IApplicationsRepository Applications { get; }

        Task<int> SaveAsync();
    }
}
