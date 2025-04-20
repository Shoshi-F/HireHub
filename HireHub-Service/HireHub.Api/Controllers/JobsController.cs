using AutoMapper;
using HireHub.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using HireHub.Api.PutModels;
using HireHub.Api.PostModels;
using HireHub.Core.IServices;
using HireHub.Core.ResultModel;
using System.Security.Claims;

namespace HireHub.API.Controllers
{

    [Route("api/jobs")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobsService _jobsService;
        private readonly IMapper _mapper;
        private readonly IResumesService _resumeService;
        private readonly IS3Service _s3Service;
        public JobsController(
            IJobsService jobsService,
            IMapper mapper,
            IResumesService resumeService,
            IS3Service s3Service)
        {
            _jobsService = jobsService;
            _mapper = mapper;
            _resumeService = resumeService;
            _s3Service = s3Service;
        }

        // GET: api/<JobsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobsDTO>>> Get()
        {
            return Ok(await _jobsService.GetAllAsync());
        }


        // GET api/<JobsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobsDTO>> Get(int id)
        {
            var job = await _jobsService.GetByIdAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            return Ok(job);
        }

        [HttpPost]
        public async Task<ActionResult<JobsDTO>> Post([FromBody] JobsPostModel jobPost)
        {
            var userId = (int)HttpContext.Items["UserId"];
            var jobDTO = _mapper.Map<JobsDTO>(jobPost);
            jobDTO.RecruiterId = userId;
            var result = await _jobsService.AddAsync(jobDTO);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        // PUT api/<JobsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<JobsDTO>> Put(int id, [FromBody] JobsPutModel jobPut)
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdString == null)
            {
                return Unauthorized();
            }
            if (!int.TryParse(userIdString, out int userId))
            {
                return BadRequest("Invalid user ID");
            }
            var authorizationResult = await _jobsService.CanManageJob(id, userId);
            if (!authorizationResult.IsSuccess)
            {
                return NotFound();
            }
            if (!authorizationResult.Value)
            {
                return Unauthorized();
            }
            var job = _mapper.Map<JobsDTO>(jobPut);

            var resultJob = await _jobsService.UpdateAsync(id, job);
            return Ok(resultJob);
        }

        [HttpPost("{id}/CreatePresignedUrlForResume")]
        public async Task<ActionResult<string>> CreatePresignedUrlForResume(int id, [FromBody] ResumesPostModel resume)
        {
            var userId = HttpContext.Items["UserId"].ToString();

            var presignedUrl = await _s3Service.GeneratePresignedUrlAsync(id.ToString(), userId, resume.ContentType);
            if (presignedUrl == null)
            {
                return BadRequest();
            }
            return Ok(presignedUrl);
        }

        // POST api/<JobsController>
        [HttpPost("{id}/Apply")]
        public async Task<ActionResult<ApplicationsDTO>> Apply(int id)
        {
            var userId = (int)HttpContext.Items["UserId"];
            var application = await _jobsService.ApplyAsync(id, userId);
            if (application == null)
            {
                return BadRequest();
            }
            return Ok(application);
        }


        [HttpPost("{id}/ConfirmResumesUploadAndApply")]
        public async Task<ActionResult<ResumesDTO>> ConfirmResumesUploadAndApply(int id, [FromBody] ResumesPostModel resume)
        {
            var userId = (int)HttpContext.Items["UserId"];

            var resumeResult = await _resumeService.ConfirmJobSpecificResumesUpload(id, userId, resume.ContentType);
            if (resumeResult == null)
            {
                return BadRequest();
            }

            var applicationResult = await _jobsService.ApplyWithResumesAsync(id, userId, resumeResult.Id);
            if (applicationResult == null)
            {
                return BadRequest();
            }

            return Ok(applicationResult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> delete(int id)
        {
            try
            {
                await _jobsService.DeleteAsync(id);
                return Ok(true);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut("{id}/change-status")]
        public async Task<ActionResult<JobsDTO>> UpdateStatus(int id)
        {
            var result = await _jobsService.ChangeStatus(id);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                if (result.ErrorCode == 404)
                {
                    return NotFound();
                }
                return BadRequest();
            }
        }
    }
}
