using HireHub.Core.Entities;
using HireHub.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HireHub.Data.Repositories
{
    public class ResumesRepository : Repository<Resumes>, IResumesRepository
    {
        public ResumesRepository(DataContext context) : base(context) { }

        public async override Task<Resumes> UpdateAsync(int id, Resumes entity)
        {
            entity.UpdatedOn = DateTime.Now;
            return await base.UpdateAsync(id, entity);
        }

        public async Task<Resumes?> GetGeneralResumesByUserIdAsync(int userId)
        {
            return await _context.Resumes.FirstOrDefaultAsync(x => x.CandidateId == userId && x.IsGeneral);
        }
    }
}
