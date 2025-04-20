using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using HireHub.Core.Entities;

namespace HireHub.Core.DTOs
{
    public class ApplicationsDTO
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public UserDTO CandidateUser { get; set; }
        public int JobId { get; set; }
        public JobsDTO JobCandidate { get; set; }
        public int? ResumeId { get; set; }
        public ResumesDTO UserResume { get; set; }
        public int Score { get; set; }
        public string Status { get; set; }
        public DateTime ApplicationDate { get; set; }
    }
}