using HireHub.Data.Repositories;
using HireHub.Data;
using HireHub.Core.Entities;
using HireHub.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HireHub.Data.Repositories
{
    public class ApplicationsRepository : Repository<Applications>, IApplicationsRepository
    {
        public ApplicationsRepository(DataContext context) : base(context)
        {
        }
    }
}
