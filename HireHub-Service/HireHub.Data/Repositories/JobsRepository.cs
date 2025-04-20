using HireHub.Core.Entities;
using HireHub.Core.IRepositories;
using HireHub.Data.Repositories;
using HireHub.Data;
using Microsoft.EntityFrameworkCore;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireHub.Data.Repositories
{
    public class JobsRepository : Repository<Jobs>, IJobsRepository
    {
        public JobsRepository(DataContext context) : base(context)
        {
        }

        public async Task<Jobs?> GetJobWithApplicationsAsync(int jobId)
        {
            return await _context.Jobs
            .Include(j => j.Applications)
            .FirstOrDefaultAsync(j => j.Id == jobId);
        }

        public async override Task<Jobs> UpdateAsync(int id, Jobs entity)
        {
            return await base.UpdateAsync(id, entity);
        }
    }
}

