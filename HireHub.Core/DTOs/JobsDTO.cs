using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace HireHub.Core.DTOs
{
    public class JobsDTO
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public string? Company { get; set; }
        public string JobRequirements { get; set; }
        public string JobSkills { get; set; }
        public int YearsOfExperienceRequired { get; set; }
        public string Area { get; set; }
        public int RecruiterId { get; set; }
        public UserDTO RecruitingUser { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public string Category { get; set; }
        public int ViewsCount { get; set; }
        public string SalaryRange { get; set; }
        public List<ApplicationsDTO> Applications { get; set; }
    }
}