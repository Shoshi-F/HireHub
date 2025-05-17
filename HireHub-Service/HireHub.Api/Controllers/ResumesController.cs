using AutoMapper;
using HireHub.Core.IServices;
using Microsoft.AspNetCore.Mvc;
using HireHub.Api.PostModels;
using HireHub.Core.DTOs;
using HireHub.Core.Entities;
using HireHub.Core.IServices;

namespace HireHub.API.Controllers
{
    [Route("api/resumes")]
    [ApiController]
    public class ResumesController : ControllerBase
    {
        private readonly IResumesService _resumesService;
        private readonly IS3Service _s3Service;
        private readonly IMapper _mapper;
        public ResumesController(
            IResumesService resumesService,
            IMapper mapper,
            IS3Service s3Service)
        {
            _resumesService = resumesService;
            _mapper = mapper;
            _s3Service = s3Service;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resumes>>> Get()
        {
            var results = await _resumesService.GetAllAsync();
            return Ok(results);
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Resumes>> Get(int id)
        {
            var result = await _resumesService.GetByIdAsync(id);
            return Ok(result);
        }

       
        [HttpPost("generate-upload-url")]
        public async Task<IActionResult> GenerateUploadUrl([FromBody] ResumesPostModel resume)
        {
            var userId = HttpContext.Items["UserId"].ToString();
            var url = await _s3Service.GeneratePresignedUrlAsync("general", userId, resume.ContentType);
            if (url == null)
            {
                return BadRequest();
            }
            return Ok(new { presignedUrl = url });
        }

        [HttpPost("confirm-upload")]
        public async Task<IActionResult> ConfirmUpload([FromBody] ResumesPostModel resume)
        {
            var userId = (int)HttpContext.Items["UserId"];
            var resumesResult = _resumesService.ConfirmGeneralResumesUpload(userId, resume.ContentType);
            return Ok(resumesResult);
        }

     
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Put(int id, [FromBody] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                // Example: UploadToAws(stream, file.FileName);
            }

            return Ok("File uploaded successfully.");
        }

        // DELETE api/<ResumesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
