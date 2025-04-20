using HireHub.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.CompilerServices;

namespace HireHub.Core.IRepositories
{
    public interface IResumesRepository : IRepository<Resumes>
    {
        // Task<IEnumerable<CV>> GetCVsWithJobAsync();
        public Task<Resumes?> GetGeneralResumesByUserIdAsync(int userId);
    }
}
