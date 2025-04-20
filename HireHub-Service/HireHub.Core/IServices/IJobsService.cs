using HireHub.Core.DTOs;
using HireHub.Core.Entities;
using HireHub.Core.ResultModel;
using System;
//using static System.Net.Mime.MediaTypeNames;

namespace HireHub.Core.IServices
{
    public interface IJobsService
    {
        Task<IEnumerable<JobsDTO>> GetAllAsync();
        Task<JobsDTO> GetByIdAsync(int id);
        Task<JobsDTO> AddAsync(JobsDTO job);
        Task<JobsDTO> UpdateAsync(int id, JobsDTO job);
        Task DeleteAsync(int id);
        Task<List<Applications>> GetApplicationsByJobId(int id);
        Task<Result<ApplicationsDTO>> ApplyAsync(int jobId, int userId);
        Task<Result<ApplicationsDTO>> ApplyWithResumesAsync(int jobId, int userId, int resumeId);
        public Task<Result<bool>> CanManageJob(int jobId, int userId);
        public Task<Result<JobsDTO>> ChangeStatus(int jobId);
    }
}
