using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mime;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HireHub.Core.Entities;
using static HireHub.Core.Entities.User;

namespace HireHub.Core.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        //public int RoleId { get; set; }
        //public RoleDTO Role { get; set; }
        //public bool IsActive { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        //public bool HasUploadedGeneralResume { get; set; }
        //public int LoginAttempts { get; set; }
        //public bool IsTwoFactorEnabled { get; set; }
        //public DateTime? LastLogin { get; set; }
        //public List<JobsDTO> Jobs { get; set; }
    }
}