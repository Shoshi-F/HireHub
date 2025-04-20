using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HireHub.Core.DTOs
{
    public class ResumesDTO
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public UserDTO Candidate { get; set; }
        public string Path { get; set; }
        public DateTime UploadedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsGeneral { get; set; }
        public string ContentType { get; set; }
        public int DownloadCount { get; set; }
    }
}