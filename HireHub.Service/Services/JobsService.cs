using HireHub.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using AutoMapper;
using HireHub.Core.DTOs;
using HireHub.Core.Entities;
using HireHub.Core.IRepositories;
using HireHub.Core.IServices;
using HireHub.Core.ResultModel;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;


namespace HireHub.Service.Services
{
    public class JobsService : IJobsService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IResumesService _resumesService;

        public JobsService(
            IRepositoryManager repository,
            IMapper mapper,
            IResumesService resumesService)
        {
            _repository = repository;
            _mapper = mapper;
            _resumesService = _resumesService;
        }
        public async Task<JobsDTO> AddAsync(JobsDTO jobDto)
        {
            var job = _mapper.Map<Jobs>(jobDto);
            var resultJob = await _repository.Jobs.AddAsync(job);
            await _repository.SaveAsync();
            return _mapper.Map<JobsDTO>(resultJob);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _repository.Jobs.GetByIdAsync(id);
            if (item == null)
            {
                throw new Exception("User Not Found");
            }
            _repository.Jobs.DeleteAsync(item);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<JobsDTO>> GetAllAsync()
        {
            var jobs = await _repository.Jobs.GetAsync();
            return _mapper.Map<IEnumerable<JobsDTO>>(jobs);
        }

        public async Task<JobsDTO> GetByIdAsync(int id)
        {
            var job = await _repository.Jobs.GetByIdAsync(id);
            return _mapper.Map<JobsDTO>(job);
        }

        public async Task<List<Applications>> GetApplicationsByJobId(int id)
        {
            var job = await _repository.Jobs.GetJobWithApplicationsAsync(id);
            return job.Applications.ToList();
        }

        public async Task<JobsDTO> UpdateAsync(int id, JobsDTO jobDto)
        {
            var job = _mapper.Map<Jobs>(jobDto);
            var existingJob = await _repository.Jobs.GetByIdAsync(id);

            existingJob.UpdatedOn = DateTime.UtcNow;
            existingJob.JobTitle = job.JobTitle;
            existingJob.Description = job.Description;
            existingJob.JobRequirements = job.JobRequirements;
            existingJob.JobSkills = job.JobSkills;
            existingJob.YearsOfExperienceRequired = job.YearsOfExperienceRequired;
            existingJob.Area = job.Area;
            existingJob.Company = job.Company;

            var resultJob = await _repository.Jobs.UpdateAsync(id, existingJob);
            var resultJobDto = _mapper.Map<JobsDTO>(resultJob);
            await _repository.SaveAsync();
            return resultJobDto;
        }

        public async Task<Result<ApplicationsDTO>> ApplyAsync(int jobId, int userId)
        {
            // Check if the user has a general Resume uploaded
            var generalResume = await _repository.Resumes.GetGeneralResumesByUserIdAsync(userId);
            if (generalResume == null)
            {
                return Result<ApplicationsDTO>.Failure("General Resume not found", 404);
            }

            // Create a new application entity
            var application = new Applications
            {
                CandidateId = userId,
                JobId = jobId,
                ResumeId = generalResume.Id,
                Score = 0
            };

            await _repository.Applications.AddAsync(application);
            await _repository.SaveAsync();

            return Result<ApplicationsDTO>.Success(_mapper.Map<ApplicationsDTO>(application));
        }

        public async Task<Result<bool>> CanManageJob(int jobId, int userId)
        {
            var job = await _repository.Jobs.GetByIdAsync(jobId);
            if (job == null)
            {
                return Result<bool>.Failure("Job not found", 404);
            }
            return Result<bool>.Success(job.RecruiterId == userId);
        }

        public async Task<Result<ApplicationsDTO>> ApplyWithResumesAsync(int jobId, int userId, int resumeId)
        {
            var application = new Applications
            {
                CandidateId = userId,
                JobId = jobId,
                ResumeId = resumeId,
                Score = 0
            };

            await _repository.Applications.AddAsync(application);
            await _repository.SaveAsync();

            return Result<ApplicationsDTO>.Success(_mapper.Map<ApplicationsDTO>(application));
        }

        public async Task<Result<JobsDTO>> ChangeStatus(int jobId)
        {
            var existingJob = await _repository.Jobs.GetByIdAsync(jobId);
            if(existingJob == null)
            {
                return Result<JobsDTO>.Failure("Job not found", 404);
            }
            existingJob.IsActive = !existingJob.IsActive;
            var resultJob = _repository.Jobs.UpdateAsync(jobId, existingJob);
            await _repository.SaveAsync();
            return Result<JobsDTO>.Success(_mapper.Map<JobsDTO>(resultJob));
        }

        //Task<IEnumerable<JobsDTO>> IJobsService.GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //Task<JobsDTO> IJobsService.GetByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<JobsDTO> AddAsync(JobsDTO job)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<JobsDTO> UpdateAsync(int id, JobsDTO job)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<List<Applications>> IJobsService.GetApplicationsByJobId(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<Result<ApplicationsDTO>> IJobsService.ApplyAsync(int jobId, int userId)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<Result<ApplicationsDTO>> IJobsService.ApplyWithResumesAsync(int jobId, int userId, int cvId)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<Result<JobsDTO>> IJobsService.ChangeStatus(int jobId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
