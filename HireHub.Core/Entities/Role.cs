using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireHub.Core.Entities
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int Id { get; set; } // מפתח ראשי (Primary Key)

        [Required]
        [MaxLength(50)]
        public string RoleName { get; set; } // שם התפקיד

        public string Description { get; set; } // תיאור התפקיד

        [Column("CreatedOn", TypeName = "timestamp with time zone")]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow; // תאריך יצירת התפקיד

        [Column("UpdatedOn", TypeName = "timestamp with time zone")]
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow; // תאריך עדכון התפקיד האחרון

        public ICollection<User>? Users { get; set; } = new List<User>(); // רשימת המשתמשים הקשורים לתפקיד
    }
}