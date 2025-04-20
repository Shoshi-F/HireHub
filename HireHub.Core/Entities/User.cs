using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireHub.Core.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
        public List<Jobs> Jobs { get; set; } = new List<Jobs>();
        [Required]
        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public bool IsActive { get; set; } = true;
        [Column("CreatedOn", TypeName = "timestamp with time zone")]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public bool HasUploadedGeneralResume { get; set; }
        public int LoginAttempts { get; set; } = 0;
        public bool IsTwoFactorEnabled { get; set; } = false; // אימות דו-שלבי
        public DateTime? LastLogin { get; set; } // תאריך ושעת הכניסה האחרונה
    }
}