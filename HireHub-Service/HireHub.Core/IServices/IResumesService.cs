using HireHub.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireHub.Core.IServices
{
    public interface IResumesService
    {
        Task<IEnumerable<ResumesDTO>> GetAllAsync();
        Task<ResumesDTO> GetByIdAsync(int id);
        Task<ResumesDTO> UpdateAsync(int id, MemoryStream stream);
        Task<bool> DeleteAsync(int id);
        Task<ResumesDTO> ConfirmGeneralResumesUpload(int userId, string contentType);
        Task<ResumesDTO> ConfirmJobSpecificResumesUpload(int jobId, int userId, string contentType);
    }
}


