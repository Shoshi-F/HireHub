using HireHub.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireHub.Core.IRepositories
{
    public interface IJobsRepository : IRepository<Jobs>
    {
        public Task<Jobs?> GetJobWithApplicationsAsync(int jobId);

    }
}
